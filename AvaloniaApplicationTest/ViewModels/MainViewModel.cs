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
        this.WhenAnyValue(x => x.IsVerified).Subscribe(x =>
        {
            Debug.WriteLine("Message haven't now!!" + IsVerified);
        });
    }

    string _text = "";
    public string Text
    {
        get => _text;
        set => this.RaiseAndSetIfChanged(ref _text, value);
    }




    bool _isVerified = false;
    public bool IsVerified
    {
        get => _isVerified;
        set=> this.RaiseAndSetIfChanged(ref _isVerified, value);
    }
}
