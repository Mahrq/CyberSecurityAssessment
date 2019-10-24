using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AttackSecuritySimulator_ViewModels
{
    /// <summary>
    /// Class provides functionality to the GUI by setting up the relay commands that
    /// the ViewModels use  
    /// 
    /// MVVM Set up reference : https://www.technical-recipes.com/2016/switching-between-wpf-xaml-views-using-mvvm-datatemplate/
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Action<object> actionCommand;
        private readonly Predicate<object> actionCondition;

        //Constructor for command if no condition is needed to for it execute.
        public RelayCommand(Action<object> action) : this(action, null)
        {
            actionCommand = action;
        }

        public RelayCommand(Action<object> action, Predicate<object> condition)
        {
            if (action == null)
            {
                throw new ArgumentNullException("action parameter is null");
            }
            actionCommand = action;
            actionCondition = condition;
        }

        #region ICommand Implementation

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return actionCondition == null || actionCondition(parameter);
        }

        public void Execute(object parameter)
        {
            actionCommand(parameter);
        }

        #endregion




        
    }
}
