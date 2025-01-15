using System.Reflection;

namespace AntonioBalic_Lab_07.Models
{
    public class Trophy
    {
        public Trophy()
        {
            Id = 0;
        }
        public Trophy(string sportclub, string trophyname, int rank, int year, List<string> sponsors)
        {
            Id = 0;
            Sportclub = sportclub;
            Trophyname = trophyname;
            Rank = rank;
            Year = year;
            Sponsors = sponsors ?? new List<string>();
        }

        public Trophy(long id, string sportclub, string trophyname, int rank, int year, List<string> sponsors)
        {
            Id = id;
            Sportclub = sportclub;
            Trophyname = trophyname;
            Rank = rank;
            Year = year;
            Sponsors = sponsors ?? new List<string>();
        }

        public long Id { get; set; }
        public string Sportclub { get; set; }
        public string Trophyname { get; set; }
        public int Rank { get; set; }
        public int Year { get; set; }
        public List<string> Sponsors { get; set; }

        public string SponsorsAsString() => string.Join(",", Sponsors);

        public static List<string> SponsorsFromString(string sponsors) => sponsors?.Split(',').ToList() ?? new List<string>();
    }
}

