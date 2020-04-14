namespace _1___Foreach.Models
{
    class Person
    {
        public string FullName { get; set; }
        public string Profession { get; set; }
        public double Bounty { get; set; }
        public string Ephithet { get; set; }

        public Person(string FullName, string Profession, double Bounty, string Ephithet)
        {
            this.FullName = FullName;
            this.Profession = Profession;
            this.Bounty = Bounty;
            this.Ephithet = Ephithet;
        }
    }
}
