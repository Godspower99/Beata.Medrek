using System;
using System.Globalization;
using System.Windows;

namespace Beata.Medrek
{
    /// <summary>
    /// Value converter for window maximize button icon
    /// </summary>
    public class MaximizeButtonImageValueConverter : BaseValueConverter<MaximizeButtonImageValueConverter>
    {
        public static MaximizeButtonImageValueConverter Instance = new MaximizeButtonImageValueConverter();
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? "\uf2d2" : "\uf2d0";
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
