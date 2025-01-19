using AntonioBalic_Lab_07.Models;
using AntonioBalic_Lab_07.Repositories;
using System.Text.RegularExpressions;
using AntonioBalic_Lab_07.Exceptions;

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
            if (!Regex.IsMatch(sportclub, sportclubRegex))
            {
                throw new TrophyAppException_UserError("Club name contains forbidden character.");
            }
            else if(sportclub.Length > 40)
            {
                throw new TrophyAppException_UserError("Club name is too long.");
            }
            else if(string.IsNullOrWhiteSpace(sportclub))
            {
                throw new TrophyAppException_UserError("Club name cannot be empty.");
            }
            return true;
        }

        private bool IsTrophynameValid(string trophyname)
        {
            var trophynameRegex = @"^[a-zA-Z\s]+$";
            if ( !Regex.IsMatch(trophyname, trophynameRegex))
            {
                throw new TrophyAppException_UserError("Trophy name contains forbidden character.");
            }
            else if (trophyname.Length > 30)
            {
                throw new TrophyAppException_UserError("Trophy name is too long.");
            }
            else if(string.IsNullOrWhiteSpace(trophyname))
            {
                throw new TrophyAppException_UserError("Trophy name cannot be empty.");
            }
            return true;
        }

        private bool IsRankValid(int rank)
        {
            if (rank < 0 || rank > 32)
            {
                throw new TrophyAppException_UserError("Club's rank cannot exceed 32.");
            }
            return true;
        }

        private bool IsYearValid(int year)
        {
            if (year < 1850 || year > 2025)
            {
                throw new TrophyAppException_UserError("Year must be between 1850 and 2025.");
            }
            return true;
        }

        private bool IsSponsorsValid(List<string> sponsors)
        {
            if (sponsors.Count > 15) //klub moze i ne mora imati sponzora
            {
                throw new TrophyAppException_UserError("A club cannot have more than 15 sponsors.");
            }
            return true;
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
