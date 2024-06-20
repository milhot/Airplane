using NUnit.Framework;
using Plane;

namespace TestAirplane
{
    [TestFixture]
    public class AirplaneTest
    {
        //[Test]
        //public static void TestAirplaneConstraction()
        //{
        //    // 100 - number of seats, 500.0 Ц fuel tank capacity
        //    Airplane airplane = new Airplane(100, 500.0);
        //    Assert.That(airplane.GetFuel(), Is.EqualTo(0));
        //    Assert.That(airplane.GetNumberOfSeats(), Is.EqualTo(100));
        //    Assert.That(airplane.GetNumberOfPassengers(), Is.EqualTo(0));
        //    Assert.That(airplane.GetNumberOfPilots(), Is.EqualTo(0));
        //    Assert.That(airplane.GetNumberOfStewardess(), Is.EqualTo(0));
        //    Assert.That(airplane.GetFuelTankCapacity(), Is.EqualTo(500.0));
        //    // 50 - number of seats, 400.3 Ц fuel tank capacity
        //    Airplane airplane1 = new Airplane(50, 400.3);
        //    Assert.That(airplane1.GetNumberOfSeats(), Is.EqualTo(50));
        //    Assert.That(airplane1.GetFuelTankCapacity(), Is.EqualTo(400.3));
        //}

        //[Test]
        //public static void TestAirplaneRefuel()
        //{
        //    Airplane airplane = new Airplane(100, 500.0);
        //    Assert.That(airplane.GetFuel(), Is.EqualTo(0));
        //    airplane.Refuel(100.0);
        //    Assert.That(airplane.GetFuel(), Is.EqualTo(100));
        //    airplane.Refuel(200.0);
        //    Assert.That(airplane.GetFuel(), Is.EqualTo(300.0));
        //    // amount of fuel can't exceed the airplaneТs fuel tank capacity
        //    airplane.Refuel(300.0);
        //    Assert.That(airplane.GetFuel(), Is.LessThanOrEqualTo(airplane.GetFuelTankCapacity()));
        //}

        //[Test]
        //public static void TestAirplaneNegativeRefuel()
        //{
        //    try
        //    {
        //        Airplane airplane = new Airplane(100, 500.0);
        //        airplane.Refuel(-1.0);
        //    }
        //    catch (ArgumentException except)
        //    {
        //        Assert.That(except.Message,
        //       Does.Contain("NegativeValue"));
        //        return;
        //    }
        //    Assert.Fail("No exception was thrown");
        //}

        [Test]
        public static void TestAirplaneTankAndSeatsLimits()
        {
            try
            {
                Airplane airplane = new Airplane(100, 100.0);
            }
            catch (ArgumentOutOfRangeException except)
            {
                Assert.That(except.Message, Does.Contain("Fuel Tank Capacity out of range"));
                return;
            }
            try
            {
                Airplane airplane1 = new Airplane(230, 500.0);
            }
            catch (ArgumentOutOfRangeException except)
            {
                Assert.That(except.Message, Does.Contain("Seats number out of range"));
                return;
            }
            Assert.Fail("No exception was thrown");
        }
        [Test]
        public static void TestRefuelUsingTankerAircraft()
        {
            // создаем самолет и фальшивый заправщик с 800 литрами топлива
            Airplane plane = new Airplane( 100, 400.0, 100.0);
            MockTankerAircraft tanker = new MockTankerAircraft(1400.0);
            Random rand = new Random();
            double fuel_costs;
            double fuelBefore;
            for (int i = 0; i < 5; i++)
            {
                fuelBefore = plane.GetFuel();
                plane.Refuel(tanker);
                Assert.That(plane.GetFuel() - fuelBefore, Is.EqualTo(tanker.requestFuelResult));
                //fuel_costs = 200.0 + rand.NextDouble() * (300.0 - 200.0);
                fuel_costs = rand.Next(200, 300);
                double query = plane.GetFuelTankCapacity() - (plane.GetFuel() - fuel_costs);
                plane.SetFuel(plane.GetFuel() - fuel_costs);
                
                Assert.That(plane.GetFuelTankCapacity() - plane.GetFuel(), Is.EqualTo(query));
                Console.WriteLine($"{fuel_costs} - {plane.GetFuel()} - {tanker.requestFuelResult} - {tanker.GetFuelTankCapacity()}");
            }
            
        }

    }
}