using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Status
    {
        public int StatusID { get; set; }

        public int StatusCode { get; set; }

        public string StatusName { get; set; }

        public Transaction Transaction { get; set; }

    }
}
