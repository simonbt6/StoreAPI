using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace AdminPanel.Content.Views.Components.Meters
{
    public class CircularProgressbar : ProgressBar 
    {
        public CircularProgressbar()
        {
            ValueChanged += CircularProgressbar_ValueChanged;
        }

        void CircularProgressbar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            CircularProgressbar bar = sender as CircularProgressbar;
            double currentAngle = bar.Angle;
            double targetAngle = e.NewValue / bar.Maximum * 359.999;

            DoubleAnimation anim = new DoubleAnimation(currentAngle, targetAngle, TimeSpan.FromMilliseconds(500));
            bar.BeginAnimation(CircularProgressbar.AngleProperty, anim, HandoffBehavior.SnapshotAndReplace);
        }

        public double Angle
        {
           get { return (double)GetValue(AngleProperty); }
           set { SetValue(AngleProperty, value); }
        }

        public static readonly DependencyProperty AngleProperty =
            DependencyProperty.Register("Angle", typeof(double), typeof(CircularProgressbar), new PropertyMetadata(0.0));

        public double StrokeThickness
        {
            get { return (double)GetValue(StrokeThicknessProperty); }
            set { SetValue(StrokeThicknessProperty, value); }
        }

        public static readonly DependencyProperty StrokeThicknessProperty =
            DependencyProperty.Register("StrokeThickness", typeof(double), typeof(CircularProgressbar), new PropertyMetadata(10.0));
    }
}
