using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttackSecuritySimulator_Models;

namespace AttackSecuritySimulator_ViewModels
{
    /// <summary>
    /// Description:    This ViewModel controls the Display tab of the players stats ingame.
    ///                 When the user needs to log into the websites, they will be prompt to
    ///                 enter creditials
    /// </summary>
    public class PlayerStatsViewModel : ViewModelPropertyChanged
    {
        //This name will be retrieved from another ViewModel where the player has input their name.
        private string inputName;
        public string InputName
        {
            get
            {
                if (inputName == null)
                {
                    return "PlayerTest";
                }
                return inputName;
            }
        }

        private PlayerStats playerStats;

        public PlayerStatsViewModel()
        {
            FinishPlayerCreation(InputName);
        }

        private void FinishPlayerCreation(string name)
        {
            string finishedEmail = string.Format($"{name}@gmail.com");
            BankingDetails[] bankingDetails = {new BankingDetails("379600354", "ilikecats", 1000),
                                                new BankingDetails(finishedEmail, "H^4%!zV4ds", 300) };

            playerStats = new PlayerStats(finishedEmail, "dragonslayer69", bankingDetails);
        }



        #region UI Binding 

        public string EmailLogIn { get; set; }
        public string EmailPassword { get; set; }

        public string AnzLogIn { get; set; }
        public string AnzPassword { get; set; }

        public string PayPalLogIn { get; set; }
        public string PayPalPassword { get; set; }

        #endregion



    }
}
