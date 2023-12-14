using Avalonia.Controls;
using Avalonia.Media.Imaging;
using DEMPS.ViewModels;

namespace DEMPS.Controls
{
    public partial class Captcha : UserControl
    {
        public Captcha()
        {
            DataContext = new CaptchaViewModel();
        }
    }
}
