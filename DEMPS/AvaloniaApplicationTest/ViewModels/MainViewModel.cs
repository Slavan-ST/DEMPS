using DEMPS.Services;
using MsBox.Avalonia;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Windows.Input;
using System;
using System.Diagnostics;

namespace AvaloniaApplicationTest.ViewModels;

public class MainViewModel : ReactiveObject, IScreen
{
    public MainViewModel()
    {
        Next = ReactiveCommand.CreateFromObservable(
                () => Router.Navigate.Execute(new FirstViewModel(this))
            );
    }
    public ICommand Next { get; set; }

    public RoutingState Router { get; } = new RoutingState();
}
