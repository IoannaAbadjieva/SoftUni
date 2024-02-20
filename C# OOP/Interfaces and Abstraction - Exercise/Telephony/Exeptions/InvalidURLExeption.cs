namespace Telephony.Exeptions
{
    using System;
    
    public class InvalidURLExeption:Exception
    {
        private const string DefaultExeptionMessage = "Invalid URL!";

        public InvalidURLExeption()
            :base(DefaultExeptionMessage)
        {

        }

        public InvalidURLExeption(string message)
            :base(message)
        {

        }
    }
}
