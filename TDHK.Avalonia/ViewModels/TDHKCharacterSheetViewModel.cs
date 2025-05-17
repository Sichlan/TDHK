using System;
using System.IO;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using ReactiveUI;
using TDHK.Common.Models;

namespace TDHK.Avalonia.ViewModels;

public class TDHKCharacterSheetViewModel : NavigableViewModel
{
    private Character _currentCharacter;

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
                if (args.PropertyName is not (nameof(Character.ExperienceSpent) or nameof(Character.Experience)))
                    return;

                BuyBaseAttributeAdvanceCommand.NotifyCanExecuteChanged();
            };
            OnPropertyChanged();
            OnPropertyChanged(nameof(IsCharacterLoaded));
        }
    }

    public bool IsCharacterLoaded => CurrentCharacter != null;

    public Interaction<bool, string> OpenFileDialog { get; }
    
    public ICommand NewCharacterCommand { get; }
    public ICommand SaveCharacterCommand { get; }
    public ICommand LoadCharacterCommand { get; }
    public IRelayCommand<string> BuyBaseAttributeAdvanceCommand { get; }

    public TDHKCharacterSheetViewModel()
    {
        OpenFileDialog = new Interaction<bool, string>();

        NewCharacterCommand = ReactiveCommand.CreateFromTask(() => ExecuteNewCharacterCommand());
        SaveCharacterCommand = ReactiveCommand.CreateFromTask(() => ExecuteSaveCharacterCommand(), this.WhenAnyValue(x => x.IsCharacterLoaded));
        LoadCharacterCommand = ReactiveCommand.CreateFromTask(() => ExecuteLoadCharacterCommand());

        BuyBaseAttributeAdvanceCommand = new RelayCommand<string>(ExecuteBuyAttributeAdvanceCommand, CanExecuteAdvanceCommand);
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

    private async Task ExecuteLoadCharacterCommand()
    {
        var path = await OpenFileDialog.Handle(false);

        if (!Path.Exists(path))
            return;

        CurrentCharacter = JsonConvert.DeserializeObject<Character>(await File.ReadAllTextAsync(path), new JsonSerializerSettings(){TypeNameHandling = TypeNameHandling.Auto});
    }

    private async Task ExecuteSaveCharacterCommand()
    {
        if (CurrentCharacter == null)
            return;

        var path = await OpenFileDialog.Handle(true);

        if (!Path.Exists(path))
            return;

        await File.WriteAllTextAsync(path, JsonConvert.SerializeObject(CurrentCharacter, new JsonSerializerSettings(){TypeNameHandling = TypeNameHandling.Auto}));
    }

    private async Task ExecuteNewCharacterCommand()
    {
        CurrentCharacter = new Character();
    }
}