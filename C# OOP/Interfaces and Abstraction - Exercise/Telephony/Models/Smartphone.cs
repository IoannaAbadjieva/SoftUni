namespace Telephony.Models
{
    using System.Linq;

    using Exeptions;
    using Contracts;

    public class Smartphone : ISmart
    {
        public Smartphone()
        {

        }

        public string Call(string phonenumber)
        {

            if (!IsPhoneNumberValid(phonenumber))
            {
                throw new InvalidPhoneNumberExeption();
            }

            return $"Calling... {phonenumber}";
        }

        public string Browse(string url)
        {
            if (!IsURLValid(url))
            {
                throw new InvalidURLExeption();
            }

            return $"Browsing: {url}!";
        }

        private bool IsPhoneNumberValid(string value)
        {
            return value.All(ch => char.IsDigit(ch));
        }

        private bool IsURLValid(string value)
        {
            return value.All(ch => !char.IsDigit(ch));
        }
    }
}
