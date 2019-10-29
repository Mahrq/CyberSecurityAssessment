using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AttackSecuritySimulator_ViewModels
{
    public class CreditPageViewModel : IPageViewModel
    {
        private ICommand displayMainMenu;
        public  ICommand DisplayMainMenu
        {
            get
            {
                if (displayMainMenu == null)
                {
                    //displayMainMenu = new RelayCommand(command => Mediator.Notify("NavMainMenu", ""));
                    displayMainMenu = NavigationHelper.NavPageCommands[(int)Page.MainMenu];
                }
                return displayMainMenu;
            }
        }


    }
}
