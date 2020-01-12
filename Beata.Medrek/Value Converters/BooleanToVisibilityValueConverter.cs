
using System;
using System.Globalization;
using System.Windows;

namespace Beata.Medrek
{
    /// <summary>
    /// Returns Visibility.Hidden if the Parameter is Null and Value is True
    /// else Visibility.Visible if the parameter is not null and Value is True
    /// </summary>
    public class BooleanToVisibilityValueConverter : BaseValueConverter<BooleanToVisibilityValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null)
                return (bool)value? Visibility.Hidden : Visibility.Visible;

                return (bool)value ? Visibility.Visible : Visibility.Hidden;

        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
