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
                year: 2023,
                location: "Rijeka"
            ));
            Trophy.Add(new Trophy(
                sportclub: "Hajduk",
                trophyname: "Prva liga",
                year: 2025,
                location: "Sibenik"
            ));
        }
    }
}
