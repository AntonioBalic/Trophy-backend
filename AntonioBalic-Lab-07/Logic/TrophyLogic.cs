using AntonioBalic_Lab_07.Models;
using AntonioBalic_Lab_07.Repositories;
using AntonioBalic_Lab_07.Exceptions;
using AntonioBalic_Lab_07.Configuration;

using System.Text.RegularExpressions;
using Microsoft.Extensions.Options;


namespace AntonioBalic_Lab_07.Logic
{
    public class TrophyLogic : ITrophyLogic
    {
        private readonly ITrophyRepository _trophyRepository;
        private readonly ValidationConfiguration _validationConfiguration;

        public TrophyLogic(ITrophyRepository trophyRepository, IOptions<ValidationConfiguration> validationConfiguration)
        {
            _trophyRepository = trophyRepository;
            _validationConfiguration = validationConfiguration.Value;
        }

        // Methods for validation of each field
        private bool IsSportclubValid(string sportclub)
        {
            var sportclubRegex = @"^[a-zA-Z0-9 '&\-./]+$";
            if (string.IsNullOrWhiteSpace(sportclub))
            {
                throw new TrophyAppException_UserError("Club name cannot be empty.");
            }
            else if (!Regex.IsMatch(sportclub, sportclubRegex))
            {
                throw new TrophyAppException_UserError("Club name contains forbidden character.");
            }
            else if(sportclub.Length > _validationConfiguration.MaxSportclubLength)
            {
                throw new TrophyAppException_UserError("Club name is too long.");
            }

            return true;
        }

        private bool IsTrophynameValid(string trophyname)
        {
            var trophynameRegex = @"^[a-zA-Z\s]+$";
            if (string.IsNullOrWhiteSpace(trophyname))
            {
                throw new TrophyAppException_UserError("Trophy name cannot be empty.");
            }
            else if ( !Regex.IsMatch(trophyname, trophynameRegex))
            {
                throw new TrophyAppException_UserError("Trophy name contains forbidden character.");
            }
            else if (trophyname.Length > _validationConfiguration.MaxTrophynameLength)
            {
                throw new TrophyAppException_UserError("Trophy name is too long.");
            }

            return true;
        }

        private bool IsRankValid(int rank)
        {
            if (rank <= 0 || rank > _validationConfiguration.MaxRank)
            {
                throw new TrophyAppException_UserError($"Club's rank cannot be negative or exceed {_validationConfiguration.MaxRank}.");
            }
            return true;
        }

        private bool IsYearValid(int year)
        {
            if (year < 1850 || year > _validationConfiguration.MaxYear)
            {
                throw new TrophyAppException_UserError($"Year must be between 1850 and {_validationConfiguration.MaxYear}.");
            }
            return true;
        }

        private bool IsSponsorsValid(List<string> sponsors)
        {
            if (sponsors.Count > _validationConfiguration.MaxSponsorsCount) //Club isn't required to have a sponsor
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
