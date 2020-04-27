using Refactor.Library;
using System;
using System.Data;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        public static DataAccessLayer dataAccess = new DataAccessLayer();

        static void Main()
        {
            string actionToTake = "";

            do
            {
                actionToTake = GetUserInput("What action do you want to take (Display, Add, or Quit): ");

                switch (actionToTake.ToLower())
                {
                    case "display":
                        var records = dataAccess.GetUser();
                        Console.WriteLine();
                        records.ForEach(x => Console.WriteLine(x.FullName));
                        Console.WriteLine();
                        break;

                    case "add":
                        var user = new
                        {
                            FirstName = GetUserInput("What is the first name: "),
                            LastName = GetUserInput("What is the last name: ")
                        };

                        dataAccess.CreateUser(user);
                        Console.WriteLine();
                        break;
                    default:
                        break;
                }
            } while (actionToTake.ToLower() != "quit");
        }

        static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
    }
}
