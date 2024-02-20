namespace PizzaCalories
{
    public static class ExeptionMessages
    {
        public const string InvalidDoughType = "Invalid type of dough.";

        public const string InvalidDoughWeight = "Dough weight should be in the range [1..200].";

        public const string InvalidToppingType = "Cannot place {0} on top of your pizza.";

        public const string InvalidToppingWeight = "{0} weight should be in the range [1..50].";

        public const string InvalidPizzaName = "Pizza name should be between 1 and 15 symbols.";

        public const string InvalidToppingsCount = "Number of toppings should be in range [0..10].";
    }
}
