﻿using AntonioBalic_Lab_07.Models;
using Microsoft.AspNetCore.Mvc;

namespace AntonioBalic_Lab_07.Repositories
{
    public class TrophyRepository : ITrophyRepository
    {
        private List<Trophy> Trophy { get; set; }

        public IEnumerable<Trophy> GetTrophies()
        {
            return Trophy;
        }

        public IEnumerable<Trophy> AddTrophy([FromBody] Trophy trophy)
        {
            Trophy.Add(trophy);
            return Trophy;
        }

        public IEnumerable<Trophy> DeleteTrophy([FromRoute] long id)
        {
            Trophy = Trophy.Where(x => x.Id != id).ToList();
            return Trophy;
        }

        public IEnumerable<Trophy> UpdateTrophy([FromRoute] long id, [FromBody] Trophy updatedTrophy)
        {
            var oldTrophy = Trophy.FirstOrDefault(x => x.Id == id);

            if (oldTrophy == null)
            {
                return Trophy;
            }
            else
            {
                oldTrophy.Sportclub = updatedTrophy.Sportclub;
                oldTrophy.Trophyname = updatedTrophy.Trophyname;
                oldTrophy.Rank = updatedTrophy.Rank;
                oldTrophy.Year = updatedTrophy.Year;
                oldTrophy.Sponsors = updatedTrophy.Sponsors;

                return Trophy;
            }
        }

        public TrophyRepository()
        {
            Trophy = new List<Trophy>();

            Trophy.Add(new Trophy(
                sportclub: "Hajduk",
                trophyname: "Rabuzinovo Sunce",
                rank: 1,
                year: 2023,
                sponsors: new List<string> { "Supersport"}
            ));
            Trophy.Add(new Trophy(
                sportclub: "Barcelona",
                trophyname: "La Liga",
                rank: 1,
                year: 2025,
                sponsors: new List<string> { "EA Sports", "Microsoft" }
            ));
        }
    }
}
