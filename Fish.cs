using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class Fish : Products, ICountable
    {
        public Fish(string name, double price, double quantity) : base(name, price, quantity) { }

        public override double CountAmount()
        {
            return Quantity;
        }
    }
}
