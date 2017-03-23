using System;
using Newtonsoft.Json;

namespace NovaApp.API.DataObjects.PlayerObjects
{
    public class ExtendedPlayerDataObject : PlayerDataObject
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("fbUserId")]
        public string FacebookUserId { get; set; }

        [JsonProperty("fbAccessToken")]
        public string FacebookAccessToken { get; set; }

        [JsonProperty("fbExpiresIn")]
        public DateTime? FacebookExpiresIn { get; set; }

        [JsonProperty("ggIdToken")]
        public string GoogleIdToken { get; set; }

        [JsonProperty("vkId")]
        public string VkontakteUserId { get; set; }
    }
}