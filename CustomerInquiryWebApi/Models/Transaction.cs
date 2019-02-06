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

       
        public virtual Currency Currency { get; set; }
       
        public virtual Status Status { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
