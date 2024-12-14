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
            OnPropertyChanged();
            OnPropertyChanged(nameof(IsCharacterLoaded));
            SaveCharacterCommand.NotifyCanExecuteChanged();
        }
    }

    public bool IsCharacterLoaded => CurrentCharacter != null;

    public IRelayCommand NewCharacterCommand { get; }
    public IRelayCommand SaveCharacterCommand { get; }
    public IRelayCommand LoadCharacterCommand { get; }

    public MainViewModel(IUserInformationMessageService userInformationMessageService)
    {
        _userInformationMessageService = userInformationMessageService;

        NewCharacterCommand = new RelayCommand(ExecuteNewCharacterCommand, CanExecuteNewCharacterCommand);
        SaveCharacterCommand = new RelayCommand(ExecuteSaveCharacterCommand, CanExecuteSaveCharacterCommand);
        LoadCharacterCommand = new RelayCommand(ExecuteLoadCharacterCommand, CanExecuteLoadCharacterCommand);
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