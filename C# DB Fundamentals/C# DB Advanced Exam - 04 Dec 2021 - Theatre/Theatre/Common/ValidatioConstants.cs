namespace Theatre.Common;


public static class ValidatioConstants
{
    //Theatre
    public const int TheatreNameMaxLength = 30;
    public const int TheatreNameMinLength = 4;

    public const int TheatreDirectorMaxLength = 30;
    public const int TheatreDirectorMinLength = 4;

    public const string TheatreNumberOfHallsMinValue = "1";
    public const string TheatreNumberOfHallsMaxValue = "10";

    //Play
    public const int PlayTitleMaxLength = 50;
    public const int PlayTitleMinLength = 4;

    public const float PlayRatingMinValue = 0f;
    public const float PlayRatingMaxValue = 10f;

    public const int PlayDescriptionMaxLength = 700;

    public const int PlayScreenwriterMaxLength = 30;
    public const int PlayScreenwriterMinLength = 4;

    //Cast
    public const int CastFullNameMaxLength = 30;
    public const int CastFullNameMinLength = 4;

    public const int CastIsMainCharacterMinValue = 0;
    public const int CastIsMainCharacterMaxValue = 1;

    public const string CastPhoneNumberRegEx = @"^\+44-\d{2}-\d{3}-\d{4}$";

    //Ticket
    public const string TicketPriceMinValue = "1";
    public const string TicketPriceMaxValue = "100";

    public const string TicketRowNumberMinValue = "1";
    public const string TicketRowNumberMaxValue = "10";
}
