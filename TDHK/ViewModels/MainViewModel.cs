using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
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
        set
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

    private bool CanExecuteLoadCharacterCommand()
    {
        return true;
    }

    private void ExecuteLoadCharacterCommand()
    {
        throw new System.NotImplementedException();
    }

    private bool CanExecuteSaveCharacterCommand()
    {
        return CurrentCharacter != null;
    }

    private void ExecuteSaveCharacterCommand()
    {
        throw new System.NotImplementedException();
    }

    private bool CanExecuteNewCharacterCommand()
    {
        return true;
    }

    private void ExecuteNewCharacterCommand()
    {
        CurrentCharacter = new Character();
    }
}