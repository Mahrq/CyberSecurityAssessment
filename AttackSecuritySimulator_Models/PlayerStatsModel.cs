using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttackSecuritySimulator_Models
{
    public class PlayerStatsModel
    {
        public string Email { get; set; }
        public string EmailPassword { get; set; }
        public BankingDetailsModel AnzBankDetails { get; set; }
        public BankingDetailsModel PayPalDetails { get; set; }

        public PlayerStatsModel(string name, string emailPassword, BankingDetailsModel[] bankingDetails)
        {
            Email = name;
            EmailPassword = emailPassword;
            AnzBankDetails = bankingDetails[0];
            PayPalDetails = bankingDetails[1];
        }
    }
}
