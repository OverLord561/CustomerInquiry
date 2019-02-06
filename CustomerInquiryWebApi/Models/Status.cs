using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class Status
    {
        [Required]
        public int StatusID { get; set; }

        public int StatusCode { get; set; }

        public string StatusName { get; set; }

        public ICollection<Transaction> Transactions { get; set; }

    }
}
