namespace Contacts.Data.Validations
{
    public static class ErrorMessages
    {
        //ErrorMessages
        public const string RequiredErrorMessage = "The {0} is required.";

        public const string StringLengthErrorMessage = "The {0} must be at least {2} and at max {1} characters long.";

        public const string PhoneErrorMessage = "The {0} must start with 0,359 or +359 and should contain only digits(and whitespaces or -).";

        public const string WebsiteErrorMessage = "The {0} must start with www. and ends with .bg. Should contain only digits,letters(and -).";


    }
}
