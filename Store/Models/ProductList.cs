using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    public class ProductList
    {
        public long Id { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }

    }
}
