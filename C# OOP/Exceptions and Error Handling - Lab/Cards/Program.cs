using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.Cards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Card> cards = new List<Card>();

            string[] input = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in input)
            {
                try
                {
                    string face = item.Split()[0];
                    string suit = item.Split()[1];

                    Card card = new Card(face,suit);
                    cards.Add(card);
                }
                catch (ArgumentException ae)
                {

                    Console.WriteLine(ae.Message);
                }
                catch
                { 
                    throw;
                }
                
            }

            Console.WriteLine(String.Join(" ", cards));
        }
    }

    internal class Card
    {

        private string face;
        private string suit;

        public Card(string face,string suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public string Face
        {
            get { return this.face; }

            private set
            {
                if (!Helper.faces.Contains(value))
                {
                    throw new ArgumentException("Invalid card!");
                }

                this.face = value;
            }
        }

        public string Suit
        {
            get { return this.suit; }

            private set 
            {

                if (!Helper.suits.ContainsKey(value))
                {
                    throw new ArgumentException("Invalid card!");
                }

                this.suit = Helper.suits[value]; 
            }
        }

        public override string ToString()
        {
            return $"[{this.Face}{this.Suit}]";
        }

    }

    internal class Helper
    {

        public static string[] faces = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

        public static Dictionary<string, string> suits = new Dictionary<string, string>()
        {
            { "S", "\u2660" },
            { "H", "\u2665" },
            { "D", "\u2666" },
            { "C", "\u2663" },
        };
    }




}
