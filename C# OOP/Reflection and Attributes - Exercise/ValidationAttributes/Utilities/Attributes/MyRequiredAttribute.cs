namespace ValidationAttributes.Utilities.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]

    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            return obj != null;
        }
    }
}
