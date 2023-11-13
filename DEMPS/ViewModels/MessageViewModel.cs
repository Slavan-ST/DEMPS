using Avalonia.Media.Imaging;
using ReactiveUI.Fody.Helpers;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DEMPS.Services;
using DEMPS.Models;

namespace DEMPS.ViewModels
{
    public class MessageViewModel : ReactiveObject
    {
        public MessageViewModel(string text)
        {
            Text = text;
            InitializeCommand();
        }
        public MessageViewModel()
        {
            Text = "Message";
            InitializeCommand();
        }
        public MessageViewModel(string text, string title)
        {
            Text = text;
            Title = title;
            InitializeCommand();
        }
        public MessageViewModel(string text, string title, Bitmap image)
        {
            Text = text;
            Title = title;
            Image = image;
            InitializeCommand();
        }
        public MessageViewModel(string text, string title, bool isCancel, Bitmap image)
        {
            Text = text;
            Title = title;
            Image = image;
            IsCancel = isCancel;
            InitializeCommand();
        }

        void InitializeCommand()
        {
            Ok = ReactiveCommand.Create(() =>
            {
                MessageBox.DialogResult = DialogResult.OK;
                Navigation.NavigationView!.Message = null;
            });
            Cancel = ReactiveCommand.Create(() =>
            {
                MessageBox.DialogResult = DialogResult.Cancel;
                Navigation.NavigationView!.Message = null;
            });
        }

        [Reactive]
        public string Text { get; set; } = "Message";
        [Reactive]
        public string Title { get; set; } = "Message";
        [Reactive]
        public Bitmap? Image { get; set; }

        [Reactive]
        public bool IsCancel { get; set; } = false;

        public ICommand? Ok { get; set; }

        public ICommand? Cancel { get; set; }
    }
}
