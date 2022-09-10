using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Ordering.Domain.Entities;

namespace Ordering.Infrastructure.Persistance
{
    public class OrderDbContextSeed
    {
        public static async Task SeedAsync(OrderDbContext orderDbContext, ILogger<OrderDbContextSeed> logger)
        {
            if (!orderDbContext.Orders.Any())
            {
                orderDbContext.Orders.AddRange(GetPreconfiguredOrders());
                await orderDbContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(OrderDbContext).Name);
            }
        }

        private static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>
            {
                new Order()
                {
                    UserName = "adnan", FirstName = "Adnan", LastName = "Suljagic",
                    EmailAdress = "asuljagic12@outlook.com", AdressLine = "Sarajevo", Country = "BiH", TotalPrice = 350
                }
            };
        }
    }
}
