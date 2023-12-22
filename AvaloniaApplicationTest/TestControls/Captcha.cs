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

namespace AvaloniaApplicationTest.TestControls
{
    [TemplatePart("CaptchaPresenter", typeof(ItemsControl))] //так мы можем найти наш контрол по имени
    public class Captcha : TemplatedControl
    {



        // public Bitmap? Image { get; set; } // изображение капчи
        public string Text { get; set; } = string.Empty; //Текст капчи
        public bool IsVerified { get; set; } = false; // совпадает-ли текст введенный пользователем с текстом капчи
        //public double Width { get; set; } = 200;
        //public double Height { get; set; } = 200;
        private static DEMPS.Models.Captcha StartCaptcha = new DEMPS.Models.Captcha(5, 200, 200);


        public Captcha()
        {

        }

        public ICommand Refresh
        {
            get { return GetValue(RefreshProperty); }
            set { SetValue(RefreshProperty, value); }
        }
        public static StyledProperty<ICommand> RefreshProperty =
            AvaloniaProperty.Register<Captcha, ICommand>(
                nameof(Refresh),
                defaultValue: ReactiveCommand.Create(() => 
                {
                    StartCaptcha = new DEMPS.Models.Captcha(5,200,200);
                })
                );

        public string InputUserText
        {
            get { return GetValue(InputUserTextProperty); }
            set { SetValue(InputUserTextProperty, value); }
        }
        public static StyledProperty<string> InputUserTextProperty =
            AvaloniaProperty.Register<Captcha, string>(
                nameof(InputUserText),
                defaultValue: string.Empty
                );

        public Grid? Image
        {
            get { return GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }
        public static StyledProperty<Grid?> ImageProperty =
            AvaloniaProperty.Register<Captcha, Grid?>(
                nameof(Image),                          //имя свойства
                defaultValue: StartCaptcha.Image        //значение по умолчанию
                );




        //public static StyledProperty<int> NumberOfStarsProperty =
        //    AvaloniaProperty.Register<Captcha, int>(
        //        nameof(NumberOfStars),          // Sets the name of the property                                задаёт имя свойства
        //        defaultValue: 5,
        //        coerce: // The default value of this property                           значение по умолчанию
        //        );   // Ensures that we always have a valid number of stars          гарантирует, что количество звёзд всегда будет правильным
        //public int NumberOfStars
        //{
        //    get { return GetValue(NumberOfStarsProperty); }
        //    set { SetValue(NumberOfStarsProperty, value); }
        //}





        #region переопределение некоторых базовых функций
        // Мы переопределяем OnPropertyChanged базового класса. Таким образом, мы можем реагировать на изменения свойств
        protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
        {
            base.OnPropertyChanged(change);
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
