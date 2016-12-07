using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NotiFact.Converters
{
    class SeverityToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.GetType() != typeof(int))
                return null;
            var severity = (int)value;
            switch (severity)
            {
                case 0:
                    return "p0.png";
                case 1:
                    return "p1.png";
                case 2:
                    return "p2.png";
                case 3:
                    return "p3.png";
                default:
                    if (severity < 0)
                        return "";
                    else
                        return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
