using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Diagnostics;
namespace AttackSecuritySimulator_ViewModels
{
    /// <summary>
    /// Base ViewModel class that implements INotifyPropertyChanged interface.
    /// Inherit this class if the view model needs to constantly change its properties.
    /// 
    /// MVVM Setup Reference: https://www.technical-recipes.com/2016/switching-between-wpf-xaml-views-using-mvvm-datatemplate/
    /// </summary>
    public class BaseViewModelPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            VerifyPropertyName(propertyName);
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }

        }

        [Conditional("DEBUG")]
        private void VerifyPropertyName(string propertyName)
        {
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                throw new ArgumentNullException(GetType().Name + " does not contain property: " + propertyName);
            }
        }
    }
}
