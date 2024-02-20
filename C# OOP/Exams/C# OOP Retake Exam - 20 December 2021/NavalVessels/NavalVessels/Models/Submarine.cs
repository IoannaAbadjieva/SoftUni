namespace NavalVessels.Models
{
    using System.Text;

    using Contracts;

    public class Submarine : Vessel, ISubmarine
    {
        private const double InitialArmorThickness = 200;
        private const double MainWeaponCaliberTogglePoints = 40;
        private const double SpeedTogglePoints = 4;

        public Submarine(string name, double mainWeaponCaliber, double speed)
           : base(name, mainWeaponCaliber, speed, InitialArmorThickness)
        {

        }

        public bool SubmergeMode { get; private set; }

        public override void RepairVessel()
        {
            this.ArmorThickness = InitialArmorThickness;
        }

        public void ToggleSubmergeMode()
        {
            if (!this.SubmergeMode)
            {
                this.MainWeaponCaliber += MainWeaponCaliberTogglePoints;
                this.Speed -= SpeedTogglePoints;
            }
            else
            {
                this.MainWeaponCaliber -= MainWeaponCaliberTogglePoints;
                this.Speed += SpeedTogglePoints;
            }

            this.SubmergeMode = !this.SubmergeMode;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine(base.ToString())
                .AppendLine($" *Submerge mode: {(this.SubmergeMode ? "ON" : "OFF")}");

            return sb.ToString().Trim();
        }
    }
}
