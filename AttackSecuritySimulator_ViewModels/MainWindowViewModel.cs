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
    /// Naviagate between different views without instantiating the views.
    /// </summary>
    public class MainWindowViewModel : BaseViewModelPropertyChanged
    {
        //Current user control displayed
        private IPageViewModel currentPageDisplayed;

        public IPageViewModel CurrentPageDisplayed
        {
            get
            {
                return currentPageDisplayed;
            }
            set
            {
                currentPageDisplayed = value;
                OnPropertyChanged("CurrentPageDisplayed");
            }
        }

        /// <summary>
        /// List of Pages:
        ///     -Main Menu
        ///     -About
        ///     -Credits
        ///     -Player Creation
        ///     -InGame
        /// </summary>
        private List<IPageViewModel> collectionOfPages;

        public List<IPageViewModel> CollectionOfPages
        {
            get
            {
                if (collectionOfPages == null)
                {
                    collectionOfPages = new List<IPageViewModel>();
                }
                return collectionOfPages;
            }
        }

        private void ChnageCurrentDisplayPage(int collectionIndex)
        {
            CurrentPageDisplayed = CollectionOfPages[collectionIndex];
        }

        public MainWindowViewModel()
        {
            CollectionOfPages.Add(new MainMenuViewModel());
            CollectionOfPages.Add(new AboutPageViewModel());
            CollectionOfPages.Add(new CreditPageViewModel());
            //TODO Add Player creation page
            //TODO Add Ingame page

            CurrentPageDisplayed = CollectionOfPages[(int)Page.MainMenu];

            Mediator.SubscribeEvent("NavMainMenu", DisplayMainMenuPage);
            Mediator.SubscribeEvent("NavAbout", DisplayAboutPage);
            Mediator.SubscribeEvent("NavCredits", DisplayCreditPage);
            Mediator.SubscribeEvent("NavPlayerCreation", DisplayPlayerCreationPage);
            Mediator.SubscribeEvent("NavIngame", DisplayIngamePage);
        }

        #region Page Display Events

        private void DisplayMainMenuPage(object obj)
        {
            ChnageCurrentDisplayPage((int)Page.MainMenu);
        }

        private void DisplayAboutPage(object obj)
        {
            ChnageCurrentDisplayPage((int)Page.About);
        }

        private void DisplayCreditPage(object obj)
        {
            ChnageCurrentDisplayPage((int)Page.Credits);
        }

        private void DisplayPlayerCreationPage(object obj)
        {
            ChnageCurrentDisplayPage((int)Page.PlayerCreation);
        }

        private void DisplayIngamePage(object obj)
        {
            ChnageCurrentDisplayPage((int)Page.InGame);
        }
        #endregion


        /// <summary>
        /// A Page is a UserControl that encompasses the main window.
        /// They can be refered to as a scene.
        /// </summary>
        private enum Page
        {
            MainMenu,
            About,
            Credits,
            PlayerCreation,
            InGame
        }

    }
}
