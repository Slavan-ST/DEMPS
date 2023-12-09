using Avalonia.Controls;
using Avalonia.Media.Imaging;
using DEMPS.ViewModels;

namespace AvaloniaApplicationTest.Views
{
    public partial class CaptchaTest : UserControl
    {
        public CaptchaTest()
        {
            InitializeComponent();
            DataContext = new CaptchaViewModel();
        }
    }
}
