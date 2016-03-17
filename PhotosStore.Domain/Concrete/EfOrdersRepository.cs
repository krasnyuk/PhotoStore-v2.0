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

       public void SaveOrder(OrderDetail order)
       {
           //if (order.OrderID == 0)
           //{
              _context.OrderDetails.Add(order);
           //}
           //else
           //{
           //    Order dbentry = _context.Orders.Find(order.OrderID);
           //    if (dbentry!=null)
           //    {
           //        dbentry.OrderID = order.OrderID;
           //        dbentry.Adress = order.Adress;
           //        dbentry.City = order.City;
           //        dbentry.Date = order.Date;
           //        dbentry.Email = order.Email;
           //        dbentry.Telephone = order.Telephone;
           //        dbentry.Name = order.Name;
           //    }
              
           //}
            _context.SaveChanges();
       }

       public Order DeleteOrder(int OrderId)
       {
           throw new NotImplementedException();
       }
    }
}
