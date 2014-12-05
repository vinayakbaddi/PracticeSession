using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.Creational.Factory
{
    public enum Vehicle 
    { 
        Scooter,
        Bike
    }

    public interface IFactory
    {
        void Drive(int miles);
    }

    class Scooter : IFactory
    { 
        public void Drive(int miles)
        {
            Console.WriteLine("Drive the Scrooter {0}km", miles);
        }
    }

    class Bike : IFactory
    {
        public void Drive(int miles)
        {
            Console.WriteLine("Drive the Bike {0}km", miles);
        }
    }

    public abstract class VehicleFactory
    {
        public abstract IFactory GetVehicle(Vehicle vehicle);
    }

    public class ConcreteVehicleFactory : VehicleFactory
    {
        public override IFactory GetVehicle(Vehicle vehicle)
        {
            switch (vehicle) { 
                case  Vehicle.Scooter:
                    {
                        return new Scooter();
                    }
                case Vehicle.Bike:
                    {
                        return new Bike();
                    }
                default:
                    throw new ApplicationException(string.Format("Vehicle request cannot be created"));
            }
        }
    }

    public class FactoryProgram
    {
        public static void ExecuteFactory() {
            VehicleFactory factory = new ConcreteVehicleFactory();

            IFactory scooter = factory.GetVehicle(Vehicle.Bike);
            scooter.Drive(10);

            scooter = factory.GetVehicle(Vehicle.Scooter);
            scooter.Drive(20);

        }
    }
}
