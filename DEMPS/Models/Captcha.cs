using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DEMPS.Models
{
    public class Captcha
    {
        /*
                Не забыть запихать всё в Grid, так будет лучше, хотя можно и Canvas....
        */

        public Captcha(int length)
        {
            int abcLength = ABCEnglishAndNumbersForCaptcha.Length;
            for (int i = 0; i < length; i++)
            {
                _text += ABCEnglishAndNumbersForCaptcha[rnd.Next(0, abcLength)];
            }
        }
        private IEnumerable<TextBlock> CreateCaptcha(string text)
        {
            List<TextBlock> textForCaptcha = new List<TextBlock>();


            foreach(var letter in  text)
            {
                TextBlock oneLetterFromText = new TextBlock();
                
                oneLetterFromText.Text = letter.ToString();
                //oneLetterFromText.Foreground = ;
                //oneLetterFromText.FontSize = 
                //oneLetterFromText.Margin = new Thickness();
            }

            return textForCaptcha;
        }

        private Random rnd = new Random();
        private string ABCEnglishAndNumbersForCaptcha = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private string _text = "";
        private Bitmap _image;
        public string Text { get => _text; }
        public Bitmap Image { get => _image; }

        /// <summary>
        /// отступ между буквами, для разнообразия
        /// </summary>
        /// <returns></returns>
        private Thickness RandomTextMargin()
        {
            return new Thickness()
            {

            };
        }
        /// <summary>
        /// размер текста
        /// </summary>
        /// <param name="minFontSize">минимальный размер текста</param>
        /// <param name="maxFontSize">максимальный размер текста</param>
        /// <returns></returns>
        private double RandowFontSize(double minFontSize = 5, double maxFontSize = 15)
        {
            return rnd.Next(
                Convert.ToInt32(Math.Round(minFontSize)),
                Convert.ToInt32(Math.Round(maxFontSize)));
        }
        /// <summary>
        /// цвет текста/буквы
        /// </summary>
        /// <returns></returns>
        private IBrush RandomTextColor()
        {
            var colors = new List<IBrush>()
            {
                new SolidColorBrush(Color.FromRgb(102,100,50))
            };
            return colors[rnd.Next(0, colors.Count)];
        }
    }
}
