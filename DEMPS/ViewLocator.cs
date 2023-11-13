﻿using Avalonia.Controls.Templates;
using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEMPS.ViewModels;
using ReactiveUI;
using System.Diagnostics;

namespace DEMPS
{
    public class ViewLocator : IDataTemplate
    {
        public Control? Build(object? data)
        {
            var name = data!.GetType().FullName!.Replace("ViewModel", "View");
            Debug.WriteLine("assembly: ============= " + data.GetType().Assembly);
            var type = Type.GetType(name);

            if (type != null)
            {
                return (Control)Activator.CreateInstance(type)!;
            }
            else
            {
                return new TextBlock { Text = "Not Found: " + name };
            }
        }

        public bool Match(object? data)
        {
            return data is ReactiveObject;
        }
    }
}
