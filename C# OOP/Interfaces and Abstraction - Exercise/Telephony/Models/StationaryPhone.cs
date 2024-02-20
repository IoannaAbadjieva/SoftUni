namespace Telephony.Models
{
    using System.Linq;

    using Contracts;
    using Exeptions;

    public class StationaryPhone : IStationary
    {
        public StationaryPhone()
        {

        }

        public string Call(string phonenumber)
        {
            if (!IsPhoneNumberValid(phonenumber))
            {
                throw new InvalidPhoneNumberExeption();
            }

            return $"Dialing... {phonenumber}";
        }

        private bool IsPhoneNumberValid(string value)
        {
            return value.All(ch => char.IsDigit(ch));
        }
    }
}
