using NotiFact.Models;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace NotiFact.Converters
{
    class TypeToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.GetType() != typeof(NotificationType))
                return null;
            var type = (NotificationType)value;
            switch (type)
            {
                case NotificationType.Maintenance:
                    return "maintenance.png";                   
                case NotificationType.Security:
                    return "security.png";
                default:
                    return "appicon.png";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
