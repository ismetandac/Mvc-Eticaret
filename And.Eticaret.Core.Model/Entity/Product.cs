using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace And.Eticaret.Core.Model.Entity
{
    public class Product : EntityBase
    {
        public string Name { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Tax { get; set; }
        public decimal Discount { get; set; }
        public int Stock { get; set; }
        public bool IsActive { get; set; }

    }
}
