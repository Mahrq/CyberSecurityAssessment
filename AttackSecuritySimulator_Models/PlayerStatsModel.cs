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

        /// <summary>
        /// Ovveride version provides the player's details in a formatted way to allow
        /// it to be sent.
        /// </summary>
        public override string ToString()
        {
            string formattedPlayerStats = $"Email\n{Email}\n{EmailPassword}" +
                $"\n\nBanking\n{AnzBankDetails.Login}\n{AnzBankDetails.Password}" +
                $"\n\nPayPal\n{PayPalDetails.Login}\n{PayPalDetails.Password}";

            return formattedPlayerStats;
        }
    }
}
