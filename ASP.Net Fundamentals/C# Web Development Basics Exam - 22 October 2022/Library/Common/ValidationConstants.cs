namespace Library.Common
{
    public static class ValidationConstants
    {
        public static class Book
        {
            public const int TitleMinLength = 10;
            public const int TitleMaxLength = 50;
            public const int AuthorMinLength = 5;
            public const int AuthorMaxLength = 50;
            public const int DescriptionMinLength = 5;
            public const int DescriptionMaxLength = 5000;
            public const string RatingMinLength = "0";
            public const string RatingMaxLength = "10";
        }

        public static class Category
        {
            public const int NameMinLength = 5;
            public const int NameMaxLength = 50;
        }
    }
}
