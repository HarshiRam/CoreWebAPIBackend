using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreWebAPIBackend.Core
{
    public class Product
    {
        public int Id { get; set; }

        public string? ProductName { get; set; }

        public decimal Price { get; set; }

        public int Qty { get; set; }
    }
}
