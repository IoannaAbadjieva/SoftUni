using System;

namespace FishingNet
{
    public class Fish
    {

		public Fish(string fishType,double lenght,double weight)
		{
            FishType = fishType;
			Length = lenght;
			Weight = weight;

        }
		
		private string fishType;

		public string FishType
		{
			get { return fishType; }
			set { fishType = value; }
		}

		private double length;

		public double Length
		{
			get { return length; }
			set { length = value; }
		}

		private double weight;

		public double Weight
		{
			get { return weight; }
			set { weight = value; }
		}

		public override string ToString()
		{
			return $"There is a {FishType}, {Length} cm. long, and {Weight} gr. in weight.";
		}

	}
}
