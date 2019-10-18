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

        public PlayerStats(string email, string emailPassword, BankingDetails[] bankingDetails)
        {
            Email = email;
            EmailPassword = emailPassword;
            AnzBankDetails = bankingDetails[0];
            PayPalDetails = bankingDetails[1];
        }
    }
}
