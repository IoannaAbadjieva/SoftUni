namespace Vehicles.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Exceptions;
    using Factories.Contracts;
    using IO.Contracts;
    using Models.Contracts;
    using Vehicles.Models;

    public class Engine : IEngine
    {

        private readonly ICollection<IVehicle> vehicles;
        private IReader reader;
        private IWriter writer;
        private IVehicleFactory vehicleFactory;

        private Engine()
        {
            this.vehicles = new HashSet<IVehicle>();
        }

        public Engine(IReader reader, IWriter writer, IVehicleFactory vehicleFactory)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
            this.vehicleFactory = vehicleFactory;
        }

        public void Run()
        {
            this.vehicles.Add(this.CreateNewVehicle());
            this.vehicles.Add(this.CreateNewVehicle());
            this.vehicles.Add(this.CreateNewVehicle());
            ProcessCommands();
            PrintVehicles();
        }

        private IVehicle CreateNewVehicle()
        {
            IVehicle vehicle;

            string[] vehicleInfo = this.reader.ReadLine()
                            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string type = vehicleInfo[0];
            double fuelQuantity = double.Parse(vehicleInfo[1]);
            double fuelConsumption = double.Parse(vehicleInfo[2]);
            double tankCapacity = double.Parse(vehicleInfo[3]);

            vehicle = vehicleFactory.CreateVehicle(type, fuelQuantity, fuelConsumption, tankCapacity);

            return vehicle;
        }

        private void ProcessCommands()
        {
            int cmdCount = int.Parse(this.reader.ReadLine());

            for (int i = 0; i < cmdCount; i++)
            {
                try
                {
                    string[] cmdArgs = this.reader.ReadLine()
                                                   .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    string cmdType = cmdArgs[0];
                    string vehicleType = cmdArgs[1];
                    double argument = double.Parse(cmdArgs[2]);

                    IVehicle vehicle = vehicles.FirstOrDefault(v => v.GetType().Name == vehicleType);

                    if (vehicle == null)
                    {
                        throw new InvalidVehicleTypeException();
                    }

                    if (cmdType == "Drive")
                    {
                        this.writer.WriteLine(vehicle.Drive(argument));
                    }
                    else if (cmdType == "Refuel")
                    {
                        vehicle.Refuel(argument);
                    }
                    else if (cmdType == "DriveEmpty")
                    {
                        Bus bus = vehicle as Bus;

                        if (bus != null)
                        {
                            bus.IsEmpty = true;
                            this.writer.WriteLine(bus.Drive(argument));
                            bus.IsEmpty = false;
                        }
                    }
                }
                catch (InvalidVehicleTypeException ex)
                {

                    this.writer.WriteLine(ex.Message);
                }
                catch (InsufficientFuelException ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
                catch (InsufficientTankCapacityException ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
                catch (InvalidFuelQuantityException ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
                catch
                {
                    throw;
                }

            }


        }

        private void PrintVehicles()
        {
            foreach (IVehicle vehicle in this.vehicles)
            {
                this.writer.WriteLine(vehicle.ToString());
            }
        }
    }
}
