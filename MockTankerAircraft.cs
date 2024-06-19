using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plane
{
    public class MockTankerAircraft : ITankerAircraft
    {
        public double requestFuelResult;
        private double fuelTankCapacity;

        // конструктор класса-имитатора самолета-заправщика
        public MockTankerAircraft(double fuelTankCapacity)
        {
            this.requestFuelResult = 0;
            this.fuelTankCapacity = fuelTankCapacity;
        }
        public double GetFuelTankCapacity() {  return this.fuelTankCapacity; }

        public double RequestFuel(double amount)
        {   
            if (amount >= this.fuelTankCapacity)
            {
                this.requestFuelResult = this.fuelTankCapacity;
            }
            else
            {
                this.requestFuelResult = amount;
            }
            this.fuelTankCapacity -= this.requestFuelResult;
            return this.requestFuelResult;
        }
    }
}
