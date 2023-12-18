using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEMPS.CustomControls
{
    public class CustomCaptcha:Control
    {
        public bool IsVerified { get; set; } = false;
        public CustomCaptcha()
        {

        }
    }
}
