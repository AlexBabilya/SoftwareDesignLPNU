using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace WPF.Converters
{
    public class DateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTimeOffset dateTimeOffset)
            {
                // Assuming you want to format the DateTimeOffset as a short date string
                return dateTimeOffset.ToString("d", culture);
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string dateString)
            {
                if (DateTimeOffset.TryParse(dateString, culture, DateTimeStyles.None, out DateTimeOffset result))
                {
                    return result;
                }
            }

            return null;
        }
    }
}
