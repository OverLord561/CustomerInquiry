using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerInquiryWebApi.ViewModels
{
    public class TransactionViewModel
    {
        public int Id { get; set; }

        public string Date { get; set; }

        public string Amount { get; set; }

        public string Currency { get; set; }

        public string Status { get; set; }
    }
}
