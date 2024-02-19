using Exam.DeliveriesManager;
using System;
using System.Linq;

namespace Exam.DeliveriesManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DeliveriesManager deliveriesManager = new DeliveriesManager();

            Deliverer firstDeliverer = new Deliverer("1", "First");
            deliveriesManager.AddDeliverer(firstDeliverer);
            Deliverer secondDeliverer = new Deliverer("2", "Second");
            deliveriesManager.AddDeliverer(secondDeliverer);     
            Deliverer thirdDeliverer = new Deliverer("3", "Third");
            deliveriesManager.AddDeliverer(secondDeliverer);

            Package firstPackage = new Package("1", "me", "somewhere", "someNumber", 57.25);
            Package secondPackage = new Package("2", "you", "someOtherPlace", "someOtherNumber", 64.25);
            Package thirdPackage = new Package("3", "zthey", "someEntirelyDifferentPlace", "someDifferentNumber", 64.25);

            deliveriesManager.AddPackage(firstPackage);
            deliveriesManager.AddPackage(secondPackage);
            deliveriesManager.AddPackage(thirdPackage);

            deliveriesManager.AssignPackage(secondDeliverer, firstPackage);

            Console.WriteLine(string.Join(", ", deliveriesManager.GetDeliverersOrderedByCountOfPackagesThenByName()
                                                                    .Select(d => d.Id)));

            Console.WriteLine(string.Join(", ", deliveriesManager.GetDeliverersOrderedByCountOfPackagesThenByName().Select(d => d.Name)));
            Console.WriteLine(string.Join(", ", deliveriesManager.GetUnassignedPackages().Select(p => p.Id)));
            Console.WriteLine(string.Join(", ", deliveriesManager.GetPackagesOrderedByWeightThenByReceiver().Select(p => p.Id)));
        }
    }
}
