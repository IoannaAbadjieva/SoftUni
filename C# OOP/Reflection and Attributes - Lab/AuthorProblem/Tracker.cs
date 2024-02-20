namespace AuthorProblem
{
    using System;
    using System.Linq;
    using System.Reflection;


    public class Tracker
    {
        public Tracker()
        {

        }

        public void PrintMethodsByAuthor()
        {
            Type type = typeof(StartUp);
            var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);

            foreach (var method in methods)
            {
                if (method.CustomAttributes.Any(ca => ca.AttributeType == typeof(AuthorAttribute)))
                {
                    var attributes = method.GetCustomAttributes(false);

                    foreach (AuthorAttribute attribute in attributes)
                    {
                        Console.WriteLine($"{method.Name} is written by {attribute.Name}");
                    }
                }
            }
        }
    }
}
