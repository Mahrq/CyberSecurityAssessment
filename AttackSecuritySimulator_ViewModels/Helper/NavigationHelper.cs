using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AttackSecuritySimulator_Models;
namespace AttackSecuritySimulator_ViewModels
{
    /// <summary>
    /// Navigation commands such as changing page views are defined here.
    /// A lot of view models use the same command for navigating to certain pages so it's better
    /// to define a reference to the commands here.
    /// </summary>
    public static class NavigationHelper
    {
        /// <summary>
        /// Page view navigation commands
        /// </summary>
        private static ICommand[] navPageCommands;
        public static ICommand[] NavPageCommands
        {
            get
            {
                if (navPageCommands == null)
                {
                    navPageCommands = new ICommand[5];
                    navPageCommands[(int)Page.MainMenu] = new RelayCommand(command => Mediator.Notify("NavMainMenu", ""));
                    navPageCommands[(int)Page.About] = new RelayCommand(command => Mediator.Notify("NavAbout", ""));
                    navPageCommands[(int)Page.Credits] = new RelayCommand(command => Mediator.Notify("NavCredits", ""));
                    navPageCommands[(int)Page.PlayerCreation] = new RelayCommand(command => Mediator.Notify("NavPlayerCreation", ""));
                    navPageCommands[(int)Page.InGame] = new RelayCommand(command => Mediator.Notify("NavIngame", ""));
                }
                return navPageCommands;
            }
        }


        /// <summary>
        /// Navigates the current instance of the web browser(Defined in InGameViewModel) to the web address.
        /// </summary>
        private static void NavToWebAddress(Uri webAddress)
        {
            InGameViewModel.Browser.Navigate(webAddress);
        }
        //Instancce of the address library containing certain websites as well as the server IPs
        private static WebAddressLibraryModel addressLibrary;
        private static WebAddressLibraryModel AddressLibrary
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

        private static ICommand[] navBrowserCommands;
        public static ICommand[] NavBrowserCommands
        {
            get
            {
                if (navBrowserCommands == null)
                {
                    navBrowserCommands = new ICommand[4];
                    //Navigate to Youtube
                    navBrowserCommands[(int)WebAddress.Youtube] = new RelayCommand<WebPageNavigationViewModel>(
                        command => NavToWebAddress(AddressLibrary.RetrieveWebAddress(WebAddress.Youtube)));
                    //Navigate to FaceBook
                    navBrowserCommands[(int)WebAddress.FaceBook] = new RelayCommand<WebPageNavigationViewModel>(
                        command => NavToWebAddress(AddressLibrary.RetrieveWebAddress(WebAddress.FaceBook)));
                    //Navigate to ANZ Bank
                    navBrowserCommands[(int)WebAddress.ANZBank] = new RelayCommand<WebPageNavigationViewModel>(
                        command => NavToWebAddress(AddressLibrary.RetrieveWebAddress(WebAddress.ANZBank)));
                    //Navigate to PayPal
                    navBrowserCommands[(int)WebAddress.PayPal] = new RelayCommand<WebPageNavigationViewModel>(
                        command => NavToWebAddress(AddressLibrary.RetrieveWebAddress(WebAddress.PayPal)));
                    //TODO: Add the server side addresses to commands.

                }
                return navBrowserCommands;
            }
        }
    }
}
