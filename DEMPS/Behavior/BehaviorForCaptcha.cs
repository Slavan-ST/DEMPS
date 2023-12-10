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
        //InputUserText..... хотяя, нее.. пока пользователю это не надо, но всё же оставлю определенные "наработки"


        //ммм, статика.... вот это - вызывается 1 раз,
        //при первом использовании объекта это класса
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




        #region 10.12.2023 - пока что, данные свойства не используются! В них просто нет необходимости
        public static object GetImageCaptcha(Control obj)
        {
            return obj.GetValue(ImageCaptchaProperty);
        }

        public static void SetImageCaptcha(Control obj, object value)
        {
            obj.SetValue(ImageCaptchaProperty, value);
        }

        public static readonly AttachedProperty<object> ImageCaptchaProperty =
            AvaloniaProperty.RegisterAttached<BehaviorForCaptcha, Control, object>
            (
                "ImageCaptcha"
            );


        public static object GetText(Control obj)
        {
            return obj.GetValue(TextProperty);
        }

        public static void SetText(Control obj, object value)
        {
            obj.SetValue(TextProperty, value);
        }

        public static readonly AttachedProperty<object> TextProperty =
            AvaloniaProperty.RegisterAttached<BehaviorForCaptcha, Control, object>
            (
                "Text"
            );

        #endregion



        //надо будет разобраться, что это и где это можно использовать
        // handle the routed event when happens on the object
        // by calling the method of name 'methodName' onf the
        // TargetObject
        
        //rus. . 
        //Обработать маршрутизируемое событие, когда оно происходит с объектом
        //путем вызова метода "название метода" у целевого объекта        //а, это же урезал..
        private static void HandleRoutedEvent(object sender, RoutedEventArgs e)
        {
            Control el = (Control)sender;

            // if TargetObject is not set, use DataContext as the target object
            object? targetObject = GetIsVerified(el) ?? el.DataContext;

        }
    }
}
