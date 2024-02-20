namespace MilitaryElite.Models
{
    using System.Text;
    using System.Collections.Generic;

    using Contracts;

    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private ICollection<IPrivate> privates;

        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary, ICollection<IPrivate> privates)
            : base(id, firstName, lastName, salary)
        {
            this.privates = privates;
        }

        public IReadOnlyCollection<IPrivate> Privates
        { get { return (IReadOnlyCollection<IPrivate>)this.privates; } }

        public decimal Salary { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());

            foreach (IPrivate privateSoldier in this.privates)
            {
                sb.AppendLine($"  {privateSoldier.ToString()}");
            }

            return sb.ToString().Trim();
        }
    }
}
