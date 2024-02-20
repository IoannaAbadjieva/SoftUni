using System.Linq;

namespace Stealer
{
    using System;
    using System.Reflection;
    using System.Reflection.Metadata;
    using System.Text;
    using System.Xml.Linq;

    public class Spy
    {
        public Spy()
        {

        }

        public string StealFieldInfo(string investigatedClass, params string[] investigatedFields)
        {
            StringBuilder sb = new StringBuilder();

            Type classType = Type.GetType(investigatedClass);
            FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static |
                                                          BindingFlags.NonPublic | BindingFlags.Public);

            Object classInstance = Activator.CreateInstance(classType, new object[] { });

            sb.AppendLine($"Class under investigation: {investigatedClass}");

            foreach (FieldInfo field in classFields.Where(f => investigatedFields.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().Trim();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            StringBuilder sb = new StringBuilder();


            Type classType = Type.GetType(className);
            //Object classInstance = Activator.CreateInstance(classType, new object[] { });
            FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            MethodInfo[] classNonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            MethodInfo[] classPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);

            

            foreach (FieldInfo field in classFields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }

            foreach (MethodInfo method in classNonPublicMethods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }

            foreach (MethodInfo method in classPublicMethods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }

            return sb.ToString().Trim();
        }

        public string RevealPrivateMethods(string className)
        {
            StringBuilder sb = new StringBuilder();

            Type classType = Type.GetType(className);
            MethodInfo[] classMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            sb
                .AppendLine($"All Private Methods of Class: {className}")
                .AppendLine($"Base Class: {classType.BaseType.Name}");

            foreach (MethodInfo method in classMethods)
            {
                sb.AppendLine(method.Name );
            }

            return sb.ToString().Trim();
        }

        public string CollectGettersAndSetters(string className)
        {
            StringBuilder sb = new StringBuilder();

            Type classType = Type.GetType(className);
            MethodInfo[] classMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            foreach (MethodInfo method in classMethods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
            }

            foreach (MethodInfo method in classMethods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
            }

            return sb.ToString().Trim();
        }

    }
}
