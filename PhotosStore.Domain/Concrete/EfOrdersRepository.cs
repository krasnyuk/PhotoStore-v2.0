using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotosStore.Domain.Abstract;
using PhotosStore.Domain.Entities;

namespace PhotosStore.Domain.Concrete
{
   public class EfOrdersRepository : IOrdersRepository 
    {
       readonly EfDbContext _context = new EfDbContext();
       public IEnumerable<Order> Orders => _context.Orders;
       public IEnumerable<OrderDetail> OrderDetails => _context.OrderDetails;

       public void SaveOrder(Order order)
       {
           
            _context.Orders.Add(order);
            _context.SaveChanges();
       }

       public Order DeleteOrder(int OrderId)
       {
           throw new NotImplementedException();
       }
    }
}
