using System.Collections.Generic;

namespace CustomerInquiryWebApi.ViewModels
{
    public class CustomerViewModel
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }

        public IEnumerable<TransactionViewModel> Transactions { get; set; }

    }
}
