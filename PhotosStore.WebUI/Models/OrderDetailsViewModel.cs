using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhotosStore.Domain.Entities;

namespace PhotosStore.WebUI.Models
{
    public class OrderDetailsViewModel
    {
        public IEnumerable<OrderDetail> orderDetails;
        public IEnumerable<PhotoTechnique> PhotoTechniques;
    }
}