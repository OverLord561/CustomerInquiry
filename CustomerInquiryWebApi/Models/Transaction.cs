using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Transaction
    {
        [Required]
        public int TransactionID { get; set; }

        public DateTime TransactionDate { get; set; }

        [RegularExpression(@"[0-9]+(\.[0-9][0-9]?)?")]
        public double TransactionAmount { get; set; }

        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }

        public int StatusId { get; set; }
        public Status Status { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
