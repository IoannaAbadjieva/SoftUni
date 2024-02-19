using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Car
    {
        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
        }
        public Car(string model, Engine engine, int weight) : this(model, engine)
        {
            Weight = weight;
        }

        public Car(string model, Engine engine, string color) : this(model, engine)
        {
            Color = color;
        }

        public Car(string model, Engine engine, int weight, string color) : this(model, engine)
        {
            Weight = weight;
            Color = color;
        }

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public int Weight { get; set; }

        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Model}:");
            sb.AppendLine($"  {Engine.Model}:");
            sb.AppendLine($"    Power: {Engine.Power}");
            sb.AppendLine($"    Displacement: {(Engine.Displacement != default(int) ? Engine.Displacement.ToString() : "n/a")}");
            sb.AppendLine($"    Efficiency: {(Engine.Efficiency != default(String) ? Engine.Efficiency : "n/a")}");
            sb.AppendLine($"  Weight: {(Weight != default(int) ? Weight.ToString() : "n/a")}");
            sb.AppendLine($"  Color: {(Color != default(String) ? Color : "n/a")}");

            return sb.ToString().TrimEnd();
        }

    }
}
