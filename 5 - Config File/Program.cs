using _5___Config_File.Model;
using Zeck.Common;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;

namespace _5___Config_File
{
    class Program
    {
        public static string userCommand;
        public static List<Command> appCommands = new List<Command>();
        public static List<Command> mainCommands = new List<Command>();
        public static bool DidInitialize = false;
        public static Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

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
            Command.DisplayCommand(mainCommands);
            userCommand = Command.CheckCommand(mainCommands, "Choose");

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
            Command.DisplayCommand(appCommands);
            userCommand = Command.CheckCommand(appCommands, "Select Mode");

            var appSettings = ConfigurationManager.AppSettings;

            switch (userCommand)
            {
                case "!a":
                    bool DidExist = false;

                    var newSetting = new
                    {
                        key = UserInput.Get("Setting Name"),
                        value = UserInput.Get("Setting Value")
                    };

                    foreach (string key in appSettings.AllKeys)
                        if (key == newSetting.key && appSettings[key] == newSetting.value)
                        {
                            DidExist = true;
                            break;
                        }

                    if (!DidExist)
                    {
                        config.AppSettings.Settings.Add(newSetting.key, newSetting.value);
                        UpdateConfiguration("appSettings", "Successfully Added new AppSettings");
                    }
                    else
                        Console.WriteLine("\nCan't Add, AppSetting already exist");
                    break;

                case "!p":
                    Console.WriteLine("======================================================================");
                    if (ConfigurationManager.AppSettings.Count > 0)
                        foreach (var key in appSettings.AllKeys)
                            Console.WriteLine($"- {key} : { appSettings[key] }");
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
            Command.DisplayCommand(appCommands);
            userCommand = Command.CheckCommand(appCommands, "Select Mode");

            ConnectionStringSettingsCollection connectionSettings = ConfigurationManager.ConnectionStrings;

            switch (userCommand)
            {
                case "!a":
                    bool DidExist = false;

                    ConnectionStringSettings newConnection = new ConnectionStringSettings()
                    {
                        Name = UserInput.Get("Connection Name"),
                        ConnectionString = UserInput.Get("Connection String"),
                        ProviderName = UserInput.Get("Connection Provider")
                    };

                    foreach (ConnectionStringSettings key in connectionSettings)
                        if (key.Equals(newConnection))
                        {
                            DidExist = true;
                            break;
                        }

                    if (!DidExist)
                    {
                        config.ConnectionStrings.ConnectionStrings.Add(newConnection);
                        UpdateConfiguration("configSections", "Successfully Added new Connection");
                    }
                    else
                        Console.WriteLine("Connection already exist");

                    break;

                case "!p":
                    Console.WriteLine("======================================================================");
                    if (connectionSettings.Count > 0)
                        foreach (ConnectionStringSettings key in connectionSettings)
                            Console.WriteLine($"- {key.Name} : {key.ConnectionString} - {key.ProviderName}");
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

        public static void UpdateConfiguration(string sectionName, string message)
        {
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(sectionName);
            Console.WriteLine($"\n{message}");
        }
    }
}
