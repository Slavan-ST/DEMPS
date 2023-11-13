﻿using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEMPS.Services;
using Avalonia.Controls;

namespace DEMPS.ViewModels
{
    public class MainNavigationPageViewModel : ReactiveObject
    {
        public MainNavigationPageViewModel()
        {
            Page = Navigation.Pages.First().Value!;
        }
        [Reactive]
        public ReactiveObject Page { get; set; }
        [Reactive]
        public UserControl? Message { get; set; }
    }
}
