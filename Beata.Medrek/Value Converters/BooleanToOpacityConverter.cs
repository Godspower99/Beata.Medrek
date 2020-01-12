
using System;
using System.Globalization;
using System.Windows;

namespace Beata.Medrek
{
    /// <summary>
    /// Returns 0.7 double of true is passed in 
    /// and 0.4 otherwise
    /// </summary>
    public class BooleanToOpacityConverter : BaseValueConverter<BooleanToOpacityConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? 0.7: 0.4;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
