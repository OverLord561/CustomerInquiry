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

            builder.Entity<Customer>(entity =>
            {
                entity.HasAlternateKey(e => e.CustomerContactEmail)
                    .HasName("Customers_CustomerContactEmail");
            });
        }
    }
}
