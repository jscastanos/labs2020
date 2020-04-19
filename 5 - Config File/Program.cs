using _5___Config_File.Model;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace _5___Config_File
{
    class Program
    {

        public static string userCommand;
        public static List<Command> appCommands = new List<Command>();
        public static List<Command> mainCommands = new List<Command>();
        public static bool DidInitialize = false;


        static void Main()
        {
            //init commands
            if (!DidInitialize)
            {
                mainCommands.Add(new Command("App Settings", "!a"));
                mainCommands.Add(new Command("Connection Strings", "!c"));
                appCommands.Add(new Command("Add New", "!a"));
                appCommands.Add(new Command("Print", "!p"));
                appCommands.Add(new Command("Return", "!r"));
                DidInitialize = true;
            }

            Console.WriteLine("Config File Challenge.");
            DisplayCommand(mainCommands);

            CheckCommand(mainCommands, "Choose: ");

            //execute
            switch (userCommand)
            {
                case "!a":
                    AppSettings();
                    break;

                case "!c":
                    ConnectionSettings();
                    break;
            }

            /**
             * NOTE: I'm trying to make it as DRY as possible.
             * So I'll refactor this once I can find a better way to execute this
             * **/

            Console.ReadLine();
        }

        static void AppSettings()
        {
            string[] newSettings = new string[2];

            DisplayCommand(appCommands);
            CheckCommand(appCommands, "Select Mode: ");

            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var appSettings = ConfigurationManager.AppSettings;

            switch (userCommand)
            {
                case "!a":
                    bool DidExist = false;

                    Console.Write("Setting Name: ");
                    newSettings[0] = Console.ReadLine();

                    Console.Write("Setting Value: ");
                    newSettings[1] = Console.ReadLine();

                    foreach (var key in appSettings.AllKeys)
                        if (key == newSettings[0] && appSettings[key] == newSettings[1])
                        {
                            DidExist = true;
                            break;
                        }

                    if (!DidExist)
                    {
                        config.AppSettings.Settings.Add(newSettings[0], newSettings[1]);
                        config.Save(ConfigurationSaveMode.Modified);
                        ConfigurationManager.RefreshSection("appSettings");
                        Console.WriteLine("\nSuccessfully Added new AppSettings");
                    }
                    else
                        Console.WriteLine("\nCan't Add, AppSetting already exist");
                    break;

                case "!p":
                    Console.WriteLine("======================================================================");
                    if (ConfigurationManager.AppSettings.Count > 0)
                        foreach (var key in appSettings.AllKeys)
                            Console.WriteLine($"- {key} : {appSettings[key]}");
                    else
                        Console.WriteLine("App doesn't have settings.");
                    Console.WriteLine("======================================================================");
                    break;

                case "!r":
                    Main();
                    break;
            }


            Console.WriteLine();
            AppSettings();
        }

        static void ConnectionSettings()
        {
            string[] newSettings = new string[3];

            DisplayCommand(appCommands);
            CheckCommand(appCommands, "Select Mode: ");

            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionSettings = ConfigurationManager.ConnectionStrings;

            switch (userCommand)
            {
                case "!a":
                    bool DidExist = false;

                    Console.Write("Connection Name: ");
                    newSettings[0] = Console.ReadLine();

                    Console.Write("Connection String: ");
                    newSettings[1] = Console.ReadLine();

                    Console.Write("Connection Provider: ");
                    newSettings[2] = Console.ReadLine();

                    foreach (ConnectionStringSettings key in connectionSettings)
                        if (key.Name == newSettings[0] && key.ConnectionString == newSettings[1] && key.ProviderName == newSettings[2])
                        {
                            DidExist = true;
                            break;
                        }


                    if (!DidExist)
                    {
                        config.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings
                        {
                            Name = newSettings[0],
                            ConnectionString = newSettings[1],
                            ProviderName = newSettings[2]
                        });

                        config.Save(ConfigurationSaveMode.Modified);
                        ConfigurationManager.RefreshSection("configSections");
                        Console.WriteLine("Successfully Added new Connection");
                    }
                    else
                        Console.WriteLine("Connection already exist");

                    break;

                case "!p":
                    Console.WriteLine("======================================================================");
                    if (connectionSettings.Count > 0)
                        foreach (ConnectionStringSettings key in connectionSettings)
                            Console.WriteLine($"- {key.Name} : {key.ConnectionString}");
                    else
                        Console.WriteLine("App is not connected to any server");

                    Console.WriteLine("======================================================================");
                    break;

                case "!r":
                    Main();
                    break;
            }


            Console.WriteLine();
            ConnectionSettings();
        }

        static void CheckCommand(List<Command> commands, string commandQuestion)
        {
            bool IsCommandValid = false;
            while (true)
            {
                Console.Write(commandQuestion);

                userCommand = Console.ReadLine();
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
                    break;
            }
        }

        static void DisplayCommand(List<Command> commands)
        {
            foreach (var command in commands)
                Console.WriteLine($"{command.Name} : {command.Key}");

            Console.WriteLine("");
        }


    }
}
