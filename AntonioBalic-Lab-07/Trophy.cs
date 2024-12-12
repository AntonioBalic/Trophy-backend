namespace AntonioBalic_Lab_07
{
    public class Trophy
    {
        public Trophy(string sportclub, string trophyname, int rank, int year, List<string> sponsors)
        {
            Id = Guid.NewGuid();
            Sportclub = sportclub ;
            Trophyname = trophyname;
            Rank = rank;
            Year = year;
            Sponsors = sponsors ?? new List<string>();
        }
        public Guid Id { get; set; }
        public string Sportclub { get; set; }
        public string Trophyname { get; set; }
        public int Rank { get; set; }
        public int Year { get; set; }
        public List<string> Sponsors { get; set; }
    }
}
