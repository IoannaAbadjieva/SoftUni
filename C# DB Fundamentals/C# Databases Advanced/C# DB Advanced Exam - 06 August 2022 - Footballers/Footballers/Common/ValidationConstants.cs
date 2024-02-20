namespace Footballers.Common;


public static class ValidationConstants
{
    //Footballer
    public const int FootballerNameMinLength = 2;
    public const int FootballerNameMaxLength = 40;
    public const int FootballerPositionTypeMinValue = 0;
    public const int FootballerPositionTypeMaxValue = 3;
    public const int FootballerBestSkillTypeMinValue = 0;
    public const int FootballerBestSkillTypeMaxValue = 4;

    //Team 
    public const int TeamNameMinLength = 3;
    public const int TeamNameMaxLength = 40;
    public const string TeamNameRegEx = @"^([\w\d\s\.\-]{3,})$";
    public const int TeamNationalityMinLength = 2;
    public const int TeamNationalityMaxLength = 40;
    public const int TeamTrophiesMinValue = 1;

    //Coach
    public const int CoachNameMinLength = 2;
    public const int CoachNameMaxLength = 40;
}
