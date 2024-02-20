namespace ValidationAttributes.Utilities
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Attributes;

    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type objType = obj.GetType();
            PropertyInfo[] propertyInfos = objType.GetProperties()
                    .Where(p => p.CustomAttributes
                    .Any(ca => typeof(MyValidationAttribute).IsAssignableFrom(ca.AttributeType)))
                    .ToArray();

            foreach (PropertyInfo property in propertyInfos)
            {
                object[] customAttributes = property.GetCustomAttributes()
                        .Where(ca => typeof(MyValidationAttribute).IsAssignableFrom(ca.GetType()))
                        .ToArray();

                object propertyValue = property.GetValue(obj);

                foreach (object customAttribute in customAttributes)
                {
                    MethodInfo isValidMethod = customAttribute.GetType()
                        .GetMethods(BindingFlags.Instance | BindingFlags.Public)
                        .FirstOrDefault(mi => mi.Name == "IsValid");

                    if (isValidMethod == null)
                    {
                        throw new InvalidOperationException("Your custom attribute does not have IsValid method!");
                    }

                    bool result = (bool)isValidMethod
                        .Invoke(customAttribute, new object[] { propertyValue });

                    if (!result)
                    {
                        return false;
                    }
                  
                }
            }

            return true;
        }
    }
}
