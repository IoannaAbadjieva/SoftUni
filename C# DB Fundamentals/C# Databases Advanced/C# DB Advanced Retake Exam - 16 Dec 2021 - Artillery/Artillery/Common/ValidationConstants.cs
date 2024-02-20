namespace Artillery.Common;


public static class ValidationConstants
{
    //Country
    public const int CountryNameMaxLength = 60;
    public const int CountryNameMinLength = 4;
    public const int CountryArmySizeMinValue = 50000;
    public const int CountryArmySizeMaxValue = 10000000;

    //Manufacturer
    public const int ManufacturerNameMaxLength = 40;
    public const int ManufacturerNameMinLength = 4;
    public const int ManufacturerFoundedMaxLength = 100;
    public const int ManufacturerFoundedMinLength = 10;

    //Shell
    public const int ShellCaliberMaxLength = 30;
    public const int ShellCaliberMinLength = 4;
    public const int ShellWeightMinValue = 2;
    public const int ShellWeightMaxValue = 1680;

    //Gun
    public const int GunWeightMinValue = 100;
    public const int GunWeightMaxValue = 1350000;
    public const double BarrelLengthMinValue = 2;
    public const double BarrelLengthMaxValue = 35;
    public const int GunRangeMinValue = 1;
    public const int GunRangeMaxValue = 100000;
}
