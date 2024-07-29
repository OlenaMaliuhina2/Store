using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class Store
    {
        public List<Products> Inventory { get; set; }

        public Store()
        {
            Inventory = new List<Products>();
        }
        public void AddProduct(Products product)
            { 
            Inventory.Add(product); 
        }
        public void RemoveProduct(string name) {
            var productToRemove = Inventory.FirstOrDefault(p => p.Name == name);
            if (productToRemove != null)
            {
                Inventory.Remove(productToRemove);
                Console.WriteLine("Product removed successfully!");
            }
            else
            {
                Console.WriteLine("Product not found!");
            }
        }

        public void PrintInventory()
        {
            var groupedInventory = Inventory.GroupBy(p => p.GetType().Name);

            foreach (var group in groupedInventory)
            {
                Console.WriteLine($"{group.Key}s: {group.Sum(p => p.Quantity)} kg");
                foreach (var product in group)
                {
                    Console.WriteLine($"{product.Name}: {product.Quantity} kg");
                }
                Console.WriteLine();
            }
        }

        public double CalculateTotalValue()
        {
            return Inventory.Sum(p => p.Price * p.Quantity);
        }

    }

}
