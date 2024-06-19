using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plane
{
    internal class TankerAircraft: ITankerAircraft
    {
        private double fuel;
        private double fuelTankCapacity;
        public TankerAircraft(double fuelTankCapacity)
        {
            this.fuelTankCapacity = fuelTankCapacity;
            this.fuel = fuelTankCapacity;
        }

        public double GetFuelTankCapacity() { return this.fuelTankCapacity; }
        public double RequestFuel(double amount)
        {   
            if (this.fuel <= amount)
            {
                this.fuel = 0;
                return amount - fuel;
            }
            this.fuel = fuel - amount;
            return amount;
        }

    }
}
