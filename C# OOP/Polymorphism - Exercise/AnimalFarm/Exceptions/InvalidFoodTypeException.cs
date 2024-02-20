namespace AnimalFarm.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class InvalidFoodTypeException:Exception
    {
        private const string DefaultMessage = "Type of food not supported";

        public InvalidFoodTypeException()
            :base(DefaultMessage)
        {

        }

        public InvalidFoodTypeException(string message)
            :base(message)
        {

        }
    }
}
