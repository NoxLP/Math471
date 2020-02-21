using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math471.StraightLine
{
    public interface IStraightLineEquation
    {
        double YValueForX(double x);
        double XValueForY(double y);
    }
}
