namespace AntonioBalic_Lab_07
{
    public class Trophy
    {
        public Trophy(string sportclub, string trophyname, int year, string location)
        {
            Id = Guid.NewGuid();
            Sportclub = sportclub ;
            Trophyname = trophyname;
            Year = year;
            Location = location;
        }
        public Guid Id { get; set; }
        public string Sportclub { get; set; }
        public string Trophyname { get; set; }
        public int Year { get; set; }
        public string Location { get; set; }
    }
}
