using System;
using System.Reactive.Linq;
using Avalonia.ReactiveUI;
using ReactiveUI;
using System.Windows.Input;

namespace Avalonia.MusicStore.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        ShowDialog = new Interaction<MusicStoreViewModel, AlbumViewModel?>();
        
        BuyMusicCommand = ReactiveCommand.Create(async () =>
        {
            var store = new MusicStoreViewModel();
            
            var result = await ShowDialog.Handle(store);
        });
    }
    
    public ICommand BuyMusicCommand { get; }
    
    public Interaction<MusicStoreViewModel, AlbumViewModel?> ShowDialog { get; }
}
