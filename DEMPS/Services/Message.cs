
using DEMPS.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEMPS.Services
{
    public static class Message
    {
        public static DialogResult DialogResult { get; set; }
        public static void Show(string text)
        {
            Navigation.NavigationView!.Message = new MessageView(text);
        }
    }
}
