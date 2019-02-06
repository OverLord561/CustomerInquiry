using Microsoft.EntityFrameworkCore;
using Models;

namespace Repositories.EntityFramework
{
    public class СustomerInquiryDbContext : DbContext
    {

        public СustomerInquiryDbContext(DbContextOptions options)
            : base(options) { }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Customer>()
                .HasMany(c => c.Transactions)
                .WithOne(e => e.Customer);

            builder.Entity<Currency>()
                .HasOne(a => a.Transaction)
                .WithOne(b => b.Currency)
                .HasForeignKey<Currency>(b => b.CurrencyID);

            builder.Entity<Status>()
                .HasOne(a => a.Transaction)
                .WithOne(b => b.Status)
                .HasForeignKey<Status>(b => b.StatusID);
        }
    }
}
