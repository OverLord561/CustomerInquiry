using Microsoft.EntityFrameworkCore;
using Models;

namespace Repositories.EntityFramework
{
    public class СustomerInquiryDbContext : DbContext
    {

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Transaction> Transactions { get; set; }


        public СustomerInquiryDbContext(DbContextOptions options)
            : base(options) { }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Customer>()
                .HasMany(c => c.Transactions)
                .WithOne(e => e.Customer);

            builder.Entity<Currency>()
                .HasMany(a => a.Transactions)
                .WithOne(b => b.Currency);

            builder.Entity<Status>()
                .HasMany(a => a.Transactions)
                .WithOne(b => b.Status);
        }
    }
}
