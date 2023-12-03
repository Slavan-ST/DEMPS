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
            int abcLength = englishABCAndNumbersForCaptcha.Length;
            for (int i = 0; i < length; i++)
            {
                _text += englishABCAndNumbersForCaptcha[rnd.Next(0, abcLength)];
            }
            Image = CreateCaptcha(_text);
        }
        private Canvas CreateCaptcha(string text)//тут будет возврат Canvas
        {
            List<TextBlock> textForCaptcha = new List<TextBlock>();


            foreach(var letter in  text)
            {
                TextBlock letterTextBlock = new TextBlock();
                
                letterTextBlock.Text = letter.ToString();
                letterTextBlock.Margin = RandomTextMargin(3,8);//min ,max
                letterTextBlock.FontSize = RandowFontSize(3,15);//min,max
                //oneLetterFromText.Foreground = ;
                //oneLetterFromText.FontSize = 

                textForCaptcha.Add(letterTextBlock);
            }
            Canvas canvasForCaptcha = new Canvas();
            foreach(var item in textForCaptcha)
            {
                item.Margin = new Thickness(
                    item.Margin.Left, 
                    item.Margin.Top,
                    item.Margin.Right + 10, 
                    item.Margin.Bottom);

                canvasForCaptcha.Children.Add(item);
            }

            return canvasForCaptcha;
        }

        private Random rnd = new Random();
        /// <summary>
        /// позже надо бы разделить на части: алфавит/числа
        /// </summary>
        private const string englishABCAndNumbersForCaptcha = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private string _text = "";
        public string Text { get => _text; }
        public Canvas Image { get; }//ну да

        /// <summary>
        /// отступ между сторонами, вычисляется к каждой стороне отдельно, от минимального до максимального
        /// </summary>
        /// <param name="marginMin">минимальный отступ</param>
        /// <param name="marginMax">максимальный отступ</param>
        /// <returns></returns>
        private Thickness RandomTextMargin(double marginMin, double marginMax)
        {
            return new Thickness(
                rnd.Next(Convert.ToInt32(Math.Round(marginMin)), Convert.ToInt32(Math.Round(marginMax))), //left
                rnd.Next(Convert.ToInt32(Math.Round(marginMin)), Convert.ToInt32(Math.Round(marginMax))), //top
                rnd.Next(Convert.ToInt32(Math.Round(marginMin)), Convert.ToInt32(Math.Round(marginMax))), //right
                rnd.Next(Convert.ToInt32(Math.Round(marginMin)), Convert.ToInt32(Math.Round(marginMax)))  //bottom
                );
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
