using Avalonia.Controls;
using MsBox.Avalonia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEMPS.Services
{
    public class MessageBox
    {
        /// <summary>
        /// просто вывыд сообщения с определенным текстом
        /// </summary>
        /// <param name="title"></param>
        /// <param name="text"></param>
        public static void Show(string title, string text)
        {
            //создаём бокс
            var message = MessageBoxManager.GetMessageBoxStandard(title, text);
            //выводим бокс
            message.ShowAsPopupAsync(Temp.CurrentControl);
        }
    }
}
