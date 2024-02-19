using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Renovator
    {
		private string name;

		private string type;

		private double rate;

		private int days;

		private bool hired;

		public Renovator(string name, string type, double rate, int days)
		{
			this.name = name;
			this.type = type;
			this.rate = rate;
			this.days = days;
			this.hired = false;
			
		}

		public bool Hired
		{
			get { return hired; }
			set { hired = value; }
		}


		public int Days
		{
			get { return days; }
			set { days = value; }
		}


		public double Rate
		{
			get { return rate; }
			set { rate = value; }
		}


		public string Type
		{
			get { return type; }
			set { type = value; }
		}


		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendLine($"-Renovator: {this.name}");
			sb.AppendLine($"--Specialty: {this.type}");
			sb.AppendLine($"--Rate per day: {this.rate} BGN");

			return sb.ToString().TrimEnd();
		}

	}
}
