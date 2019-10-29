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
    public class PlayerStatsViewModel : BaseViewModelPropertyChanged, IPageViewModel
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

        private PlayerStatsModel currentPlayer;
        public PlayerStatsModel CurrentPlayer { get { return currentPlayer; } }

        public PlayerStatsViewModel()
        {
            FinishPlayerCreation(InputName);
        }

        private void FinishPlayerCreation(string name)
        {
            string finishedEmail = string.Format($"{name}@gmail.com");        
            BankingDetailsModel[] bankingDetails = {new BankingDetailsModel("379600354", "ilikecats", 1000),
                                                new BankingDetailsModel(finishedEmail, "H^4%!zV4ds", 300) };

            currentPlayer = new PlayerStatsModel(finishedEmail, "dragonslayer69", bankingDetails);
        }

        #region UI Binding 

        //Email details
        public string TxtEmailLogIn
        {
            get
            {
                if (currentPlayer == null)
                {
                    return "default@gmail.com";
                }
                return currentPlayer.Email;
            }
        }
        public string TxtEmailPassword
        {
            get
            {
                if (currentPlayer == null)
                {
                    return "defpassemail";
                }
                return currentPlayer.EmailPassword;
            }
        }
        //Anz details
        public string TxtAnzLogIn
        {
            get
            {
                if (currentPlayer == null)
                {
                    return "123456789";
                }
                return currentPlayer.AnzBankDetails.Login;
            }
        }
        public string TxtAnzPassword
        {
            get
            {
                if (currentPlayer == null)
                {
                    return "password1234bank";
                }
                return currentPlayer.AnzBankDetails.Password;
            }
        }
        //PayPal details
        public string TxtPayPalLogIn
        {
            get
            {
                if (currentPlayer == null)
                {
                    return "payforpals@gmail.com";
                }
                return "use email";
            }
        }
        public string TxtPayPalPassword
        {
            get
            {
                if (currentPlayer == null)
                {
                    return "1234abcd";
                }
                return currentPlayer.PayPalDetails.Password;
            }
        }

        #endregion

    }
}
