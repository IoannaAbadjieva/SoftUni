﻿namespace CarRacing.Models.Cars
{
   

    public class SuperCar : Car
    {
        private const double InitialFuel = 80.0;
        private const double RaceFuelConsumption = 10.0;


        public SuperCar(string make, string model, string VIN, int horsePower) 
            : base(make, model, VIN, horsePower, InitialFuel, RaceFuelConsumption)
        {

        }
    }
}
