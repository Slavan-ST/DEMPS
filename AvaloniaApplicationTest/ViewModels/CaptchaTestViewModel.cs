using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplicationTest.ViewModels
{
    public class CaptchaTestViewModel:ViewModelBase
    {


        // public Bitmap? Image { get; set; } // изображение капчи
        public string Text { get; set; } = string.Empty; //Текст капчи
        public string InputUserText { get; set; } = string.Empty; //Текст капчи, введенный пользователем
        public bool IsVerified { get; set; } = false; // совпадает-ли текст введенный пользователем с текстом капчи
    }
}
