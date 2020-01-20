
using System;
using System.Globalization;
using System.Windows.Media;

namespace Beata.Medrek
{
    /// <summary>
    /// converts an enum of Warning Mode
    /// to Colors
    /// </summary>
    public class WarningModeToColorConverter : BaseValueConverter<WarningModeToColorConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
                switch ((WarningMode)value)
                {
                    case (WarningMode.Red):
                    return Colors.Red;

                    case (WarningMode.Green):
                    return Colors.DarkGreen;

                default:
                    return Colors.Black ;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
