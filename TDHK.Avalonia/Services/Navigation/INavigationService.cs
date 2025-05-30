﻿using System.ComponentModel;
using System.Threading.Tasks;
using TDHK.Avalonia.ViewModels;

namespace TDHK.Avalonia.Services.Navigation;

public interface INavigationService : INotifyPropertyChanged
{
    public NavigableViewModel ActiveViewModel { get; }
    public bool CanGoBack { get; }
    public bool CanGoForward { get; }

    public void Navigate(NavigableViewModel target);
    public Task NavigateAsync(NavigableViewModel target);
    public void GoBack();
    public bool TryGoBack();
    public Task GoBackAsync();
    public Task<bool> TryGoBackAsync();
    public void GoForward();
    public bool TryGoForward();
    public Task GoForwardAsync();
    public Task<bool> TryGoForwardAsync();
}