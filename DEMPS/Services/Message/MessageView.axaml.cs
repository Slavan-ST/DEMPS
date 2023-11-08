using Avalonia.Controls;

namespace DEMPS.Services.Message
{
    public partial class MessageView : UserControl
    {
        public MessageView(string text)
        {
            InitializeComponent();
            DataContext = new MessageViewModel(text);
        }
    }
}
