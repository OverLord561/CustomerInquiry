using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{

    public class Customer
    {
        [Required]
        [MaxLength(10)]
        public int CustomerID { get; set; }

        [MaxLength(30)]
        public string CustomerName { get; set; }

        [MaxLength(25)]
        public string CustomerContactEmail { get; set; }

        [MaxLength(10)]
        public string CustomerMobileNumber { get; set; }

        public ICollection<Transaction> Transactions { get; set; }

    }
}
