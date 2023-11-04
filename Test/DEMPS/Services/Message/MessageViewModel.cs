using Avalonia.Media.Imaging;
using ReactiveUI.Fody.Helpers;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Test.ViewModels;

namespace Test.DEMPS.Services.Message
{
    public class MessageViewModel:ViewModelBase
    {
        public MessageViewModel(string text)
        {
            Text = text;
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
                Message.DialogResult = DialogResult.OK;
            });
            Cancel = ReactiveCommand.Create(() =>
            {
                Message.DialogResult = DialogResult.Cancel;
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
