using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class Vegetables:Products, ICountable
    {
        public Vegetables(string name, double price, double quantity) : base(name, price, quantity) { }

        public override double CountAmount()
        {
            return Quantity;
        }
    }
    
}
