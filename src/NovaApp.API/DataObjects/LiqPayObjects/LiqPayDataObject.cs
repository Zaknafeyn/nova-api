using System;
using Newtonsoft.Json;

namespace NovaApp.API.DataObjects.LiqPayObjects
{
    public class LiqPayDataObject
    {
        [JsonProperty("version")]
        public int Version { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("public_key")]
        public string PublicKey { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("sandbox")]
        public string Sandbox { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("result_url")]
        public string ResultUrl { get; set; }

        [JsonProperty("order_id")]
        public DateTime OrderId { get; set; }
    }
}