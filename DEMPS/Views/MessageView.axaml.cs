using Avalonia.Controls;

namespace DEMPS.Views
{
    public partial class MessageView : UserControl
    {
        public MessageView(string text)
        {
            InitializeComponent();
            DataContext = new ViewModels.MessageViewModel(text);
        }
    }
}
