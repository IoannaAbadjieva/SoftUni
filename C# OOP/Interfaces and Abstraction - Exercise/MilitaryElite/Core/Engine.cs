namespace MilitaryElite.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using MilitaryElite.IO.Contracts;
    using MilitaryElite.Models;
    using MilitaryElite.Models.Enums;
    using Models.Contracts;


    public class Engine : IEngine
    {
        private ICollection<ISoldier> soldiers;
        private IReader reader;
        private IWriter writer;

        private Engine()
        {
            this.soldiers = new HashSet<ISoldier>();
        }

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {

        }

        private void CreateSoldiers()
        {
            string command;

            while ((command = this.reader.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split(' ');

                string type = cmdArgs[0];
                int id = int.Parse(cmdArgs[1]);
                string firstName = cmdArgs[2];
                string lastName = cmdArgs[3];

                ISoldier soldier;
                if (type == "Private")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    soldier = new Private(id, firstName, lastName, salary);
                }
                else if (type == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    soldier = new LieutenantGeneral(id, firstName, lastName, salary, GetPrivates(cmdArgs));

                }
                else if (type == "Engineer")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    string corpsName = cmdArgs[5];

                    if (!Enum.TryParse(corpsName, false, out Corps corps))
                    {
                        continue;
                    }

                    soldier = new Engineer(id, firstName, lastName, salary, corps, GetRepairs(cmdArgs))
                }
                else if (type == "Commando")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);
                }
                else if (type == "Spy")
                {
                    int codeNumber = int.Parse(cmdArgs[4]);
                }
            }
        }

        private ICollection<IRepair> GetRepairs(string[] cmdArgs)
        {
            ICollection<IRepair> repairs = new HashSet<IRepair>();

            string[] repairsArgs = cmdArgs.Skip(6).ToArray();

            for (int i = 0; i < repairsArgs.Length; i += 2)
            {
IRepair repair = new Rep(repairsArgs[i], int.Parse(repairsArgs[i+1]));
            }
        }

        private ICollection<IPrivate> GetPrivates(string[] cmdArgs)
        {
            ICollection<IPrivate> privates = new HashSet<IPrivate>();

            int[] ids = cmdArgs.Skip(5).Select(int.Parse).ToArray();

            foreach (int id in ids)
            {
                IPrivate @private = soldiers.FirstOrDefault(s => s.Id == id) as IPrivate;
                if (@private != null)
                {
                    privates.Add(@private);
                }
            }

            return privates;
        }
    }
}
