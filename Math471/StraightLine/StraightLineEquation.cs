using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Math471.StraightLine
{
    public class StraightLineEquation : IStraightLineEquation
    {
        public StraightLineEquation(Point pasaPor2Puntos_p0, Point pasaPor2Puntos_p1)
        {
            CalculaParaPasarPor2Puntos(pasaPor2Puntos_p0, pasaPor2Puntos_p1);
        }

        private Point[] _Current2Points;

        public double Pendiente { get; private set; }
        public double TerminoIndependiente { get; private set; }

        private void CalculaParaPasarPor2Puntos(Point p0, Point p1)
        {
            _Current2Points = new Point[2] { p0, p1 };
            Pendiente = (p1.Y - p0.Y) / (p1.X - p0.X);
            TerminoIndependiente = p1.Y - ((Pendiente) * p0.X);
        }
        public double YValueForX(double x)
        {
            return TerminoIndependiente + (Pendiente * x);
        }
        public double XValueForY(double y)
        {
            return (y - TerminoIndependiente) / Pendiente;
        }
        public void Change2Points(Point p0, Point p1)
        {
            if (_Current2Points != null && _Current2Points[0].Equals(p0) && _Current2Points[1].Equals(p1))
                return;

            CalculaParaPasarPor2Puntos(p0, p1);
        }
    }
}
