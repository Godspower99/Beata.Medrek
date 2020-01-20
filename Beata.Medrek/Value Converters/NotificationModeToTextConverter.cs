
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
    public class NotificationModeToTextConverter : BaseValueConverter<NotificationModeToTextConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
                switch ((NotificationMode)value)
                {
                    case (NotificationMode.error):
                    return "\uf071";
                    case (NotificationMode.success):
                        return "\uf00c";
                    default:
                    return "\uf12a";
                }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
