namespace Homies.Data.DataValidations
{
    public static  class ErrorMessages
    {
        public const string RequiredErrorMessage = "The {0} is required";

        public const string StringLengthErrorMessage = "The {0} must be at least {2} and at max {1} characters long.";

        public const string DateFormatErrorMessage = "The {0} must be in format yyyy-MM-dd H:mm.";
    }
}
