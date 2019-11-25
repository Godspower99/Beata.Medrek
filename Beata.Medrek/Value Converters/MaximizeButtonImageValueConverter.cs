using System;
using System.Globalization;
using System.Windows;

namespace Beata.Medrek
{
    public class MaximizeButtonImageValueConverter : BaseValueConverter<MaximizeButtonImageValueConverter>
    {
        public static MaximizeButtonImageValueConverter Instance = new MaximizeButtonImageValueConverter();
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Application.Current.MainWindow.WindowState == WindowState.Maximized ? "&#xf2d0" : "&#xf2d2";
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
