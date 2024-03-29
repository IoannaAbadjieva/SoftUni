﻿namespace SeminarHub.Data.DataValidation
{
	public static class DataConstants
	{
		public static class Seminar
		{
			public const int TopicMinLength = 3;

			public const int TopicMaxLength = 100;

			public const int LecturerMinLength = 5;

			public const int LecturerMaxLength = 60;

			public const int DetailsMinLength = 10;

			public const int DetailsMaxLength = 500;

			public const int DurationMinValue = 30;

			public const int DurationMaxValue = 180;

			public const string DateFormat = "yyyy-MM-dd H:mm";
		}

		public static class Category
		{
			public const int NameMinLength = 3;

			public const int NameMaxLength = 50;
		}
	}
}
