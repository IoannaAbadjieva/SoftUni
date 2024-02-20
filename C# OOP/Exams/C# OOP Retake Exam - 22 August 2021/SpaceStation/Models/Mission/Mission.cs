namespace SpaceStation.Models.Mission
{
    using System.Collections.Generic;

    using Contracts;
    using Astronauts.Contracts;
    using Planets.Contracts;
    using System.Linq;

    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var astronaut in astronauts)
            {
                while (astronaut.CanBreath && planet.Items.Any())
                {
                    string item = planet.Items.FirstOrDefault();
                    astronaut.Bag.Items.Add(item);
                    planet.Items.Remove(item);
                    astronaut.Breath();
                }

                if (!planet.Items.Any())
                {
                    break;
                }
            }
        }
    }
}
