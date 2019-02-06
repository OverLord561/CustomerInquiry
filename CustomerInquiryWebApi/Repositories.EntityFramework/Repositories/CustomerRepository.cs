using Microsoft.EntityFrameworkCore;
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

        protected override IQueryable<Customer> Include()
        {
            return base.Include()
                .Include(x => x.Transactions)
                    .ThenInclude(x=>x.Status)
                .Include(x => x.Transactions)
                    .ThenInclude(x=>x.Currency);
        }

    }
}
