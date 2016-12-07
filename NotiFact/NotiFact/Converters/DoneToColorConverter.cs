using NotiFact.Models;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace NotiFact.Converters
{
    class DoneToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.GetType() != typeof(bool))
                return null;
            var isDone = (bool)value;
            return isDone ? Color.Gray : Color.Green;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
