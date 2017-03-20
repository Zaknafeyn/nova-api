using Newtonsoft.Json;

namespace NovaApp.API.DataObjects
{
    public class PlayerDataObject
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("nickName")]
        public string NickName { get; set; }

        [JsonProperty("avatarFilename")]
        public string AvatarFilename { get; set; }

        [JsonProperty("clubID")]
        public int? ClubId { get; set; }

        [JsonProperty("birthDate")]
        public string BirthDate { get; set; }

        [JsonProperty("feePayed")]
        public string FeePayed { get; set; }
    }

}