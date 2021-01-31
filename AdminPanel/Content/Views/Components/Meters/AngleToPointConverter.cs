using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;

namespace AdminPanel.Content.Views.Components.Meters
{
    class AngleToPointConverter : IValueConverter 
    {
        public object Convert(object value, Type targetType, object param, System.Globalization.CultureInfo culture)
        {
            double angle = (double)value;
            double radius = 50;
            double piang = angle * Math.PI / 180;

            double px = Math.Sin(piang) * radius + radius;
            double py = -Math.Cos(piang) * radius + radius;
            return new Point(px, py);
        }

        public object ConvertBack(object value, Type targetType, object param, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
