using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
//using System.Windows.Forms;
using System.Windows.Controls;
using AttackSecuritySimulator_Models;
/// <summary>
/// Server IP Address: 
/// </summary>
namespace AttackSecuritySimulator_ViewModels
{
    public class InGameViewModel : BaseViewModelPropertyChanged, IPageViewModel, IPoolSubscriber
    {
        //Home page property,
        //Displays the desired website when first navigating to the game view.
        private Uri homePage;
        public Uri HomePage
        {
            get
            {
                if (homePage == null)
                {
                    homePage = AddressLibrary.RetrieveWebAddress(WebAddress.Home);
                }
                return homePage;
            }
        }
        //Instancce of the address library containing certain websites as well as the server IPs
        private static WebAddressLibraryModel addressLibrary;
        public static WebAddressLibraryModel AddressLibrary
        {
            get
            {
                if (addressLibrary == null)
                {
                    addressLibrary = new WebAddressLibraryModel();
                }
                return addressLibrary;
            }
        }
        //The mid section of the side tab toggles between more buttons or the player's stats.
        private bool showDetailsTab;
        private IPageViewModel currentMidTabDisplayed;
        public IPageViewModel CurrentMidTabDisplayed
        {
            get
            {
                return currentMidTabDisplayed;
            }
            set
            {
                currentMidTabDisplayed = value;
                OnPropertyChanged("CurrentMidTabDisplayed");
            }
        }
        //List of the mid info tab views
        private List<IPageViewModel> midTabViews;
        public List<IPageViewModel> MidTabViews
        {
            get
            {
                if (midTabViews == null)
                {
                    midTabViews = new List<IPageViewModel>();
                }
                return midTabViews;
            }
        }

        public string InstanceKey()
        {
            return "InGameViewModel";
        }

        //Constructor
        public InGameViewModel()
        {
            ViewModelPool.AddToPool(this.InstanceKey(), this);
            //Set up browser settings
            IEBrowserSetUp browserSetUp = new IEBrowserSetUp();
            browserSetUp.SetBrowserFeatureControl();
            //Set browser home page
            Browser.Source = HomePage;
            //Add neccessary views
            MidTabViews.Add(new PlayerStatsViewModel());
            MidTabViews.Add(new WebPageNavigationViewModel());
            //Set the view for mid tab
            showDetailsTab = false;
            currentMidTabDisplayed = MidTabViews[(int)TabView.WebPageNav];

        }

        #region UI DataBinding

        private static WebBrowser browser;
        public static WebBrowser Browser
        {
            get
            {
                if (browser == null)
                {
                    browser = new WebBrowser();
                }
                return browser;
            }
        }

        private string txtDetailsButton;
        public string TxtDetailsButton
        {
            get
            {
                //If the details tab is showing then the tab button should say websites to change the current tab to websites.
                return txtDetailsButton = showDetailsTab ? "Websites" : "Details";
            }
        }
        #endregion

        #region Button Command Definition

        /// <summary>
        /// Switches the middle tab of the side bar to another view.
        /// </summary>
        private void SwitchInfoTab(object sender)
        {
            //Change condition of the shown tab
            showDetailsTab = !showDetailsTab;
            //Notify UI of property changed
            OnPropertyChanged("TxtDetailsButton");
            if (showDetailsTab)
            {
                CurrentMidTabDisplayed = MidTabViews[(int)TabView.PlayerStats];
            }
            else
            {
                CurrentMidTabDisplayed = MidTabViews[(int)TabView.WebPageNav];
            }
        }

        private ICommand switchInfoCommand;
        public ICommand SwitchInfoCommand
        {
            get
            {
                if (switchInfoCommand == null)
                {
                    switchInfoCommand = new RelayCommand(SwitchInfoTab);
                }
                return switchInfoCommand;
            }
        }
        //Navigate browser to home page
        private ICommand navToHome;
        public ICommand NavToHome
        {
            get
            {
                if (navToHome == null)
                {
                    navToHome = NavigationHelper.NavBrowserCommands[(int)WebAddress.Home];
                }
                return navToHome;
            }
        }
        //Navigate the page back to the main menu
        private ICommand returnToMainMenu;
        public ICommand ReturnToMainMenu
        {
            get
            {
                if (returnToMainMenu == null)
                {
                    returnToMainMenu = new RelayCommand(NavWithCleanUp);
                }
                return returnToMainMenu;
            }
        }

        private void NavWithCleanUp(object sender)
        {
            Mediator.Notify("HookCleanUp");
            Mediator.Notify("NavMainMenu", "");
        }

        #endregion

    }

    public enum TabView
    {
        PlayerStats,
        WebPageNav
    }

}
