using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace AttackSecuritySimulator_ViewModels
{
    /// <summary>
    /// Base ViewModel class that implements INotifyPropertyChanged interface.
    /// Inherit this class 
    /// </summary>
    public class ViewModelPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, eArgs) => { };
    }
}
