using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public abstract class Products
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; } // Quantity can be in kg, liters, pieces etc.

        public Products(string name, double price, double quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }
        public abstract double CountAmount();
    }
}
