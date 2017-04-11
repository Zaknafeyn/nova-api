namespace NovaApp.API.DataObjects
{
    public class PaymentPurposeDataObject
    {
        public int Id { get; set; }

        public string PurposeName { get; set; }

        public string PurposeDescription { get; set; }

        public decimal FeedAmount { get; set; }

        public bool IsPurposeEditable { get; set; }

        public bool IsDisabled { get; set; }
    }
}