namespace Vehicles.Exceptions
{
    using System;

    public class InvalidFuelQuantityException:Exception
    {
        private const string DefaultMessage = "Fuel must be a positive number";

        public InvalidFuelQuantityException()
            :base(DefaultMessage)
        {

        }
    }
}
