using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models.Repositories
{
    using Microsoft.EntityFrameworkCore;

    using SportsStore.Models.Domain;
    using SportsStore.Models.Interfaces;

    public class EFOrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext dbContext;

        public EFOrderRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<Order> Orders => dbContext.Orders.Include(_ => _.Lines).ThenInclude(_ => _.Product);

        public void SaveOrder(Order order)
        {
            dbContext.AttachRange(order.Lines.Select(l => l.Product));
            if (order.OrderID == 0)
            {
                dbContext.Orders.Add(order);
                dbContext.SaveChanges();
            }
        }
    }
}
