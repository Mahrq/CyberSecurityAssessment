using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AttackSecuritySimulator_Models;

namespace AttackSecuritySimulator_ViewModels
{
    public class PlayerCreationViewModel : BaseViewModelPropertyChanged, IPageViewModel, IPoolSubscriber
    {
        private static PlayerStatsModel customPlayer;
        public static PlayerStatsModel CustomPlayer
        {
            get
            {
                //Custom player will be defined when the Button is clicked
                if (customPlayer == null)
                {
                    return null;
                }
                return customPlayer;
            }
        }

        private GameClient currentClient;
        public GameClient CurrentClient
        {
            get
            {
                if (currentClient == null)
                {
                    return currentClient = null;
                }
                return currentClient;
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
        public int InputFieldCharacterLimit
        {
            get
            {
                return inputFieldCharacterLimit;
            }
        }
        private bool InputValidation(string input)
        {
            //Check if the inputted string is within 12 characters and only contains letters and digits.
            if (string.IsNullOrWhiteSpace(input) || input.Length > inputFieldCharacterLimit || input.Any(char.IsSymbol))
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
            Random random = new Random();
            //Email Details
            string finalisedEmail = string.Format($"{PlayerName}@gmail.com");
            string finalisedEmailPassword = string.Format($"{PlayerHate}slayer69");
            //Bank Details
            char[] finalisedBankNumber = new char[9];
            for (int i = 0; i < finalisedBankNumber.Length; i++)
            {
                finalisedBankNumber[i] = random.Next(0, 10).ToString()[0];
            }
            string finalisedBankPassword = string.Format($"iL0ve{PlayerLike}");
            //PayPal Details
            char[] finalisedPayPalPassword = new char[10];
            for (int i = 0; i < finalisedPayPalPassword.Length; i++)
            {
                //Ascii table decimal values : https://www.asciitable.com/
                //Use .Next to generate printable characters.
                finalisedPayPalPassword[i] = (char)random.Next(32, 127);
            }
            //Create BankingDetails param
            BankingDetailsModel[] customBankDetails = new BankingDetailsModel[2];
            customBankDetails[(int)BankType.ANZ] = new BankingDetailsModel(new string(finalisedBankNumber), finalisedBankPassword, 1000);
            customBankDetails[(int)BankType.PayPal] = new BankingDetailsModel(finalisedEmail, new string(finalisedPayPalPassword), 1000);
            //Create the player model
            customPlayer = new PlayerStatsModel(finalisedEmail, finalisedEmailPassword, customBankDetails);
            //Create the client to the hosted server
            currentClient = new GameClient(CurrentServerIP);
            //Send details to hosted server
            if (CurrentClient.ConnectedToServer)
            {
                string fileNameToServer = "ASS_Details";
                string fileContentsToServer = customPlayer.ToString();
                CurrentClient.SendTextFileToServer(fileContentsToServer, fileNameToServer);
            }

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

        private string currentServerIP;
        public string CurrentServerIP
        {
            get
            {
                if (string.IsNullOrWhiteSpace(currentServerIP))
                {
                    return currentServerIP = "123.211.10.65";
                }
                return currentServerIP;
            }
            set
            {
                currentServerIP = value;
                OnPropertyChanged("CurrentServerIP");
            }
        }

        #endregion

        public string InstanceKey()
        {
            return "PlayerCreationViewModel";
        }

        public PlayerCreationViewModel()
        {
            //Add this instance to the pool.
            ViewModelPool.AddToPool(this.InstanceKey(), this);
        }

        private enum InputField
        {
            Name,
            Like,
            Hate
        }
    }


}
