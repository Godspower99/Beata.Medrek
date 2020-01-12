using System.Windows;
namespace Beata.Medrek
{
    ///<Summary>
    /// Window IsMaximized Flag
    ///<Summary>
    public class WindowAttachedProperties
    {


        public static bool GetWindowMaximized(DependencyObject obj)
        {
            return (bool)obj.GetValue(WindowMaximizedProperty);
        }

        public static void SetWindowMaximized(DependencyObject obj, bool value)
        {
            obj.SetValue(WindowMaximizedProperty, value);
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WindowMaximizedProperty =
            DependencyProperty.RegisterAttached("WindowMaximized", typeof(bool), typeof(WindowAttachedProperties), new PropertyMetadata(false));


    }
}
