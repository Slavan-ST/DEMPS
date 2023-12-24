using Avalonia.Controls.Metadata;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Data;
using ReactiveUI.Fody.Helpers;
using System.Windows.Input;
using ReactiveUI;
using DEMPS.Models;
using System.Diagnostics;

namespace AvaloniaApplicationTest.TestControls
{
    [TemplatePart("CaptchaPresenter", typeof(ItemsControl))] //так мы можем найти наш контрол по имени
    public class Captcha : TemplatedControl
    {
        CaptchaModel? captchaModel;
        string text = string.Empty;

        void InitializeCaptcha()
        {
            captchaModel = new DEMPS.Models.CaptchaModel(5, WidthImage, HeightImage);
            text = captchaModel.Text;
            Image = captchaModel.Image;
            InputUserText = "";
        }
        public Captcha()
        {
            InitializeCaptcha();
            Refresh = ReactiveCommand.Create(() =>
            {
                Debug.WriteLine(InputUserText);
                InitializeCaptcha();
            });
        }


        public ICommand Refresh
        {
            get { return GetValue(RefreshProperty); }
            set { SetValue(RefreshProperty, value); }
        }
        public static StyledProperty<ICommand> RefreshProperty =
            AvaloniaProperty.Register<Captcha, ICommand>(
                nameof(Refresh)
                );

        public double WidthImage
        {
            get { return GetValue(WidthImageProperty); }
            set { SetValue(WidthImageProperty, value); }
        }
        public static StyledProperty<double> WidthImageProperty =
            AvaloniaProperty.Register<Captcha, double>(
                nameof(WidthImage),
                defaultValue:200
                );
        public double HeightImage
        {
            get { return GetValue(HeightImageProperty); }
            set { SetValue(HeightImageProperty, value); }
        }
        public static StyledProperty<double> HeightImageProperty =
            AvaloniaProperty.Register<Captcha, double>(
                nameof(HeightImage),
                defaultValue: 200
                );
        public string InputUserText
        {
            get { return GetValue(InputUserTextProperty); }
            set { SetValue(InputUserTextProperty, value); }
        }
        public static StyledProperty<string> InputUserTextProperty =
            AvaloniaProperty.Register<Captcha, string>(
                nameof(InputUserText),
                defaultBindingMode: BindingMode.TwoWay,
                defaultValue:""




                );

        public bool IsVerified
        {
            get { return GetValue(IsVerifiedProperty); }
            set { SetValue(IsVerifiedProperty, value); }
        }
        public static StyledProperty<bool> IsVerifiedProperty =
            AvaloniaProperty.Register<Captcha, bool>(
                nameof(IsVerified),
                defaultValue: false
                );

        public Grid? Image
        {
            get { return GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }
        public static StyledProperty<Grid?> ImageProperty =
            AvaloniaProperty.Register<Captcha, Grid?>(
                nameof(Image)                          //имя свойства
                );






        #region переопределение некоторых базовых функций
        // Мы переопределяем OnPropertyChanged базового класса. Таким образом, мы можем реагировать на изменения свойств
        protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
        {
            base.OnPropertyChanged(change);
            if (change.Property == InputUserTextProperty)
            {
                IsVerified = InputUserText.ToLower() == text.ToLower();//t == InputUserText
                Debug.WriteLine("it's work   " + IsVerified);
            }
        }

        // Мы переопределяем то, что происходит при применении шаблона элемента управления.
        // Таким образом, мы можем, например, прослушивать события элементов управления, которые являются частью шаблона
        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);
        }

        //Вызывается для обновления состояния проверки свойств, для которых включена проверка данных
        protected override void UpdateDataValidation(AvaloniaProperty property, BindingValueType state, Exception? error)
        {
            base.UpdateDataValidation(property, state, error);
        }
        #endregion
    }
}
