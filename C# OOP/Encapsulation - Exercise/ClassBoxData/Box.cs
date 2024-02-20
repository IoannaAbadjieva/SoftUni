namespace ClassBoxData
{
    using System;
    using System.Text;

    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get { return length; }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(String.Format(ExeptionMessages.ZeroOrNegativeArgument, nameof(this.Length)));
                }

                length = value;
            }
        }

        public double Width
        {
            get { return width; }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(String.Format(ExeptionMessages.ZeroOrNegativeArgument, nameof(this.Width)));
                }

                width = value;
            }
        }

        public double Height
        {
            get { return height; }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(String.Format(ExeptionMessages.ZeroOrNegativeArgument, nameof(this.Height)));
                }

                height = value;
            }
        }

        public double SurfaceArea()
        {
            return 2 * this.Length * this.Width + LateralSurfaceArea();
        }

        public double LateralSurfaceArea()
        {
            return 2 * this.Length * this.Height + 2 * this.Width * this.Height;
        }

        public double Volume()
        {
            return this.Length * this.Width * this.Height;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"Surface Area - {SurfaceArea():f2}")
                .AppendLine($"Lateral Surface Area - {LateralSurfaceArea():f2}")
                .AppendLine($"Volume - {Volume():f2}");

            return sb.ToString().Trim();
        }

    }
}
