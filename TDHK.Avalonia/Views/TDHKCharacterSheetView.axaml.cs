using System;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Platform.Storage;
using Avalonia.ReactiveUI;
using ReactiveUI;
using TDHK.Avalonia.ViewModels;

namespace TDHK.Avalonia.Views;

public partial class TDHKCharacterSheetView : ReactiveUserControl<TDHKCharacterSheetViewModel>
{
    public TDHKCharacterSheetView()
    {
        InitializeComponent();
        this.WhenActivated(a => a(ViewModel?.OpenFileDialog.RegisterHandler(OpenFileDialogAsync)));
    }

    private async Task OpenFileDialogAsync(IInteractionContext<bool, string> obj)
    {
        var topLevel = TopLevel.GetTopLevel(this);
        if (topLevel == null)
            return;

        var path = obj.Input
            ? (await topLevel.StorageProvider.SaveFilePickerAsync(new FilePickerSaveOptions()
            {
                FileTypeChoices = new[]
                {
                    new FilePickerFileType("TDHK Character") {Patterns = new[] {"*.tdhkc"}},
                    FilePickerFileTypes.All
                }
            }))?.Path.AbsolutePath
            : (await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions()
            {
                FileTypeFilter = new[]
                {
                    new FilePickerFileType("TDHK Character") {Patterns = new[] {"*.tdhkc"}},
                    FilePickerFileTypes.All
                },
                AllowMultiple = false
            })).FirstOrDefault()?.Path.AbsolutePath;

        obj.SetOutput(path);
    }
}