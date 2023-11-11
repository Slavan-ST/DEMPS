using MsBox.Avalonia;

namespace AvaloniaApplication2.ViewModels;

public class MainViewModel : ViewModelBase
{
    public string Greeting => "Welcome to Avalonia!";
    public MainViewModel()
    {
        MessageBoxManager.GetMessageBoxStandard("Caption", "Start").ShowAsync();
    }
}
