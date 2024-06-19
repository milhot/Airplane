using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plane
{
    public interface ITankerAircraft
    {
        public double GetFuelTankCapacity();
        public double RequestFuel(double amount);
    }
}
