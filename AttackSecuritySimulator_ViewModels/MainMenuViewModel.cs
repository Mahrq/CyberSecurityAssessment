using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
namespace AttackSecuritySimulator_ViewModels
{
    /// <summary>
    /// The Main Menu view contains various buttons that navigate into new pages.
    /// </summary>
    public class MainMenuViewModel : IPageViewModel
    {
        private ICommand displayAboutPage;
        public ICommand DisplayAboutPage
        {
            get
            {
                if (displayAboutPage == null)
                {
                    //displayAboutPage = new RelayCommand(command => Mediator.Notify("NavAbout", ""));
                    displayAboutPage = NavigationHelper.NavPageCommands[(int)Page.About];
                }
                return displayAboutPage;
            }
        }

        private ICommand displayCreditPage;
        public ICommand DisplayCreditPage
        {
            get
            {
                if (displayCreditPage == null)
                {
                    //displayCreditPage = new RelayCommand(command => Mediator.Notify("NavCredits", ""));
                    displayCreditPage = NavigationHelper.NavPageCommands[(int)Page.Credits];
                }
                return displayCreditPage;
            }
        }

        private ICommand displayPlayerCreation;
        public ICommand DisplayPlayerCreation
        {
            get
            {
                if (displayPlayerCreation == null)
                {
                    displayPlayerCreation = NavigationHelper.NavPageCommands[(int)Page.PlayerCreation]; 
                }
                return displayPlayerCreation;
            }
        }

        private ICommand displayInGame;
        public ICommand DisplayInGame
        {
            get
            {
                if (displayInGame == null)
                {
                    //displayInGame = new RelayCommand(command => Mediator.Notify("NavIngame", ""));
                    displayInGame = NavigationHelper.NavPageCommands[(int)Page.InGame];
                }
                return displayInGame;
            }
        }

        private ICommand quitGame;
        public ICommand QuitGame
        {
            get
            {
                if (quitGame == null)
                {
                    quitGame = new RelayCommand(AppExit);
                }
                return quitGame;
            }
        }

        private void AppExit(object sender)
        {
            Mediator.Notify("HookCleanUp");
            Environment.Exit(0);
        }
    }
}
