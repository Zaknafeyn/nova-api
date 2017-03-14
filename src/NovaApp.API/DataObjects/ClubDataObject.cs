using Newtonsoft.Json;

namespace NovaApp.API.DataObjects
{
    public class ClubDataObject
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("logoFilename")]
        public string LogoFilename { get; set; }

        [JsonProperty("playersNum")]
        public string PlayersNum { get; set; }

        [JsonProperty("feePayedNum")]
        public string FeePayedNum { get; set; }
    }
}