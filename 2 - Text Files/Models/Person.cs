using CsvHelper.Configuration.Attributes;

namespace _2___Text_Files.Models
{
    class Person
    {
        [Index(0)]
        public string FirstName { get; set; }

        [Index(1)]
        public string LastName { get; set; }

        [Index(2)]
        public decimal Age { get; set; }

        [Index(3)]
        public bool IsAlive { get; set; }

        public Person(string FirstName, string LastName, decimal Age, bool IsAlive)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Age = Age;
            this.IsAlive = IsAlive;
        }
    }
}
