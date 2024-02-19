using System.Collections.Generic;

namespace _02.FitGym
{
    public class Trainer
    {
        public Trainer(int id, string name, int popularity)
        {
            this.Id = id;
            this.Name = name;
            this.Popularity = popularity;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Popularity { get; set; }

        public HashSet<Member> Members = new HashSet<Member>();

        public override bool Equals(object obj)
        {
            return Id.Equals(((Trainer)obj).Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}