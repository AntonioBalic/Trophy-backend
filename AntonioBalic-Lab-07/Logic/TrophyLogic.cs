using AntonioBalic_Lab_07.Models;
using AntonioBalic_Lab_07.Repositories;
using System.Text.RegularExpressions;

namespace AntonioBalic_Lab_07.Logic
{
    public class TrophyLogic : ITrophyLogic
    {
        private readonly ITrophyRepository _trophyRepository;

        public TrophyLogic(ITrophyRepository trophyRepository)
        {
            _trophyRepository = trophyRepository;
        }

        // Methods for validation of each field
        private bool IsSportclubValid(string sportclub)
        {
            var sportclubRegex = @"^[a-zA-Z0-9 '&\-./]+$";
            return (!string.IsNullOrWhiteSpace(sportclub) && Regex.IsMatch(sportclub, sportclubRegex) && sportclub.Length < 40 );
        }

        private bool IsTrophynameValid(string trophyname)
        {
            var trophynameRegex = @"^[a-zA-Z\s]+$";
            return (!string.IsNullOrWhiteSpace(trophyname) && Regex.IsMatch(trophyname, trophynameRegex) && trophyname.Length < 30);
        }

        private bool IsRankValid(int rank)
        {
            return (rank > 0 && rank <32);
        }

        private bool IsYearValid(int year)
        {
            return (year > 1850 && year <= 2025);
        }

        private bool IsSponsorsValid(List<string> sponsors)
        {
            return sponsors.Count <= 15;  //klub moze i ne mora imati sponzora
        }

        // CRUD operations
        public IEnumerable<Trophy> GetTrophies()
        {
            return _trophyRepository.GetTrophies();
        }

        public IEnumerable<Trophy> AddTrophy(Trophy trophy)
        {
            if (!IsSportclubValid(trophy.Sportclub) ||
                !IsTrophynameValid(trophy.Trophyname) ||
                !IsRankValid(trophy.Rank) ||
                !IsYearValid(trophy.Year) ||
                !IsSponsorsValid(trophy.Sponsors))
            {
                return _trophyRepository.GetTrophies();
            }

            _trophyRepository.AddTrophy(trophy);
            return _trophyRepository.GetTrophies();
        }

        public IEnumerable<Trophy> DeleteTrophy(long id)
        {
            if (id <= 0)
            {
                return _trophyRepository.GetTrophies();
            }

            return _trophyRepository.DeleteTrophy(id);
        }

        public IEnumerable<Trophy> UpdateTrophy(long id, Trophy updatedTrophy)
        {
            if (!IsSportclubValid(updatedTrophy.Sportclub) ||
                !IsTrophynameValid(updatedTrophy.Trophyname) ||
                !IsRankValid(updatedTrophy.Rank) ||
                !IsYearValid(updatedTrophy.Year) ||
                !IsSponsorsValid(updatedTrophy.Sponsors))
            {
                return _trophyRepository.GetTrophies();
            }

            return _trophyRepository.UpdateTrophy(id, updatedTrophy);
        }
    }
}
