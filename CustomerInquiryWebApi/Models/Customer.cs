using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{

    public class Customer
    {
        [Required]
        public int CustomerID { get; set; }

        public string CustomerName { get; set; }

        public string CustomerContactEmail { get; set; }

        public string CustomerMobileNumer { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }

    }
}
