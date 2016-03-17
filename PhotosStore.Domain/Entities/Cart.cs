using System.Collections.Generic;
using System.Linq;

namespace PhotosStore.Domain.Entities
{
   public class Cart
    {
        private readonly List<CartLine> _lineCollection = new List<CartLine>();
       
        public void AddItem(PhotoTechnique technique, int quantity)
        {
            CartLine line = _lineCollection.FirstOrDefault(g => g.PhotoTechnique.PhotoTechniqueId == technique.PhotoTechniqueId);

            if (line == null)
            {
                _lineCollection.Add(new CartLine
                {
                    PhotoTechnique = technique,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(PhotoTechnique technique)
        {
            _lineCollection.RemoveAll(l => l.PhotoTechnique.PhotoTechniqueId == technique.PhotoTechniqueId);
        }

        public decimal ComputeTotalValue()
        {
            return _lineCollection.Sum(e => e.PhotoTechnique.Price * e.Quantity);
        }
        public void Clear()
        {
            _lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines => _lineCollection;
    }

    public class CartLine
    {
        public PhotoTechnique PhotoTechnique { get; set; }
        public int Quantity { get; set; }
    }
}

