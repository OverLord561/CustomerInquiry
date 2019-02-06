using Models;
using System.Linq;

namespace Repositories.EntityFramework.Repositories
{
    public class TransactionRepository: Repository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(СustomerInquiryDbContext context)
            : base(context)
        {

        }
    }
}
