﻿namespace Watchlist.Data.Validations
{
    public static class DataConstants
    {
        public static class Movie
        {
            public const int TitleMinLength = 10;
                            
            public const int TitleMaxLength = 50;

            public const int DirectorMinLength = 5;
                            
            public const int DirectorMaxLength = 50;

            public const string RatingMinValue = "0";
                                  
            public const string RatingMaxValue = "10";
        }

        public static class Genre
        {
            public const int NameMinLength = 5;
                       
            public const int NameMaxLength = 50;

        }

        public static class User
        {
            public const int UserNameMinLength = 5;
                             
            public const int UserNameMaxLength = 20;

            public const int EmailMinLength = 10;
                           
            public const int EmailMaxLength = 60;

            public const int PasswordMinValue = 5;
                            
            public const int PasswordMaxValue = 20;
        }
    }
}
