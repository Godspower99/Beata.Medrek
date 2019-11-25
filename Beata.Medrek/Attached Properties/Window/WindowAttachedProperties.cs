
using System;
using System.Windows;

namespace Beata.Medrek
{
   public class WindowAttachedProperties
    {

        #region MonitorWindowState Property
    
        public static bool GetMonitorWindowState(Window element)
        {
            return (bool)element.GetValue(MonitorWindowStateProperty);
        }

        public static void SetMonitorWindowState(Window element, bool value)
        {
           element.SetValue(MonitorWindowStateProperty, value);
        }

        // Using a DependencyProperty as the backing store for MonitorWindowState.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MonitorWindowStateProperty =
            DependencyProperty.RegisterAttached("MonitorWindowState", typeof(bool), typeof(WindowAttachedProperties), new PropertyMetadata(false,OnMonitorWindowState));

        private static void OnMonitorWindowState(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var window = (d as Window);
            if (window == null)
                return;

            window.StateChanged -= Window_StateChanged;


            if ((bool)e.NewValue)
            {
                SetIsMaximized(window);
                window.StateChanged += Window_StateChanged;
            }

        }


        private static void Window_StateChanged(object sender, EventArgs e)
        {
            SetIsMaximized((Window)sender);
        }

        #endregion





        #region MaximizeProperty
        public static bool GetIsMaximized(Window element)
        {
            return (bool)element.GetValue(IsMaximizedProperty);
        }

        private static void SetIsMaximized(Window element)
        {
            element.SetValue(IsMaximizedProperty, element.WindowState==WindowState.Maximized);
        }

        // Using a DependencyProperty as the backing store for IsMaximized.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsMaximizedProperty =
            DependencyProperty.RegisterAttached("IsMaximized", typeof(bool), typeof(WindowAttachedProperties), new PropertyMetadata(false));

        #endregion
    }
}
