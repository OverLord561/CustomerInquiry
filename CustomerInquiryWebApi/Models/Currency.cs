using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Currency
    {
        [Required]
        public int CurrencyID { get; set; }

        public int CurrencyCode { get; set; }

        public string CurrencyName { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
    }
}
