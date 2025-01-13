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

        public IEnumerable<Trophy> GetTrophies()
        {
            return _trophyRepository.GetTrophies();
        }

        public IEnumerable<Trophy> AddTrophy(Trophy trophy)
        {
            _trophyRepository.AddTrophy(trophy);
            return _trophyRepository.GetTrophies();
        }

    }
}
