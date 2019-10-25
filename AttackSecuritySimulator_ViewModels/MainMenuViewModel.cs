using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
namespace AttackSecuritySimulator_ViewModels
{
    public class MainMenuViewModel : IPageViewModel
    {
        private ICommand displayAboutPage;
        public ICommand DisplayAboutPage
        {
            get
            {
                if (displayAboutPage == null)
                {
                    displayAboutPage = new RelayCommand(x => Mediator.Notify("NavAbout", ""));
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
                    displayCreditPage = new RelayCommand(x => Mediator.Notify("NavCredits", ""));
                }
                return displayCreditPage;
            }
        }

        //private ICommand displayPlayerCreation;

        //private ICommand displayIngame;

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

        private void AppExit(object obj)
        {
            Environment.Exit(0);
        }
    }
}
