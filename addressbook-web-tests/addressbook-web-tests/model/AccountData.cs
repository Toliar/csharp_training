using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class AccountData
    {
    //    private string username;
    //    private string password;

        public AccountData(string username, string password)
        {
            this.Username = username;
            this.Password = password;

        }
        public AccountData()
        {
            
        }

        public string Username { get; set; } = "admin";
        public string Password { get; set; } = "secret";
    }

    
}
