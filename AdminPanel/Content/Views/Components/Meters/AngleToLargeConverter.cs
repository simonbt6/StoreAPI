using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;

namespace AdminPanel.Content.Views.Components.Meters
{
    class AngleToLargeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object param, System.Globalization.CultureInfo culture)
        {
            double angle = (double)value;

            return angle > 180;
        }

        public object ConvertBack(object value, Type targetType, object param, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
