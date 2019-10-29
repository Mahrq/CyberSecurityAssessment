using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using AttackSecuritySimulator_Models;
namespace AttackSecuritySimulator_ViewModels
{
    /// <summary>
    /// View model defines the commands of the 3 buttons
    /// </summary>
    public class WebPageNavigationViewModel : IPageViewModel
    {
        private ICommand button1Command;
        public ICommand Button1Command
        {
            get
            {
                if (button1Command == null)
                {
                    button1Command = NavigationHelper.NavBrowserCommands[(int)WebAddress.FaceBook];
                }
                return button1Command;
            }
        }

        private ICommand button2Command;
        public ICommand Button2Command
        {
            get
            {
                if (button2Command == null)
                {
                    button2Command = NavigationHelper.NavBrowserCommands[(int)WebAddress.ANZBank];
                }
                return button2Command;
            }
        }

        private ICommand button3Command;
        public ICommand Button3Command
        {
            get
            {
                if (button3Command == null)
                {
                    button3Command = NavigationHelper.NavBrowserCommands[(int)WebAddress.PayPal];
                }
                return button3Command;
            }
        }
    }
}
