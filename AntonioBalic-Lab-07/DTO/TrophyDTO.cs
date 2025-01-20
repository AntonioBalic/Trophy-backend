using System.Text.Json.Serialization;
using AntonioBalic_Lab_07.Models;

namespace AntonioBalic_Lab_07.DTO
{
    public class TrophyDTO
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
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


        // Added two methods for converting Model <-> DTO
        public Trophy ToModel()
        {
            return new Trophy
            (
                 this.Id,
                 this.Sportclub,
                 this.Trophyname,
                 this.Rank,
                 this.Year,
                 Trophy.SponsorsFromString(this.Sponsors)
            );
        }
        public static TrophyDTO FromModel(Trophy model)
        {
            return new TrophyDTO
            {
                Id = model.Id,
                Sportclub = model.Sportclub,
                Trophyname = model.Trophyname,
                Rank = model.Rank,
                Year = model.Year,
                Sponsors = model.SponsorsAsString(),
            };
        }
    }
}