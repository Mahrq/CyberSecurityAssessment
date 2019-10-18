using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttackSecuritySimulator_Models
{
    public class BankingDetails
    {
        private string login = "user";
        public string Login { get { return login; } }
        private string password = "password";
        public string Password { get { return password; } }
        private double balance = 0;
        public double Balance { get { return balance; } }

        public BankingDetails(string name, string password, double amount)
        {
            login = name;
            login = password;
            balance = amount;
        }

    }
}
