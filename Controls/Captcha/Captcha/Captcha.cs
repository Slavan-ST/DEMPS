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
using System.Windows.Input;
using ReactiveUI;
using Captcha.Models;
using System.Diagnostics;
using Avalonia.Markup.Xaml.Styling;

namespace Captcha
{
    [TemplatePart("CaptchaPresenter", typeof(ItemsControl))] //так мы можем найти контрол по имени
    public class Captcha : TemplatedControl
    {
        #region Поля
        CaptchaModel? _captchaModel;
        string _text = string.Empty;
        #endregion

        #region Конструктор

        static Captcha()
        {
            //добавляем стиль капчи в ресурсы приложения
            Application.Current?.Resources.MergedDictionaries
                .Add(new ResourceInclude(new Uri("avares://Captcha/Themes/CaptchaStyles.axaml"))
                {
                    Source = new Uri("avares://Captcha/Themes/CaptchaStyles.axaml")
                });

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

        void InitializeCaptcha()
        {
            //устанавливаем стартовые значения свойств и полей
            _captchaModel = new CaptchaModel(5, WidthImage, HeightImage);
            _text = _captchaModel.Text;
            Image = _captchaModel.Image;
            InputUserText = "";
        }
        #endregion

        #region Свойства
        public static StyledProperty<Grid?> ImageProperty = AvaloniaProperty.Register<Captcha, Grid?>(nameof(Image));
        public static StyledProperty<ICommand> RefreshProperty = AvaloniaProperty.Register<Captcha, ICommand>(nameof(Refresh));
        public static StyledProperty<double> WidthImageProperty = AvaloniaProperty.Register<Captcha, double>(nameof(WidthImage), defaultValue: 200);
        public static StyledProperty<double> HeightImageProperty = AvaloniaProperty.Register<Captcha, double>(nameof(HeightImage), defaultValue: 200);
        public static StyledProperty<bool> IsVerifiedProperty = AvaloniaProperty.Register<Captcha, bool>(nameof(IsVerified), defaultValue: false);
        public static StyledProperty<string> InputUserTextProperty = AvaloniaProperty.Register<Captcha, string>(nameof(InputUserText), defaultBindingMode: BindingMode.TwoWay, defaultValue: "");
        /// <summary>
        /// Ширина рисунка капчи
        /// </summary>
        public double WidthImage
        {
            get { return GetValue(WidthImageProperty); }
            set { SetValue(WidthImageProperty, value); }
        }
        /// <summary>
        /// Высота рисунка капчи
        /// </summary>
        public double HeightImage
        {
            get { return GetValue(HeightImageProperty); }
            set { SetValue(HeightImageProperty, value); }
        }
        /// <summary>
        /// Текст введенный пользователем, необходим для проверки прохождения капчи
        /// </summary>
        public string InputUserText
        {
            get { return GetValue(InputUserTextProperty); }
            set { SetValue(InputUserTextProperty, value); }
        }
        /// <summary>
        /// Пройдена капча или нет, true - да, false - нет 
        /// </summary>
        public bool IsVerified
        {
            get { return GetValue(IsVerifiedProperty); }
            set { SetValue(IsVerifiedProperty, value); }
        }
        /// <summary>
        /// Картинка капчи, представленна гридом для лучшей масштабируемости
        /// </summary>
        public Grid? Image
        {
            get { return GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }
        /// <summary>
        /// команда обновления капчи
        /// </summary>
        public ICommand Refresh
        {
            get { return GetValue(RefreshProperty); }
            set { SetValue(RefreshProperty, value); }
        }


        #endregion

        #region переопределение некоторых базовых функций
        // Мы переопределяем OnPropertyChanged базового класса. Таким образом, мы можем реагировать на изменения свойств
        protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
        {
            base.OnPropertyChanged(change);
            //если измененное свойство - текст введенный пользователем, то проверяем прошёл ли пользователь капчи
            if (change.Property == InputUserTextProperty)
            {
                IsVerified = InputUserText.ToLower() == _text.ToLower();//t == InputUserText
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
