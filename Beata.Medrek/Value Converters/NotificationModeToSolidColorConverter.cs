
using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Media;

namespace Beata.Medrek
{
    /// <summary>
    /// Application page converts an enum of pages
    /// to an instance of a page class
    /// </summary>
    public class NotificationModeToSolidColorConverter : BaseValueConverter<NotificationModeToSolidColorConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
                switch ((NotificationMode)value)
                {
                    case (NotificationMode.error):
                    return new SolidColorBrush() { Color=Colors.Red};
                    case (NotificationMode.success):
                    return new SolidColorBrush() { Color = Colors.Green };

                default:
                    return new SolidColorBrush() { Color = Colors.Black };

            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
