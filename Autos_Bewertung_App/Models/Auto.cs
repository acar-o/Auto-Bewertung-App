using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Autos_Bewertung_App.Models
{
    public class Auto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("img")]
        public string Image { get; set; }

        [JsonPropertyName("price")]
        public string Price { get; set; }

        [JsonPropertyName("rating")]
        public int[] Bewertung { get; set; }

        public override string ToString() =>
            JsonSerializer.Serialize<Auto>(this);
        
    }
}
