namespace VaporStore.Common;

using Microsoft.EntityFrameworkCore.Query;

public static class ValidationConstants
{
    //User
    public const string GamePriceMinValue = "0";
    public const string GamePriceMaxValue = "79228000000000000000000000000";

    //User
    public const int UsernameMinLength = 3;
    public const int UsernameMaxLength = 20;
    public const string UserFullNameRegEx = @"^([A-Z][a-z]+\s[A-Z][a-z]+)$";
    public const int UserAgeMinValue = 3;
    public const int UserAgeMaxValue = 103;

    //Card
    public const string CardNumberRegEx = @"^(\d{4}\s\d{4}\s\d{4}\s\d{4})$";
    public const string CardCvcRegEx = @"^(\d{3})$";

    //Purchase
    public const string PurchaseProductKeyRegEx = @"^([A-Z\d]{4}\-[A-Z\d]{4}\-[A-Z\d]{4})$";

}
