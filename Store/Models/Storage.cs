using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    public class Storage
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public ProductList ProductList { get; set; }
    }
}
