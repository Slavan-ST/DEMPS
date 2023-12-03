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
            TheEventProperty.Changed.Subscribe(OnEventChanged);
        }


        public static RoutedEvent GetTheEvent(Control obj)
        {
            return obj.GetValue(TheEventProperty);
        }

        public static void SetTheEvent(Control obj, RoutedEvent value)
        {
            obj.SetValue(TheEventProperty, value);
        }

        public static readonly AttachedProperty<RoutedEvent> TheEventProperty =
            AvaloniaProperty.RegisterAttached<BehaviorForCaptcha, Control, RoutedEvent>
            (
                "TheEvent"
            );


        public static object GetTargetObject(Control obj)
        {
            return obj.GetValue(TargetObjectProperty);
        }

        public static void SetTargetObject(Control obj, object value)
        {
            obj.SetValue(TargetObjectProperty, value);
        }

        public static readonly AttachedProperty<object> TargetObjectProperty =
            AvaloniaProperty.RegisterAttached<BehaviorForCaptcha, Control, object>
            (
                "TargetObject"
            );



        public static string GetMethodToCall(Control obj)
        {
            return obj.GetValue(MethodToCallProperty);
        }

        public static void SetMethodToCall(Control obj, string value)
        {
            obj.SetValue(MethodToCallProperty, value);
        }

        public static readonly AttachedProperty<string> MethodToCallProperty =
            AvaloniaProperty.RegisterAttached<BehaviorForCaptcha, Control, string>
            (
                "MethodToCall"
            );




        private static void OnEventChanged(AvaloniaPropertyChangedEventArgs<RoutedEvent> args)
        {
            Control el = (Control)args.Sender;

            RoutedEvent? oldRoutedEvent = args.OldValue.Value as RoutedEvent;

            if (oldRoutedEvent != null)
            {
                // remove old event handler from the object (if exists)
                el.RemoveHandler(oldRoutedEvent, (EventHandler<RoutedEventArgs>)HandleRoutedEvent!);
            }


            RoutedEvent newRoutedEvent = args.NewValue.Value as RoutedEvent;

            if (newRoutedEvent != null)
            {
                // add new event handler to the object
                el.AddHandler(newRoutedEvent, (EventHandler<RoutedEventArgs>)HandleRoutedEvent!);
            }
        }

        // handle the routed event when happens on the object
        // by calling the method of name 'methodName' onf the
        // TargetObject
        private static void HandleRoutedEvent(object sender, RoutedEventArgs e)
        {
            Control el = (Control)sender;

            // if TargetObject is not set, use DataContext as the target object
            object? targetObject = GetTargetObject(el) ?? el.DataContext;

            string? methodName = GetMethodToCall(el);

            // do not do anything
            if (targetObject == null || methodName == null)
            {
                return;
            }

            MethodInfo? methodInfo =
                targetObject.GetType().GetMethod(methodName);

            if (methodInfo == null)
            {
                return;
            }

            // call the method using reflection
            methodInfo.Invoke(targetObject, null);
        }
    }
}
