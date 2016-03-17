using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotosStore.Domain.Entities
{
    public  class OrderDetail
    {
        [Key]

        public int OrderDetailsID { get; set; }
        [ForeignKey("Orders")]
        public int OrderId { get; set; }
        public int PhotoTechniqueID { get; set; }
        public int Quantity { get; set; }

        public virtual Order Orders { get; set; }
        public virtual PhotoTechnique PhotoTechniques { get; set; }

    }
}
