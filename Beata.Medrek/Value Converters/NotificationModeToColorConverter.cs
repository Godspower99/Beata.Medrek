
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
    public class NotificationModeToColorConverter : BaseValueConverter<NotificationModeToColorConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
                         switch ((NotificationMode)value)
                         {
                    case (NotificationMode.error):
                        return Colors.Red;
                    case (NotificationMode.success):
                        return Colors.Green;
                    default:
                        return Colors.Black;
                }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
