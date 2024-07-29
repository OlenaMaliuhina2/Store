using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public Store UserStore { get; private set; }

        public User(string username, string password) 
        {
            Username = username;
            Password = password;
            UserStore = new Store();
        }

        
    }
}
