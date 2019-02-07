using Microsoft.AspNetCore.Hosting;
using Models;
using Repositories.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerInquiryWebApi.Extensions
{
    public static class DbContextExtensions
    {
        public static void EnsureSeedData(this СustomerInquiryDbContext context, IHostingEnvironment env)
        {
            var statuses = new List<Status>()
            {
                new Status
                {
                    StatusCode = 1,
                    StatusName = "Success"
                },
                new Status{
                    StatusCode = 2,
                    StatusName = "Failed"

                },
                new Status{
                    StatusCode = 3,
                    StatusName = "Canceled"
                }
            };

            var currencies = new List<Currency>()
            {
                new Currency
                {
                    CurrencyCode = 1,
                    CurrencyName = "USD"
                },
                new Currency{
                    CurrencyCode = 2,
                    CurrencyName = "JPY"

                },
                new Currency{
                    CurrencyCode = 3,
                    CurrencyName = "THB"
                },
                new Currency{
                    CurrencyCode = 4,
                    CurrencyName = "SGD"
                }
            };

            context.Statuses.AddRange(statuses);
            context.Currencies.AddRange(currencies);

            context.SaveChanges();

            var customer = new Customer
            {
                CustomerName = "John",
                CustomerContactEmail = "test@test.com",
                CustomerMobileNumber = "123456789"
            };

            context.Customers.Add(customer);
            context.SaveChanges();


            var transactions = new List<Transaction>
            {
                new Transaction
                {
                    TransactionDate = DateTime.Now,
                    TransactionAmount = 222,
                    StatusId = statuses[0].StatusID,
                    CurrencyId =  currencies[0].CurrencyID,
                    CustomerId = customer.CustomerID
                },
                new Transaction
                {
                    TransactionDate = DateTime.Now,
                    TransactionAmount = 228,
                    StatusId = statuses[1].StatusID,
                    CurrencyId =  currencies[1].CurrencyID,
                    CustomerId = customer.CustomerID
                }
            };
            context.Transactions.AddRange(transactions);
            context.SaveChanges();

        }
    }
}
