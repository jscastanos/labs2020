using _5___Config_File.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using Zeck.Common;

namespace _5___Config_File
{
    internal static class Program
    {
        public static readonly List<Command> appCommands = new List<Command>()
        {
                new Command("Add New", "!a"),
                new Command("Print", "!p"),
                new Command("Return", "!r")
        };

        public static readonly List<Command> mainCommands = new List<Command>()
        {
                new Command("App Settings", "!a"),
                new Command("Connection Strings", "!c")
        };

        public static readonly Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        private static void Main()
        {
            Console.WriteLine("Config File Challenge.");
            Command.DisplayCommand(mainCommands);

            //execute
            switch (Command.CheckCommand(mainCommands, "Choose"))
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

        private static void AppSettings()
        {
            Command.DisplayCommand(appCommands);

            var appSettings = ConfigurationManager.AppSettings;

            switch (Command.CheckCommand(appCommands, "Select Mode"))
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

        private static void ConnectionSettings()
        {
            Command.DisplayCommand(appCommands);

            ConnectionStringSettingsCollection connectionSettings = ConfigurationManager.ConnectionStrings;

            switch (Command.CheckCommand(appCommands, "Select Mode"))
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