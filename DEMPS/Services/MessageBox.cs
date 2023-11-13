
using DEMPS.Models;
using DEMPS.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEMPS.Services
{
    public class MessageBox
    {
        string Text { get; set; }
        public MessageBox(string text)
        {
            Text = text;
        }
        public static DialogResult DialogResult { get; set; }
        public DialogResult Show()
        {
            Navigation.NavigationView!.Message = new MessageView(Text);
            return DialogResult;
        }
    }
}
