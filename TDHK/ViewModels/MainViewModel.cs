using System;
using System.Collections.ObjectModel;
using System.IO;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using Newtonsoft.Json;
using TDHK.ModernUi.Models;
using TDHK.ModernUi.Services.UserInformationService;
using TDHK.ModernUi.ViewModels.Common;
using TDHK.ModernUi.ViewModels.Users;

namespace TDHK.ModernUi.ViewModels;

public class MainViewModel : BaseViewModel
{
    private readonly IUserInformationMessageService _userInformationMessageService;
    private Character _currentCharacter;

    public ObservableCollection<UserMessageViewModel> UserMessageViewModels =>
        _userInformationMessageService.UserMessageViewModels;

    public Character CurrentCharacter
    {
        get => _currentCharacter;
        private set
        {
            if (Equals(value, _currentCharacter))
                return;

            _currentCharacter = value;
            _currentCharacter.PropertyChanged += (_, args) =>
            {
                if (args.PropertyName is nameof(Character.ExperienceSpent) or nameof(Character.Experience))
                {
                    BuyBaseAttributeAdvanceCommand.NotifyCanExecuteChanged();
                }
            };
            OnPropertyChanged();
            OnPropertyChanged(nameof(IsCharacterLoaded));
            SaveCharacterCommand.NotifyCanExecuteChanged();
        }
    }

    public bool IsCharacterLoaded => CurrentCharacter != null;

    public IRelayCommand NewCharacterCommand { get; }
    public IRelayCommand SaveCharacterCommand { get; }
    public IRelayCommand LoadCharacterCommand { get; }
    public IRelayCommand<string> BuyBaseAttributeAdvanceCommand { get; }

    public MainViewModel(IUserInformationMessageService userInformationMessageService)
    {
        _userInformationMessageService = userInformationMessageService;

        NewCharacterCommand = new RelayCommand(ExecuteNewCharacterCommand, CanExecuteNewCharacterCommand);
        SaveCharacterCommand = new RelayCommand(ExecuteSaveCharacterCommand, CanExecuteSaveCharacterCommand);
        LoadCharacterCommand = new RelayCommand(ExecuteLoadCharacterCommand, CanExecuteLoadCharacterCommand);

        BuyBaseAttributeAdvanceCommand = new RelayCommand<string>(ExecuteBuyAttributeAdvanceCommand, a => CanExecuteAdvanceCommand(a));
    }

    private bool CanExecuteAdvanceCommand(string attribute)
    {
        var cost = attribute switch
        {
            "HP" => 2,
            "STR" or "INS" or "INT" or "CHA" => 7,
            "REF" or "PER" or "WIL" or "STL" => 5,
            "ESC" or "LAB" => 3,
            _ => throw new ArgumentOutOfRangeException(nameof(attribute))
        };

        return CurrentCharacter.Experience - CurrentCharacter.ExperienceSpent >= cost;
    }

    private void ExecuteBuyAttributeAdvanceCommand(string attribute)
    {
        switch (attribute)
        {
            case "HP":
                CurrentCharacter.MaxHitPointBonus++;
                CurrentCharacter.HitPoints++;
                break;
            case "STR":
                CurrentCharacter.StrengthBonus++;
                break;
            case "INS":
                CurrentCharacter.InsightBonus++;
                break;
            case "INT":
                CurrentCharacter.IntelligenceBonus++;
                break;
            case "CHA":
                CurrentCharacter.CharismaBonus++;
                break;
            case "REF":
                CurrentCharacter.ReflexBonus++;
                break;
            case "PER":
                CurrentCharacter.PerceptionBonus++;
                break;
            case "WIL":
                CurrentCharacter.WillpowerBonus++;
                break;
            case "STL":
                CurrentCharacter.StyleBonus++;
                break;
            case "ESC":
                CurrentCharacter.SpellCardSlots++;
                break;
            case "LAB":
                CurrentCharacter.AbilityTargetNumberDiscount++;
                break;
        }
    }

    private static bool CanExecuteLoadCharacterCommand()
    {
        return true;
    }

    private void ExecuteLoadCharacterCommand()
    {
        var dialog = new OpenFileDialog()
        {
            Filter = "TDHK Character (*.tdhkc)|*.tdhkc|All files (*.*)|*.*",
            AddExtension = true,
            CheckFileExists = false,
            CheckPathExists = false,
            RestoreDirectory = true
        };

        if (dialog.ShowDialog() != true
            || !Path.Exists(Path.GetDirectoryName(dialog.FileName)))
            return;

        CurrentCharacter = JsonConvert.DeserializeObject<Character>(File.ReadAllText(dialog.FileName), new JsonSerializerSettings(){TypeNameHandling = TypeNameHandling.Auto});
    }

    private bool CanExecuteSaveCharacterCommand()
    {
        return CurrentCharacter != null;
    }

    private void ExecuteSaveCharacterCommand()
    {
        if (CurrentCharacter == null)
            return;

        var dialog = new OpenFileDialog()
        {
            Filter = "TDHK Character (*.tdhkc)|*.tdhkc|All files (*.*)|*.*",
            AddExtension = true,
            CheckFileExists = false,
            CheckPathExists = false,
            RestoreDirectory = true,
            FileName =
                $"{(string.IsNullOrEmpty(CurrentCharacter.Name) ? $"unnamed_character_{Guid.NewGuid()}" : CurrentCharacter.Name.Replace(" ", "_"))}.tdhkc"
        };

        if (dialog.ShowDialog() != true
            || !Path.Exists(Path.GetDirectoryName(dialog.FileName)))
            return;

        File.WriteAllText(dialog.FileName, JsonConvert.SerializeObject(CurrentCharacter, new JsonSerializerSettings(){TypeNameHandling = TypeNameHandling.Auto}));
    }

    private static bool CanExecuteNewCharacterCommand()
    {
        return true;
    }

    private void ExecuteNewCharacterCommand()
    {
        CurrentCharacter = new Character();
    }
}