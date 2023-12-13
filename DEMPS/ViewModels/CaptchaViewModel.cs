using Avalonia.Controls;
using DEMPS.Models;
using MsBox.Avalonia;
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
            int lengthCaptcha = 6;
            Captcha captcha = new Captcha(lengthCaptcha);

            Image = captcha.Image;
            Text = captcha.Text;

            this.WhenAnyValue(x => x.InputUserText).Subscribe(x =>
            {
                if (InputUserText.ToLower() == Text.ToLower())
                {
                    IsVerified = true;
                    MessageBoxManager.GetMessageBoxStandard("message", "Is verified !!").ShowAsync();
                }
                else
                {
                    IsVerified = false;
                }
            });
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
