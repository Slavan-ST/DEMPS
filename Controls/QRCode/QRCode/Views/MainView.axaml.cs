using Avalonia.Controls;
using QRCode.ViewModels;

namespace QRCode.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
    }
}
