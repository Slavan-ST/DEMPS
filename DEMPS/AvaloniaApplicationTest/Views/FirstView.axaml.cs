using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using AvaloniaApplicationTest.ViewModels;
using ReactiveUI;

namespace AvaloniaApplicationTest.Views
{
    public partial class FirstView : ReactiveUserControl<FirstViewModel>
    {
        public FirstView()
        {
            this.WhenActivated(disposables => { });
            AvaloniaXamlLoader.Load(this);
        }
    }
}
