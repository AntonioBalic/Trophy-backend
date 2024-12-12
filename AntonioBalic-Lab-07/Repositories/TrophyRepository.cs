namespace AntonioBalic_Lab_07.Repositories
{
    public class TrophyRepository
    {
        public List<Trophy> Trophy;
        public TrophyRepository()
        {
            Trophy = new List<Trophy>();

            Trophy.Add(new Trophy(
                sportclub: "Hajduk",
                trophyname: "Rabuzinovo Sunce",
                rank: 1,
                year: 2023,
                sponsors: new List<string> { "Sponsor A", "Sponsor B" }
            ));
            Trophy.Add(new Trophy(
                sportclub: "Barcelona",
                trophyname: "La Liga",
                rank: 1,
                year: 2025,
                sponsors: new List<string> { "Sponsor A", "Sponsor B" }
            ));
        }
    }
}
