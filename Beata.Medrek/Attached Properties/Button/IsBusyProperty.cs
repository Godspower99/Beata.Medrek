
using System.Windows;

namespace Beata.Medrek
{
    /// <summary>
    /// A flag attached property,
    /// sets to true if the dependency object <Button> is running a task
   /// </summary>
   public class IsBusyAttachedProperty
    {

      
        public static bool GetIsBusy(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsBusyProperty);
        }

      
        public static void SetIsBusy(DependencyObject obj, bool value)
        {
            obj.SetValue(IsBusyProperty, value);
        }

        // Using a DependencyProperty as the backing store for IsBusy.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsBusyProperty =
            DependencyProperty.RegisterAttached("IsBusy", typeof(bool), typeof(IsBusyAttachedProperty), new PropertyMetadata(false));


    }
}
