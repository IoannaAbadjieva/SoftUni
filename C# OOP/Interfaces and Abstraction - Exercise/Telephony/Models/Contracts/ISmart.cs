namespace Telephony.Models.Contracts
{
    public interface ISmart : IStationary
    {
        public string Browse(string url);
    }
}
