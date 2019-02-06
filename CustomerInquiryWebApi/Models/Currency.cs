namespace Models
{
    public class Currency
    {
        public int CurrencyID { get; set; }

        public int CurrencyCode { get; set; }

        public string CurrencyName { get; set; }

        public Transaction Transaction { get; set; }
    }
}
