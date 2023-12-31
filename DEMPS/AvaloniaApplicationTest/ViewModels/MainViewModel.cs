using DEMPS.Services;
using MsBox.Avalonia;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Windows.Input;
using System;
using System.Diagnostics;

namespace AvaloniaApplicationTest.ViewModels;

public class MainViewModel : ReactiveObject
{
    public MainViewModel()
    {
        CmdTest = ReactiveCommand.Create(() =>
        {
            MessageBox.Show("message","test!");
        });
    }
    public ICommand CmdTest { get; set; }
}
