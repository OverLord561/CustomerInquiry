using System;

namespace Models
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public DateTime TransactionDate { get; set; }

        public double TransactionAmount { get; set; }

        public int CurrencyID { get; set; }
        public Currency Currency { get; set; }

        public int StatusID { get; set; }
        public Status Status { get; set; }

        public Customer Customer { get; set; }
    }
}
