using System;
using System.Windows;
using System.Windows.Controls;

namespace Beata.Medrek
{
   public class PasswordBoxAttachedProperties
    {


        public static bool GetMonitorPassword(PasswordBox element)
        {
            return (bool)element.GetValue(MonitorPasswordProperty);
        }

        public static void SetMonitorPassword(PasswordBox element, bool value)
        {
            element.SetValue(MonitorPasswordProperty, value);
        }

        // Using a DependencyProperty as the backing store for MonitorPassword.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MonitorPasswordProperty =
            DependencyProperty.RegisterAttached("MonitorPassword", typeof(bool), typeof(PasswordBoxAttachedProperties), new PropertyMetadata(false,OnMonitorPassWord));

        private static void OnMonitorPassWord(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var passwordbox = (d as PasswordBox);
            if (passwordbox == null)
                return;

            passwordbox.PasswordChanged -= Passwordbox_PasswordChanged;

            if ((bool)e.NewValue)
            {
                SetHasText(passwordbox);

                passwordbox.PasswordChanged += Passwordbox_PasswordChanged;
            }

        }



        private static void Passwordbox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            SetHasText((PasswordBox)sender);
        }

        public static  bool GetHasText(PasswordBox element)
        {
            return (bool)element.GetValue(HasTextProperty);
        }

        private static void SetHasText(PasswordBox element)
        {
            element.SetValue(HasTextProperty, element.SecurePassword.Length > 0);
        }

        // Using a DependencyProperty as the backing store for HasText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HasTextProperty =
            DependencyProperty.RegisterAttached("HasText", typeof( bool), typeof(PasswordBoxAttachedProperties), new PropertyMetadata(false));


    }
}
