using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhotosStore.Domain.Entities
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public string Telephone { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public virtual  ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
