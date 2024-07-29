using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class Beverage : Products, ICountable
    {
        public Beverage(string name, double price, double quantity) : base(name, price, quantity) { }

        public override double CountAmount()
        {
            return Quantity;
        }
    }
}
