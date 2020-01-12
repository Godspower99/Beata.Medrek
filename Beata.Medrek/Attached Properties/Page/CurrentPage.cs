
using Beata.Medrek.Core;
using System.Windows;
using System.Windows.Controls;

namespace Beata.Medrek
{
    ///<Summary>
    /// Current Page Attached Property
    ///<Summary>
    public class CurrentPage
    {

        public static ApplicationPage GetValue(DependencyObject obj)
        {
            return (ApplicationPage)obj.GetValue(ValueProperty);
        }

        public static void SetValue(DependencyObject obj, ApplicationPage value)
        {
            obj.SetValue(ValueProperty, value);
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.RegisterAttached("Value", typeof(ApplicationPage), 
                typeof(CurrentPage), 
                new PropertyMetadata(ApplicationPage.Login,null,new CoerceValueCallback(OnValueUpdated)));

        private static object OnValueUpdated(DependencyObject d, object baseValue)
        {
            var frame = (d as Frame);
            frame.Content = ApplicationPageDataContextConverter.Convert((ApplicationPage)baseValue,IoC.ApplicationViewModel.CurrentPageViewModel);
            return null;
        }
    }
}
