
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
    public class AddTextConverter : BaseValueConverter<AddTextConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null)
                return $"{(string)value} :";
            return $"{(string)value} {(string)parameter}";
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
