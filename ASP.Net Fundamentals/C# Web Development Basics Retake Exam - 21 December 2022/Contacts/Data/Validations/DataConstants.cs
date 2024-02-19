namespace Contacts.Data.Validations
{
    public static class DataConstants
    {
        //Contact
        public const int FirstNameMinLength = 2;

        public const int LastNameMinLength = 5;

        public const int ContactNameMaxLength = 50;

        public const string PhoneNumberRegEx = @"(\+?359|0){1}([ -]?[\d]{3}){1}([ -]?[\d]{2}){3}";

        public const string WebsiteRegEx = @"^(www\.[A-Za-z0-9-]+\.bg)$";

        //ApplicationUser
        public const int UsernameMinLength = 5;

        public const int UsernameMaxLength = 20;

        public const int PasswordMinLength = 5;

        public const int PasswordMaxLength = 20;

        //Contact && ApplicationUser
        public const int EmailMinLength = 10;

        public const int EmailMaxLength = 60;

    }
}

