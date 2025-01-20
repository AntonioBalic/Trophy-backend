using AntonioBalic_Lab_07.Models;
using Microsoft.Data.Sqlite;
using System.Data;
using AntonioBalic_Lab_07.Configuration;
using Microsoft.Extensions.Options;

namespace AntonioBalic_Lab_07.Repositories
{
    public class TrophySqlRepository : ITrophyRepository
    {
        //private readonly string _connectionString = "Data Source=C:\\PI-DIS\\Trophies.db";
        private readonly string? _connectionString;
        public TrophySqlRepository(IOptions<DBConfiguration> configuration)
        {
            _connectionString = configuration.Value.ConnectionString;
        }

        public IEnumerable<Trophy> AddTrophy(Trophy trophy)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();

            command.CommandText =
            @"
                INSERT INTO Trophies (Sportclub, Trophyname, Rank, Year, Sponsors)
                VALUES ($sportclub, $trophyname, $rank, $year, $sponsors)";

            command.Parameters.AddWithValue("$sportclub", trophy.Sportclub);
            command.Parameters.AddWithValue("$trophyname", trophy.Trophyname);
            command.Parameters.AddWithValue("$rank", trophy.Rank);
            command.Parameters.AddWithValue("$year", trophy.Year);
            command.Parameters.AddWithValue("$sponsors", trophy.SponsorsAsString());

            _ = command.ExecuteNonQuery();


            return GetTrophies();
        }

        public IEnumerable<Trophy> DeleteTrophy(long id)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();

            command.CommandText =
            @"
                DELETE FROM Trophies
                WHERE ID = $id";

            command.Parameters.AddWithValue("$id", id);

            _ = command.ExecuteNonQuery();

            return GetTrophies();
        }

        public IEnumerable<Trophy> GetTrophies()
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
            "SELECT ID, Sportclub, Trophyname, Rank, Year, Sponsors FROM Trophies";

            using var reader = command.ExecuteReader();

            var results = new List<Trophy>();
            while (reader.Read())
            {
                var row = new Trophy(
                    id: reader.GetInt64(0),
                    sportclub: reader.GetString(1),
                    trophyname: reader.GetString(2),
                    rank: reader.GetInt32(3),
                    year: reader.GetInt32(4),
                    sponsors: Trophy.SponsorsFromString(reader.GetString(5))
                );

                results.Add(row);
            }

            return results;
        }

        public IEnumerable<Trophy> UpdateTrophy(long id, Trophy trophy)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();

            command.CommandText =
            @"
                UPDATE Trophies
                SET
                    Sportclub = $sportclub,
                    Trophyname = $trophyname,
                    Rank = $rank,
                    Year = $year,
                    Sponsors = $sponsors
                WHERE
                    ID = $id;";

            command.Parameters.AddWithValue("$id", id);
            command.Parameters.AddWithValue("$sportclub", trophy.Sportclub);
            command.Parameters.AddWithValue("$trophyname", trophy.Trophyname);
            command.Parameters.AddWithValue("$rank", trophy.Rank);
            command.Parameters.AddWithValue("$year", trophy.Year);
            command.Parameters.AddWithValue("$sponsors", trophy.SponsorsAsString());

            _ = command.ExecuteNonQuery();

            return GetTrophies();
        }
    }
}