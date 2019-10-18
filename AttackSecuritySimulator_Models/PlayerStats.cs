using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttackSecuritySimulator_Models
{
    public class PlayerStats
    {
        public string Email { get; set; }
        public string EmailPassword { get; set; }
        public BankingDetails AnzBankDetails { get; set; }
        public BankingDetails PayPalDetails { get; set; }

        public PlayerStats(string name, string emailPassword, BankingDetails[] bankingDetails)
        {
            Email = name;
            EmailPassword = emailPassword;
            AnzBankDetails = bankingDetails[0];
            PayPalDetails = bankingDetails[1];
        }
    }
}
