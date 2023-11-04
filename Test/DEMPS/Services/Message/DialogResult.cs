using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DEMPS.Services.Message
{
    public struct DialogResult
    {
        string Tag { get; set; }
        public static DialogResult OK { get; } = new DialogResult()
        {
            Tag = "OK"
        };
        public static DialogResult Cancel { get; } = new DialogResult()
        {
            Tag = "Cancel"
        };
    }
}
