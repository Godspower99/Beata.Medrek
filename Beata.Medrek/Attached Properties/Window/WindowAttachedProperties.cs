using System;
using System.Windows;
namespace Beata.Medrek
{
   public class WindowAttachedProperties
    {

        /// <summary>
        /// Get WindowMaximized Property Value
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool GetWindowMaximized(DependencyObject obj)
        {
            return (bool)obj.GetValue(WindowMaximizedProperty);
        }

        /// <summary>
        /// Set WindowMaximized Property Value
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetWindowMaximized(DependencyObject obj, bool value)
        {
            obj.SetValue(WindowMaximizedProperty, value);
        }

        // Using a DependencyProperty as the backing store for WindowMaximized.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WindowMaximizedProperty =
            DependencyProperty.RegisterAttached("WindowMaximized", typeof(bool), typeof(WindowAttachedProperties), new PropertyMetadata(false));

        
    }
}
