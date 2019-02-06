using System.Collections.Generic;

namespace Models
{

    public class Customer
    {
        public int CustomerID { get; set; }

        public string CustomerName { get; set; }

        public string CustomerContactEmail { get; set; }

        public string CustomerMobileNumer { get; set; }

        public ICollection<Transaction> Transactions { get; set; }

    }
}
