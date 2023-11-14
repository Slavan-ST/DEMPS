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
        {/*
            var box = MessageBoxManager
                .GetMessageBoxStandard("Caption", "Are you sure you would like to delete appender_replace_page_1?",
                    ButtonEnum.YesNo);

            var result = await box.ShowAsPopupAsync(this);*/
        });
    }
    public ICommand Click { get; set; }
}
