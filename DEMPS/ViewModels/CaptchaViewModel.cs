using Avalonia.Controls;
using DEMPS.Models;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEMPS.ViewModels
{
    public class CaptchaViewModel:ReactiveObject
    {
        public CaptchaViewModel()
        {
            int lengthCaptcha = 10;
            Image = new Captcha(lengthCaptcha).Image;
        }

        // public Bitmap? Image { get; set; } // изображение капчи
        [Reactive]
        public Grid Image { get; set; }
        [Reactive]
        public string Text { get; set; } = string.Empty; //Текст капчи
        [Reactive]
        public string InputUserText { get; set; } = string.Empty; //Текст капчи, введенный пользователем
        [Reactive]
        public bool IsVerified { get; set; } = false; // совпадает-ли текст введенный пользователем с текстом капчи
    }
}
