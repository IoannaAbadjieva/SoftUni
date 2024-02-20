namespace Easter.Models.Workshops
{
    using System.Linq;

    using Bunnies.Contracts;
    using Easter.Models.Dyes.Contracts;
    using Eggs.Contracts;
    using Workshops.Contracts;


    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {
            while (bunny.Energy > 0 && bunny.Dyes.Any())
            {
                IDye dye = bunny.Dyes.FirstOrDefault();

                while (!egg.IsDone() && !dye.IsFinished() && bunny.Energy > 0)
                {
                    bunny.Work();
                    egg.GetColored();
                    dye.Use();

                }

                if (dye.IsFinished())
                {
                    bunny.Dyes.Remove(dye);
                }

                if (egg.IsDone())
                {
                    break;
                }

            }
        }
    }
}
