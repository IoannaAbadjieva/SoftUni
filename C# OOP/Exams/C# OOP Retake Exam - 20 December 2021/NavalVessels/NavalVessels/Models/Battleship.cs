namespace NavalVessels.Models
{
    using System.Text;

    using Contracts;

    public class Battleship : Vessel, IBattleship
    {
        private const double InitialArmorThickness = 300;
        private const double MainWeaponCaliberTogglePoints = 40;
        private const double SpeedTogglePoints = 5;


        public Battleship(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, InitialArmorThickness)
        {

        }

        public bool SonarMode { get; private set; }

        public override void RepairVessel()
        {
            this.ArmorThickness = InitialArmorThickness;
        }

        public void ToggleSonarMode()
        {
            if (!this.SonarMode)
            {
                this.MainWeaponCaliber += MainWeaponCaliberTogglePoints;
                this.Speed -= SpeedTogglePoints;
            }
            else
            {
                this.MainWeaponCaliber -= MainWeaponCaliberTogglePoints;
                this.Speed += SpeedTogglePoints;
            }

            this.SonarMode = !this.SonarMode;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine(base.ToString())
                .AppendLine($" *Sonar mode: {(this.SonarMode ? "ON" : "OFF")}");

            return sb.ToString().Trim();
        }
    }
}
