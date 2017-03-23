using System.Linq;

namespace NovaApp.API.QueryParams
{
    public class PlayerQueryParams
    {
        public string FacebookId { get; set; }

        public string GoogleId { get; set; }

        public string VkId { get; set; }

        public string Email { get; set; }

        public bool IsMultipleIdsProvided()
        {
            var result = IsMultipleNonEmptyStrings(FacebookId, VkId, GoogleId, Email);
            return result;
        }

        public bool IsEmpty()
        {
            return string.IsNullOrEmpty(FacebookId) &&
                   string.IsNullOrEmpty(GoogleId) &&
                   string.IsNullOrEmpty(VkId) &&
                   string.IsNullOrEmpty(Email);
        }

        private bool IsMultipleNonEmptyStrings(params string[] strings)
        {
            if (strings == null)
                return false;

            var nonEmptyItems = strings.Where(x => !string.IsNullOrEmpty(x));
            var result = nonEmptyItems.Count() > 1;
            return result;
        }
    }
}