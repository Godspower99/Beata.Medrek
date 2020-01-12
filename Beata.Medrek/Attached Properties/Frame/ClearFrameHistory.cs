using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Beata.Medrek
{
    ///<Summary>
    /// Clear Frame Contetent History
    /// To Disable Navigation by Frame NavigationService
    ///<Summary>
    public class ClearFrameHistory
    {

        /// <summary>
        /// Get ClearFrameHistory 
        /// Property Value Method
        /// </summary>
        /// <param name="obj">
        /// Usually of Type <see cref="Frame"/>
        /// </param>
        /// <returns></returns>
        public static bool GetValue(DependencyObject obj)
        {
            return (bool)obj.GetValue(ValueProperty);
        }

        /// <summary>
        /// Set ClearFrameHistory
        /// Property Value Method
        /// </summary>
        /// <param name="obj">
        /// Ususally of Type <see cref="Frame"/>
        /// </param>
        /// <returns></returns>
        public static void SetValue(DependencyObject obj, bool value)
        {
            obj.SetValue(ValueProperty, value);
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.RegisterAttached("Value", typeof(bool),
                typeof(ClearFrameHistory), new PropertyMetadata(false,OnValueChanged));


        /// <summary>
        /// <see cref="ClearFrameHistory"/> property Value Changed Event Handler
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // Set DependencyObject Sender as Frame
            var frame = (d as Frame);

            // Set frame Navigated Event Handler
            frame.Navigated += Frame_Navigated;
        }

        /// <summary>
        /// Frame Navigated Event Handler 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Frame_Navigated(object sender, NavigationEventArgs e)
        {
            var frame = (sender as Frame);

            // Delete all content history from frame
            frame.NavigationService.RemoveBackEntry();
        }
    }
}
