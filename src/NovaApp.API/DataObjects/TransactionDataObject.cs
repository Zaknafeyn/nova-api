using Newtonsoft.Json;

namespace NovaApp.API.DataObjects
{
    public class TransactionDataObject
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("playerID")]
        public int PlayerId { get; set; }

        [JsonProperty("sum")]
        public double Sum { get; set; }

        [JsonProperty("isFee")]
        public string IsFee { get; set; }

        [JsonProperty("feeYear")]
        public string FeeYear { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }
    }
}