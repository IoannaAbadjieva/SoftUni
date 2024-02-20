namespace NavalVessels.Core
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Models;
    using Models.Contracts;
    using NavalVessels.Utilities.Messages;
    using Repositories;
    using Repositories.Contracts;


    public class Controller : IController
    {
        private readonly IRepository<IVessel> vessels;
        private readonly ICollection<ICaptain> captains;

        public Controller()
        {
            this.vessels = new VesselRepository();
            this.captains = new HashSet<ICaptain>();
        }

        public string HireCaptain(string fullName)
        {
            ICaptain captain = new Captain(fullName);

            if (this.captains.Any(c => c.FullName == fullName))
            {
                return string.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
            }

            this.captains.Add(captain);
            return string.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            IVessel vessel = this.vessels.FindByName(name);

            if (vessel != null)
            {
                return string.Format(OutputMessages.VesselIsAlreadyManufactured, vessel.GetType().Name, name);
            }

            if (vesselType == nameof(Battleship))
            {
                vessel = new Battleship(name, mainWeaponCaliber, speed);
            }
            else if (vesselType == nameof(Submarine))
            {
                vessel = new Submarine(name, mainWeaponCaliber, speed);
            }
            else
            {
                return OutputMessages.InvalidVesselType;
            }

            this.vessels.Add(vessel);
            return string.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            ICaptain selectedCaptain = this.captains.FirstOrDefault(c => c.FullName == selectedCaptainName);

            if (selectedCaptain == null)
            {
                return string.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
            }

            IVessel selectedVessel = this.vessels.FindByName(selectedVesselName);

            if (selectedVessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, selectedVesselName);
            }

            if (selectedVessel.Captain != null)
            {
                return string.Format(OutputMessages.VesselOccupied, selectedVesselName);
            }

            selectedVessel.Captain = selectedCaptain;
            selectedCaptain.AddVessel(selectedVessel);

            return string.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);
        }

        public string CaptainReport(string captainFullName)
        {
            ICaptain captain = this.captains.First(c => c.FullName == captainFullName);

            return captain.Report();
        }

        public string VesselReport(string vesselName)
        {
            IVessel vessel = this.vessels.FindByName(vesselName);

            return vessel.ToString();
        }

        public string ToggleSpecialMode(string vesselName)
        {
            IVessel vessel = this.vessels.FindByName(vesselName);

            if (vessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, vesselName);
            }

            if (vessel.GetType() == typeof(Battleship))
            {
                Battleship battleship = vessel as Battleship;
                battleship.ToggleSonarMode();

                return string.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
            }
            else
            {
                Submarine submarine = vessel as Submarine;
                submarine.ToggleSubmergeMode();

                return string.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);
            }
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            IVessel attackingVessel = this.vessels.FindByName(attackingVesselName);

            if (attackingVessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, attackingVesselName);
            }

            IVessel defendingVessel = this.vessels.FindByName(defendingVesselName);

            if (defendingVessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, defendingVesselName);
            }

            if (attackingVessel.ArmorThickness == 0)
            {
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);
            }

            if (defendingVessel.ArmorThickness == 0)
            {
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);
            }

            attackingVessel.Attack(defendingVessel);

            return string.Format(OutputMessages.SuccessfullyAttackVessel,
                defendingVesselName, attackingVesselName, defendingVessel.ArmorThickness);
        }

        public string ServiceVessel(string vesselName)
        {
            IVessel vessel = this.vessels.FindByName(vesselName);

            if (vessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, vesselName);
            }

            vessel.RepairVessel();

            return string.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
        }


    }
}
