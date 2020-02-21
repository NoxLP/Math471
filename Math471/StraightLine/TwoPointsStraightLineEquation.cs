using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Math471.StraightLine
{
    public class TwoPointsStraightLineEquation : IStraightLineEquation
    {
        public TwoPointsStraightLineEquation(Point pasaPor2Puntos_p0, Point pasaPor2Puntos_p1)
        {
            CalculaParaPasarPor2Puntos(pasaPor2Puntos_p0, pasaPor2Puntos_p1);
        }

        private Point[] _Current2Points;

        public double Slope { get; private set; }

        private void CalculaParaPasarPor2Puntos(Point p0, Point p1)
        {
            _Current2Points = new Point[2] { p0, p1 };
            Slope = (p1.Y - p0.Y) / (p1.X - p0.X);
        }
        public double YValueForX(double x)
        {
            return (Slope * (x - _Current2Points[0].X)) + _Current2Points[0].Y;
        }
        public double XValueForY(double y)
        {
            return (y - _Current2Points[0].Y + (Slope * _Current2Points[0].X)) / Slope;
        }
        public Point GetPointAlongLineAtDistanceFrom(Point point, double distance)
        {
            var vector = (_Current2Points[1] - _Current2Points[0]);
            vector.Normalize();
            vector *= distance;
            return new Point(vector.X + point.X, vector.Y + point.Y);
        }
        public void Change2Points(Point p0, Point p1)
        {
            if (_Current2Points != null && _Current2Points[0].Equals(p0) && _Current2Points[1].Equals(p1))
                return;

            CalculaParaPasarPor2Puntos(p0, p1);
        }
    }
}
