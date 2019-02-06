using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Transaction
    {
        [Required]
        public int TransactionID { get; set; }

        public DateTime TransactionDate { get; set; }

        public double TransactionAmount { get; set; }

       
        public Currency Currency { get; set; }
       
        public Status Status { get; set; }

        public Customer Customer { get; set; }
    }
}
