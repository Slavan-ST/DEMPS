using Avalonia.Controls;
using AvaloniaApplicationTestDEMPS.ViewModels;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplicationTestDEMPS.TestServices
{
    public static class Navigation
    {
        #region Страницы для переходов/при необходимости добавить

        public static UserControl Avtoriz { get; set; } = new UserControl();
        public static UserControl Registration { get; set; } = new UserControl();
        public static UserControl RedactionItem { get; set; } = new UserControl();
        public static UserControl AddItem { get; set; } = new UserControl();
        public static UserControl ListItems { get; set; } = new UserControl();

        #endregion

        /// <summary>
        /// Модель в которой будет наодиться контент
        /// </summary>
        public static ViewModelBase MainViewModel { get; set; } = new ViewModelBase();

        /// <summary>
        /// Переход на указаную страницу
        /// </summary>
        /// <param name="page"></param>
        public static void Go(UserControl page)
        {

        }
    }
    public class NavigationPageViewModel:ViewModelBase
    {
        [Reactive]
        public ViewModelBase Page { get; set; }
    }
}
