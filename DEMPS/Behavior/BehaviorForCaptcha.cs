using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Interactivity;
using Avalonia.Controls;
using Avalonia;
using System.Reflection;

namespace DEMPS.Behavior
{
    public class BehaviorForCaptcha
    {
        //Image
        //IsVerified
        //Text
        //InputUserText

        
        static BehaviorForCaptcha()
        {

        }



        public static object GetIsVerified(Control obj)
        {
            return obj.GetValue(IsVerifiedProperty);
        }

        public static void SetIsVerified(Control obj, object value)
        {
            obj.SetValue(IsVerifiedProperty, value);
        }

        public static readonly AttachedProperty<object> IsVerifiedProperty =
            AvaloniaProperty.RegisterAttached<BehaviorForCaptcha, Control, object>
            (
                "IsVerified"
            );



       

        // handle the routed event when happens on the object
        // by calling the method of name 'methodName' onf the
        // TargetObject
        private static void HandleRoutedEvent(object sender, RoutedEventArgs e)
        {
            Control el = (Control)sender;

            // if TargetObject is not set, use DataContext as the target object
            object? targetObject = GetIsVerified(el) ?? el.DataContext;

        }
    }
}
