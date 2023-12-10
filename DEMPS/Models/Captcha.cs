﻿using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DEMPS.Models
{
    public class Captcha:ReactiveObject
    {
        /*
                Не забыть запихать всё в Grid, так будет лучше, хотя можно и Canvas....
                
                а не, чистый Canvas смотрится плохо
                лучше его сделать "вспомогательным", расшириф на весь грид, для рисования "помех" и прочего
                а в столбца грида буквы: 1 столбец = 1 буква
        */

        public Captcha(int length)
        {
            int abcLength = englishABCAndNumbersForCaptcha.Length;
            for (int i = 0; i < length; i++)
            {
                _text += englishABCAndNumbersForCaptcha[rnd.Next(0, abcLength)];
            }
            Image = CreateCaptcha(_text);
            CreateInterference(3, 100,100);
        }
        private Grid CreateCaptcha(string text)//тут будет возврат Canvas
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
            Grid gridForCaptcha = new Grid();


            int numberColumn = 0;
            foreach (var item in textForCaptcha)
            {
                gridForCaptcha.ColumnDefinitions.Add(new ColumnDefinition()); //добавляем новый столбец для буквы

                gridForCaptcha.Children.Add(item);  //добавляем буква в грид
                Grid.SetColumn(item, numberColumn); //закидываем букву в последний столбец

                numberColumn++;
            }
            return gridForCaptcha;
        }

        private void CreateInterference(int interferencesMultiplier, int width, int height)
        {
            Canvas canvas = new Canvas();

            canvas.Width = Image.Width;
            canvas.Height = Image.Height;

            int imageWidth = width;
            int imageHeight = height;

            int rand = rnd.Next(5 * interferencesMultiplier, 10 * interferencesMultiplier);

            for (int i = 0; i < 100; i++)
            {
                Line line = new Line()
                {
                    StartPoint = new Point(
                        rnd.Next(0, imageWidth),
                        rnd.Next(0, imageHeight)
                        ),

                    EndPoint = new Point(
                        rnd.Next(0, imageWidth),
                        rnd.Next(0, imageHeight)
                        ),
                    StrokeThickness = rnd.Next(2, 5),
                    Stroke = Brushes.White
                };
                canvas.Children.Add(line);
            }

            Image.Children.Add(canvas);
            Grid.SetColumnSpan(canvas, Image.ColumnDefinitions.Count);
        }



        #region Свойства

        public string Text { get => _text; }
        public Grid Image { get; }//ну да

        #endregion
        #region Поля

        private string _text = "";

        private Random rnd = new Random();
        /// <summary>
        /// позже надо бы разделить на части: алфавит/числа
        /// </summary>
        private const string englishABCAndNumbersForCaptcha = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        #endregion



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
