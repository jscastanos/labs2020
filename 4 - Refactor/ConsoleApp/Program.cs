using Refactor.Library;
using System;
using Zeck.Common;

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
                actionToTake = UserInput.Get("What action do you want to take (Display, Add, or Quit): ");

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
                            FirstName = UserInput.Get("What is the first name: "),
                            LastName = UserInput.Get("What is the last name: ")
                        };

                        dataAccess.CreateUser(user);
                        Console.WriteLine();
                        break;
                    default:
                        break;
                }
            } while (actionToTake.ToLower() != "quit");
        }
    }
}
