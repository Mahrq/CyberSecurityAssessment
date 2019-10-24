using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace AttackSecuritySimulator_ViewModels
{
    /// <summary>
    /// MVVM framework reference : https://www.technical-recipes.com/2018/navigating-between-views-in-wpf-mvvm/
    /// Without instantiating views and decoupling from the view assembly entirely.
    /// </summary>
    public class MainWindowViewModel : BaseViewModelPropertyChanged
    {
        //View
        private object[] pages = new object[5];
        private object currentPageDisplayed;
        public object CurrentPageDisplayed { get; set; }


        public MainWindowViewModel()
        {
            
        }

        private enum ViewObjects
        {
            MainMenu,
            About,
            Credits,
            PlayerCreation,
            InGame
        }

    }
}
