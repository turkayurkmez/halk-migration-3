using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsNewInCsharp
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Vendor Vendor { get; set; }

        public Product(string name, double price, Vendor vendor)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Price = price;
            Vendor = vendor ?? throw new ArgumentNullException(nameof(vendor));
        }
    }

    public class Vendor
    {
        public string CompanyName { get; set; }
    }
}
