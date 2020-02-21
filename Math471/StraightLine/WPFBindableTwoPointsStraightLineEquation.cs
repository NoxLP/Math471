using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Math471.StraightLine
{
    public class WPFBindableTwoPointsStraightLineEquation : DependencyObject, IStraightLineEquation
    {
        public Point P0
        {
            get { return (Point)GetValue(P0Property); }
            set { SetValue(P0Property, value); }
        }
        public static readonly DependencyProperty P0Property =
            DependencyProperty.Register("P0", typeof(Point), typeof(WPFBindableTwoPointsStraightLineEquation), new PropertyMetadata(default(Point), P0PropertyChanged));
        private static void P0PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((WPFBindableTwoPointsStraightLineEquation)d).PointChanged();
        }

        public Point P1
        {
            get { return (Point)GetValue(P1Property); }
            set { SetValue(P1Property, value); }
        }
        public static readonly DependencyProperty P1Property =
            DependencyProperty.Register("P1", typeof(Point), typeof(WPFBindableTwoPointsStraightLineEquation), new PropertyMetadata(default(Point), P1PropertyChanged));
        private static void P1PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((WPFBindableTwoPointsStraightLineEquation)d).PointChanged();
        }
        private void PointChanged()
        {
            CalculaParaPasarPor2Puntos();
        }

        public double Slope { get; private set; }

        private void CalculaParaPasarPor2Puntos()
        {
            Slope = (P1.Y - P0.Y) / (P1.X - P0.X);
        }
        public double YValueForX(double x)
        {
            return (Slope * (x - P0.X)) + P0.Y;
        }
        public double XValueForY(double y)
        {
            return (y - P0.Y + (Slope * P0.X)) / Slope;
        }
        public Point GetPointAlongLineAtDistanceFrom(Point point, double distance)
        {
            var vector = (P1 - P0);
            vector.Normalize();
            vector *= distance;
            return new Point(vector.X + point.X, vector.Y + point.Y);
        }
    }
}
