using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Beata.Medrek
{
    /// <summary>
    /// Base Value Converter
    /// </summary>
    public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter
        where T:class,new()
    {
        /// <summary>
        /// Private static instance of value converter
        /// </summary>
        private static T _instance;

        /// <summary>
        /// Converter Method to be ovverridden when derived
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        /// <summary>
        /// ConvertBack Method to be Ovverridden when Derived
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);


        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (_instance == null)
                _instance = new T();

            return _instance;
        }

    }
}
