using NotiFact.Models;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace NotiFact.Converters
{
    class ReadToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.GetType() != typeof(bool))
                return null;
            var isRead = (bool)value;
            var color = App.Current.Resources.ContainsKey("BlueMichelin") ? (Color) App.Current.Resources["BlueMichelin"] : Color.Blue;
            return isRead ? Color.Gray : color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
