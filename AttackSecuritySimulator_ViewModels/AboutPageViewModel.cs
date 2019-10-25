using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AttackSecuritySimulator_ViewModels
{
    /// <summary>
    /// Also used as a DataContext for the credits page as that page only has 1 button
    /// </summary>
    public class AboutPageViewModel : IPageViewModel
    {
        private ICommand displayMainMenu;

        public  ICommand DisplayMainMenu
        {
            get
            {
                if (displayMainMenu == null)
                {
                    displayMainMenu = new RelayCommand( x => Mediator.Notify("NavMainMenu", ""));
                }
                return displayMainMenu;
            }
        }
    }
}
