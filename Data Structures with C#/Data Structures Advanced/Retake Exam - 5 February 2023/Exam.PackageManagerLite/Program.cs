using System;

namespace Exam.PackageManagerLite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var manager = new PackageManager();
            var package1 = new Package("1", "one", new DateTime(2000,12,1), "1.0");
            var package11 = new Package("11", "one", new DateTime(2000,12,11), "11.0");
            var package3 = new Package("3", "three", new DateTime(2000,12,3), "3.0");
            var package4 = new Package("4", "four", new DateTime(2000,12,4), "4.444");
            var package44 = new Package("44", "four-four", new DateTime(2000,12,4), "4.44");
            var package444 = new Package("444", "four-four-four", new DateTime(2000,12,4), "4.0");
            var package5 = new Package("5", "two", new DateTime(2000,12,5), "5.0");
            var package6 = new Package("6", "two", new DateTime(2000,12,6), "6.0");

            //Console.WriteLine(string.Join(Environment.NewLine, manager.GetOrderedPackagesByReleaseDateThenByVersion()));
            //Console.WriteLine();
            //Console.WriteLine(string.Join(Environment.NewLine, manager.GetIndependentPackages()));
            //Console.WriteLine(); 
            //Console.WriteLine(string.Join(Environment.NewLine, manager.GetDependants(package1)));
            //Console.WriteLine();

            manager.RegisterPackage(package1);
            manager.RegisterPackage(package11);
            manager.RegisterPackage(package3);
            manager.RegisterPackage(package4);
            manager.RegisterPackage(package44);
            manager.RegisterPackage(package6);
            manager.RegisterPackage(package5);
            manager.RegisterPackage(package444);

            manager.AddDependency("11", "1");
            manager.AddDependency("3", "1");
            manager.AddDependency("3", "4");
            manager.AddDependency("3", "44");
            manager.AddDependency("3", "444");
            manager.AddDependency("1", "5");
            manager.AddDependency("1", "4");


            Console.WriteLine(string.Join(Environment.NewLine, manager.GetOrderedPackagesByReleaseDateThenByVersion()));
            Console.WriteLine();
            Console.WriteLine(string.Join(Environment.NewLine, manager.GetIndependentPackages()));
            Console.WriteLine();
            Console.WriteLine(string.Join(Environment.NewLine, manager.GetDependants(package1)));
            Console.WriteLine();


        }
    }
}
