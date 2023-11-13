using DEMPS.Services;
using ReactiveUI;
using System.Windows.Input;

namespace AvaloniaApplicationTest.ViewModels;

public class MainViewModel : ViewModelBase
{
    public string Greeting => "Welcome to Avalonia!";
    public MainViewModel()
    {
        Click = ReactiveCommand.Create(() =>
        {
            if (new MessageBox("text").Show() == DEMPS.Models.DialogResult.OK)
            {
                new MessageBox("t2").Show();
            }
        });
    }
    public ICommand Click { get; set; }
}
