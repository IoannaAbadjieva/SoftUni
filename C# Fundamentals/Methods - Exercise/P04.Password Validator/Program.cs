namespace P04.Password_Validator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int passwordMinLenght = 6;
            const int passwordMaxLenght = 10;
            const int passwordMinDigitsCount = 2;


            string password = Console.ReadLine();

            if (ValidatePassword(password, passwordMinLenght, passwordMaxLenght, passwordMinDigitsCount))
            {
                Console.WriteLine("Password is valid");
            }
        }

        static bool ValidatePassword(string password, int passwordMinLenght, int passwordMaxLenght, int passwordMinDigitsCount)
        {
            bool isPasswordValid = true;

            if (!ValidatePasswordLenght(password, passwordMinLenght, passwordMaxLenght))
            {
                Console.WriteLine($"Password must be between {passwordMinLenght} and {passwordMaxLenght} characters ");
                isPasswordValid = false;
            }

            if (!ValidatePasswordIsAlphaNumerical(password))
            {
                Console.WriteLine("Password must consist only of letters and digits");
                isPasswordValid = false;
            }

            if (!ValidateMInDigitsCount(password, passwordMinDigitsCount))
            {
                Console.WriteLine($"Password must have at least {passwordMinDigitsCount} digits");
                isPasswordValid = false;
            }

            return isPasswordValid;
        }

        static bool ValidatePasswordLenght(string password, int minLenght, int maxLenght)
        {

            if (password.Length < minLenght || password.Length > maxLenght)
            {
                return false;
            }

            return true;
        }

        static bool ValidatePasswordIsAlphaNumerical(string password)
        {

            foreach (char ch in password)
            {
                if (!Char.IsLetterOrDigit(ch))
                {
                    return false;
                }
            }
            return true;
        }

        static bool ValidateMInDigitsCount(string password, int minDigitsCount)
        {
            int digitsCount = 0;

            foreach (char ch in password)
            {
                if (Char.IsDigit(ch))
                {
                    digitsCount++;
                }
            }

            return digitsCount >= minDigitsCount;
        }

    }
}
