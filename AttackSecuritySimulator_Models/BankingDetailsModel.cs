using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttackSecuritySimulator_Models
{
    public class BankingDetailsModel
    {
        private string login = "user";
        public string Login { get { return login; } }
        private string password = "password";
        public string Password { get { return password; } }
        private double balance = 0;
        public double Balance { get { return balance; } }

        public BankingDetailsModel(string setName, string setPassword, double setAmount)
        {
            login = setName;
            password = setPassword;
            balance = setAmount;
        }

    }
}
