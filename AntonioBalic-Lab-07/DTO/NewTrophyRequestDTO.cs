using System.Text.Json.Serialization;
using AntonioBalic_Lab_07.Models;

namespace AntonioBalic_Lab_07.DTO
{
    public class NewTrophyRequestDTO
    {
        [JsonPropertyName("sportclub")]
        public string? Sportclub { get; set; }
        [JsonPropertyName("trophyname")]
        public string? Trophyname { get; set; }
        [JsonPropertyName("rank")]
        public int Rank { get; set; }
        [JsonPropertyName("year")]
        public int Year { get; set; }
        [JsonPropertyName("sponsors")]
        public string? Sponsors { get; set; }

        public Trophy ToModel()
        {
            return new Trophy
            (
                this.Sportclub,
                this.Trophyname,
                this.Rank,
                this.Year,
                Trophy.SponsorsFromString(this.Sponsors)
            );
        }
        public static NewTrophyRequestDTO FromModel(Trophy model)
        {
            return new NewTrophyRequestDTO
            {
                Sportclub = model.Sportclub,
                Trophyname = model.Trophyname,
                Rank = model.Rank,
                Year = model.Year,
                Sponsors = model.SponsorsAsString(),
            };
        }
    }
}