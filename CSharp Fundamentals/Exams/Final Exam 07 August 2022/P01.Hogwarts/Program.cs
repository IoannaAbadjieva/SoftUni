using System;

namespace P01.Hogwarts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string spell = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "Abracadabra")
            {
                string[] cmdArgs = command
                    .Split(' ',StringSplitOptions.RemoveEmptyEntries);

                string cmdType = cmdArgs[0];

                if (cmdType == "Abjuration")
                {
                    spell = spell.ToUpper();
                    Console.WriteLine(spell);
                }
                else if (cmdType == "Necromancy")
                {
                    spell = spell.ToLower();
                    Console.WriteLine(spell);
                }
                else if (cmdType == "Illusion")
                {
                    int index = int.Parse(cmdArgs[1]);
                    string letter = cmdArgs[2];
                    if (!IsIndexValid(spell, index))
                    {
                        Console.WriteLine("The spell was too weak.");
                        continue;
                    }
                    spell = spell.Remove(index, 1);
                    spell = spell.Insert(index, letter);
                    Console.WriteLine("Done!");
                }
                else if (cmdType == "Divination")
                {
                    string firstSubstring = cmdArgs[1];
                    string secondSubstring = cmdArgs[2];
                    if (!spell.Contains(firstSubstring))
                    {
                        continue;
                    }
                    spell = spell.Replace(firstSubstring, secondSubstring);
                    Console.WriteLine(spell);
                }
                else if (cmdType == "Alteration")
                {
                    string substring = cmdArgs[1];
                    if (!spell.Contains(substring))
                    {
                        continue;
                    }

                    int startIndex = spell.IndexOf(substring);
                    spell = spell.Remove(startIndex, substring.Length);
                    Console.WriteLine(spell);
                }
                else
                {
                    Console.WriteLine("The spell did not work!");
                }
            }
        }
        static bool IsIndexValid(string spell,int index)
        {
            return index >= 0 && index < spell.Length;
        }
    }
}
