using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace @foreach
{
    class Program
    {
        static void Main(string[] args)
        {
            // MAIN: loop through list of names
            MainChallenge();

            // BONUS: loop with models
            BonusChallenge();

            Console.ReadLine();
        }

        private static void MainChallenge()
        {
            List<string> names = new List<string>
            {
                "John",
                "Doe",
                "Lorem",
                "Ipsum",
                "Dolor",
                "Fake Name"
            };

            foreach (var name in names)
            {
                Console.WriteLine($"Hello {name}");
            }

        }

        private static void BonusChallenge()
        {

        }
    }
}
