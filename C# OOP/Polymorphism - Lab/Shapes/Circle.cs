﻿namespace Shapes
{
    using System;

    public class Circle : Shape
    {
        private readonly double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * this.radius * this.radius;
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * this.radius;
        }

      
    }
}
