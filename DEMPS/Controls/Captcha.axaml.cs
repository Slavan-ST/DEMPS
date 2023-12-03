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





        #region Свойства

        public Bitmap? Image { get; set; } // изображение капчи
        public string Text { get; set; } = string.Empty; //Текст капчи
        public string InputUserText { get; set; } = string.Empty; //Текст капчи, введенный пользователем
        public bool IsVerified { get; set; } = false; // совпадает-ли текст введенный пользователем с текстом капчи

        #endregion

    }


    /*
     
    по сути пользователь должен создавать новый объект - капчу, на какой-либо странице.. 
    также он может получить доступ к тому пройдена ли капча или нет

    */
}
