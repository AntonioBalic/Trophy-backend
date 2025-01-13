using AntonioBalic_Lab_07.Models;
namespace AntonioBalic_Lab_07.Logic
{
    public interface ITrophyLogic
    {
        public IEnumerable<Trophy> GetTrophies();

        public IEnumerable<Trophy> AddTrophy(Trophy trophy);

        //public IEnumerable<Trophy> DeleteTrophy(long id);

        //public IEnumerable<Trophy> UpdateTrophy(long id, Trophy trophy);
    }
}