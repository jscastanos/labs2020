using _1___Foreach.Models;
using System;
using System.Collections.Generic;

namespace _1___Foreach
{
    class Program
    {
        static void Main()
        {
            // MAIN: 
            MainChallenge();

            // BONUS: 
            BonusChallenge();

            Console.ReadLine();
        }

        private static void MainChallenge()
        {
            List<string> names = new List<string>
            {
                "Monkey D. Luffy",
                "Roronoa Zoro",
                "Nami",
                "Usopp",
                "Vinsmoke Sanji",
                "Tony Tony Chopper",
                "Nico Robin",
                "Franky",
                "Brook",
                "Jinbe"
            };

            Console.WriteLine("MAIN: Foreach with Regular List \n");

            foreach (var name in names)
            {
                Console.WriteLine($"Hello {name}");
            }

            Console.WriteLine("\n");
        }

        private static void BonusChallenge()
        {
            List<Person> names = new List<Person> {
                new Person("Monkey D. Luffy", "Captian", 1_500_000_000, "Straw Hat"),
                new Person("Roronoa Zoro", "Combatant", 320_000_000, "Pirate Hunter"),
                new Person("Nami", "Navigator", 66_000_000, "Cat Burglar"),
                new Person("Usopp", "Sniper", 200_000_000, "Sogeking"),
                new Person("Vinsmoke Sanji", "Cook", 330_000_000, "Black Leg"),
                new Person("Tony Tony Chopper", "Doctor", 100, "Cotton-Candy Lover"),
                new Person("Nico Robin", "Archeologist", 130_000_000, "Devil Child"),
                new Person("Franky", "Shipwright", 94_000_000, "Cyborg"),
                new Person("Brook", "Musician", 83_000_000, "Soul King"),
                new Person("Jinbe", "Helmsman", 438_000_000, "Knight of the Sea")
            };



            Console.WriteLine("BONUS: Foreach using Models \n");
            Console.WriteLine("Full Name - Profession - Ephithet - Bounty (Model Properties)");
            Console.WriteLine("===================================================");

            foreach (var name in names)
            {
                Console.WriteLine($"{name.FullName} - {name.Profession}  - \"{name.Ephithet}\" - {name.Bounty}");
            }

            Console.WriteLine("\n");

        }
    }
}
