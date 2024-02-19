namespace P01.Valid_Usernames
{
    internal class Program
    {
        const int MinUsernameLenght = 3;
        const int MaxUsernameLenght = 16;

        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var user in usernames)
            {
                if (ValidateUsername(user))
                {
                    Console.WriteLine(user);
                }
            }
        }

        static bool ValidateUsername(string username)
        {
            return ValidateUsernameLenght(username)
                && ValidateUsernameContent(username);
        }

        static bool ValidateUsernameLenght(string username)
        {
            return username.Length >= MinUsernameLenght
                && username.Length <= MaxUsernameLenght;
        }

        static bool ValidateUsernameContent(string username)
        {
            foreach (char ch in username)
            {
                if (!char.IsLetterOrDigit(ch) && ch != 45 && ch != 95)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
