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
    }

}
