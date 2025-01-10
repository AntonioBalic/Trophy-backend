namespace AntonioBalic_Lab_07.Repositories
{
    public interface ITrophyRepository
    {
        public IEnumerable<Trophy> GetTrophies();
        public IEnumerable<Trophy> AddTrophy(Trophy trophy);
        public IEnumerable<Trophy> DeleteTrophy(Guid id);
    }
}
