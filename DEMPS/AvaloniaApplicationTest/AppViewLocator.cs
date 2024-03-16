using Avalonia.Controls;
using Avalonia.ReactiveUI;
using AvaloniaApplicationTest.ViewModels;
using AvaloniaApplicationTest.Views;
using Captcha.ViewModels;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplicationTest
{
    public class AppViewLocator : ReactiveUI.IViewLocator
    {
        public IViewFor? ResolveView<T>(T? viewModel, string? contract = null)
        {
            //получаем имя вьюмодели
            var viewModelName = viewModel!.GetType().FullName;

            //заменяем имя вьюмодели на имя вьюшки (включая пространство, т.е. папку)
            var viewTypeName = viewModelName!.TrimEnd("Model".ToCharArray());
            viewTypeName = viewTypeName.Replace("ViewModels","Views");

            try
            {
                var viewType = Type.GetType(viewTypeName);
                if (viewType == null)
                {
                    return null;
                }
                return Activator.CreateInstance(viewType) as IViewFor;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}
