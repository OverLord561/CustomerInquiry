using Microsoft.EntityFrameworkCore;
using Models;
using System.Linq;

namespace Repositories.EntityFramework.Repositories
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(СustomerInquiryDbContext context)
            : base(context)
        {
            
        }

        protected override IQueryable<Transaction> Include()
        {
            return base.Include()
                .Include(x => x.Customer)
                .Include(x => x.Currency)
                .Include(x => x.Status);
        }
    }
}
