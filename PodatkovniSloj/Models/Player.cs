using Newtonsoft.Json;
using System.Drawing;

namespace PodatkovniSloj.Models
{
    public class Player
    {
        public Player()
        {

        }

        public Player(string name, bool captain, string shirtNumber, string position)
        {
            Name = name;
            Captain = captain;
            ShirtNumber = shirtNumber;
            Position = position;
        }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("captain")]
        public bool Captain { get; set; }

        [JsonProperty("shirt_number")]
        public string ShirtNumber { get; set; }

        [JsonProperty("position")]
        public string Position { get; set; }

        public bool Najdrazi { get; set; }

        public string SlikaIgraca { get; set; }

        public override string ToString()
        {
            return $"{Name}, {Position}";
        }
    }
}
