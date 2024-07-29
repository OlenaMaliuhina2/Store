using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store;

namespace Store
{
     public class ProgramRun
    {
       static List<User> users = new List<User>();
       static User currentUser = null;
        public void Run()
        {    
                bool _running = true;
                
                while (_running)
                {
                    Console.WriteLine("Welcome to the Store Inventory System");
                    Console.WriteLine("1. Create account");
                    Console.WriteLine("2. Log In");
                    Console.WriteLine("3. Exit");
                    Console.Write("Select an option: ");
                    var choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            CreateAccount();
                        break;
                        case "2":
                           Login();
                        break;
                        case "3":
                        _running = false;
                        break;
                    default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
            }
        

       static void CreateAccount()
        {
        Console.WriteLine("Enter username:");
        string username = Console.ReadLine();
        Console.WriteLine("Enter password:");
        string password = Console.ReadLine();

        users.Add(new User(username, password));
        Console.WriteLine("Account created successfully!");
        }

        static void Login()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            currentUser = users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (currentUser != null)
            {
                Console.WriteLine("Login successful!");
                ManageStore();
            }
            else
            {
                Console.WriteLine("Invalid username or password. Try again.");
            }
        }


        static void ManageStore()
        {
            bool loggedIn = true;

            while (loggedIn)
            {
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Remove Product");
                Console.WriteLine("3. View Products");
                Console.WriteLine("4. Calculate Total Value");
                Console.WriteLine("5. Logout");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddProduct();
                        break;
                    case "2":
                        RemoveProduct();
                        break;
                    case "3":
                        ViewProducts();
                        break;
                    case "4":
                        CalculateTotalValue();
                        break;
                    case "5":
                        loggedIn = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }
        static void AddProduct()
        {
            Console.WriteLine("Enter product type (Beverage, Vegetables, Milk, Meat, Fish):");
            string type = Console.ReadLine();
            Console.WriteLine("Enter product name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter product price:");
            double price = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter product quantity:");
            double quantity = Convert.ToDouble(Console.ReadLine());

            Products product = type.ToLower() switch
            {
                "beverage" => new Beverage(name, price, quantity),
                "vegetables" => new Vegetables(name, price, quantity),
                "milk" => new Milk(name, price, quantity),
                "meat" => new Meat(name, price, quantity),
                "fish" => new Fish(name, price, quantity),
                _ => null,
            };

            if (product != null)
            {
                currentUser.UserStore.AddProduct(product);
                Console.WriteLine("Product added successfully!");
            }
            else
            {
                Console.WriteLine("Invalid product type. Try again.");
            }
        }

        static void RemoveProduct()
        {
            Console.WriteLine("Enter product name to remove:");
            string name = Console.ReadLine();
            currentUser.UserStore.RemoveProduct(name);
        }

        static void ViewProducts()
        {
            currentUser.UserStore.PrintInventory();
        }

        static void CalculateTotalValue()
        {
            double totalValue = currentUser.UserStore.CalculateTotalValue();
            Console.WriteLine($"Total inventory value: {totalValue:C}");
        }
      }
    }

