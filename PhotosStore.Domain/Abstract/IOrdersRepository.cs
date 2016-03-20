using System.Collections.Generic;
using PhotosStore.Domain.Entities;

namespace PhotosStore.Domain.Abstract
{
    public interface IOrdersRepository
    {
        IEnumerable<Order> Orders { get; }
        IEnumerable<OrderDetail> OrderDetails { get; }
        void SaveOrder(Order order);
        //реализовать удаление  OrderDetails
        Order DeleteOrder(int OrderId);

    }
}