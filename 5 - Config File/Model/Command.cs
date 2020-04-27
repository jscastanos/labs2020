using Zeck.Common;
using System;
using System.Collections.Generic;

namespace _5___Config_File.Model
{
    public class Command
    {
        public string Name { get; set; }
        public string Key { get; set; }

        public Command(string name, string key)
        {
            this.Name = name;
            this.Key = key;
        }

        public static string CheckCommand(List<Command> commands, string commandQuestion)
        {
            bool IsCommandValid = false;
            string userCommand;

            while (true)
            {
                userCommand = UserInput.Get(commandQuestion);
                Console.WriteLine();

                foreach (var command in commands)
                    if (command.Key.Equals(userCommand))
                    {
                        IsCommandValid = true;
                        break;
                    }

                if (!IsCommandValid)
                    Console.WriteLine($"Can't recognized \"{userCommand}\" as command\n");
                else
                    return userCommand;
            }
        }

        public static void DisplayCommand(List<Command> commands)
        {
            foreach (var command in commands)
                Console.WriteLine($"{command.Name} : {command.Key}");

            Console.WriteLine("");
        }
    }
}