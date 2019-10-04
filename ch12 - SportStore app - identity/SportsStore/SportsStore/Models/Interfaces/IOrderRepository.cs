namespace SportsStore.Models.Interfaces
{
    using System.Linq;

    using SportsStore.Models.Domain;

    public interface IOrderRepository
    {
        IQueryable<Order> Orders { get; }

        void SaveOrder(Order order);
    }
}