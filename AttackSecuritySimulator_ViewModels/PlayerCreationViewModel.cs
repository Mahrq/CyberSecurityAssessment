using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AttackSecuritySimulator_Models;

namespace AttackSecuritySimulator_ViewModels
{
    public class PlayerCreationViewModel : BaseViewModelPropertyChanged, IPageViewModel
    {
        private PlayerStatsModel customPlayer;
        public PlayerStatsModel CustomPlayer
        {
            get
            {
                //Custom payer will be defined when the Button is clicked
                if (customPlayer == null)
                {
                    return null;
                }
                return customPlayer;
            }
        }
        private ICommand startGame;
        public ICommand StartGame
        {
            get
            {
                if (startGame == null)
                {
                    startGame = new RelayCommand(FinalisePlayerAndStart, condition => InputfieldConditions.All(item => item.Equals(true)));
                }
                return startGame;
            }
        }
        private int inputFieldCharacterLimit = 12;
        private bool InputValidation(string input)
        {
            //Check if the inputted string is within 12 characters and only contains letters and digits.
            if (string.IsNullOrWhiteSpace(input) || input.Length > inputFieldCharacterLimit || !input.All(char.IsLetterOrDigit))
            {
                return false;
            }
            return true;
        }
        private bool[] inputFieldConditions;
        private bool[] InputfieldConditions
        {
            get
            {
                if (inputFieldConditions == null)
                {
                    inputFieldConditions = new bool[3];
                    inputFieldConditions[(int)InputField.Name] = InputValidation(PlayerName);
                    inputFieldConditions[(int)InputField.Like] = InputValidation(PlayerLike);
                    inputFieldConditions[(int)InputField.Hate] = InputValidation(PlayerHate);
                }
                return inputFieldConditions;
            }
        }



        private void FinalisePlayerAndStart(object sender)
        {
            //Finalise player stats

            //Send details to hosted server

            //Navigate to in game
            Mediator.Notify("NavIngame", "");
        }

        #region Text Box Data Binding

        private string playerName;
        public string PlayerName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(playerName))
                {
                    return playerName = "12 character limit";
                }
                return playerName;
            }
            set
            {
                playerName = value;
                inputFieldConditions[(int)InputField.Name] = InputValidation(PlayerName);
                OnPropertyChanged("PlayerName");
                OnPropertyChanged("InputfieldConditions");
                OnPropertyChanged("StartGame");
            }
        }

        private string playerLike;
        public string PlayerLike
        {
            get
            {
                if (string.IsNullOrWhiteSpace(playerLike))
                {
                    return playerLike = "12 character limit";
                }
                return playerLike;
            }
            set
            {
                playerLike = value;
                inputFieldConditions[(int)InputField.Like] = InputValidation(PlayerLike);
                OnPropertyChanged("PlayerLike");
                OnPropertyChanged("InputfieldConditions");
                OnPropertyChanged("StartGame");
            }
        }


        private string playerHate;
        public string PlayerHate
        {
            get
            {
                if (string.IsNullOrWhiteSpace(playerHate))
                {
                    return playerHate = "12 character limit";
                }
                return playerHate;
            }
            set
            {
                playerHate = value;
                inputFieldConditions[(int)InputField.Hate] = InputValidation(PlayerHate);
                OnPropertyChanged("PlayerHate");
                OnPropertyChanged("InputfieldConditions");
                OnPropertyChanged("StartGame");
            }
        }

        #endregion


        private enum InputField
        {
            Name,
            Like,
            Hate
        }
    }


}
