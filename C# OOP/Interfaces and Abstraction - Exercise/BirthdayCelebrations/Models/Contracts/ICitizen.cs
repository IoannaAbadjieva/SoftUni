namespace BirthdayCelebrations.Models.Contracts
{
    public interface ICitizen : IIdentifiable, IBirthable
    {
        public string Name { get; }

        public int Age { get; }
    }
}
