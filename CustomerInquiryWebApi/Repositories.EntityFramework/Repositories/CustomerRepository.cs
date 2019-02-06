using Models;
using System.Linq;

namespace Repositories.EntityFramework.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(СustomerInquiryDbContext context)
            : base(context)
        {

        }
       
    }
}
