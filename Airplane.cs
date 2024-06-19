using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plane
{
    public class Airplane
    {
        private List<string> statuses = new List<string> {
            "OnTheGround",
            "Takeoff",
            "Flight",
            "Landing"
        };
        private double fuel;
        private double fuelTankCapacity;
        private byte numberOfSeats;
        private bool serviceStaff;
        private string status;
        private byte numberOfPassengers;
        private byte numberOfPilots;
        private byte numberOfStewardess;

        enum SeatsLimits
        {
            MIN = 10,
            MAX = 200,
        };
        enum FuelTankLimits
        {
            MIN = 300,
            MAX = 5000,
        };

        public Airplane(byte numberOfSeats, double fuelTankCapacity, double fuel = 0, bool serviceStaff = true, string status = "OnTheGround",
            byte numberOfPassengers = 0, byte numberOfPilots = 0, byte numberOfStewardess = 0)
        {
            if (fuelTankCapacity < (double)FuelTankLimits.MIN ||
           fuelTankCapacity > (double)FuelTankLimits.MAX)
            {
                throw new ArgumentOutOfRangeException("Fuel Tank Capacity out of range");
            }
            if (numberOfSeats < (byte)SeatsLimits.MIN || numberOfSeats > (byte)SeatsLimits.MAX)
            {
                throw new ArgumentOutOfRangeException("Seats number out of range");
            }
            if (!statuses.Contains(status))
            {
                throw new ArgumentException("NegativeValue");
            }

            this.numberOfSeats = numberOfSeats;
            this.fuelTankCapacity = fuelTankCapacity;
            this.serviceStaff = serviceStaff;
            this.status = status;
            this.fuel = fuel;
            this.numberOfPassengers = numberOfPassengers;
            this.numberOfPilots = numberOfPilots;
            this.numberOfStewardess = numberOfStewardess;
        }

        public double GetFuel() { return this.fuel; }
        public void SetFuel(double fuel) 
        {  
            if (fuel < 0)
            {
                throw new ArgumentException("У самолёта нет топлива ");
            }
            this.fuel = fuel; 
        }
        public double GetFuelTankCapacity() { return this.fuelTankCapacity; }
        public string GetStatus() { return this.status; }
        public bool GetServiceStaff() { return this.serviceStaff; }
        public byte GetNumberOfSeats() { return this.numberOfSeats; }
        public byte GetNumberOfPassengers() { return this.numberOfPassengers; }
        public byte GetNumberOfPilots() { return this.numberOfPilots; }
        public byte GetNumberOfStewardess() { return this.numberOfStewardess; }


        public void Refuel(ITankerAircraft aircraft)
        {   
            double amount = this.GetFuelTankCapacity() - this.GetFuel();
            this.fuel += aircraft.RequestFuel(amount);
            if (this.fuel > this.fuelTankCapacity)
            {
                this.fuel = this.fuelTankCapacity;
            }
        }
    }
}

