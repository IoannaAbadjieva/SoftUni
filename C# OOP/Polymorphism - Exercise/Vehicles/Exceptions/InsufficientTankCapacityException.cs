namespace Vehicles.Exceptions
{
    using System;


    public class InsufficientTankCapacityException : Exception
    {
        public InsufficientTankCapacityException(string message)
            : base(message)
        {

        }
    }
}
