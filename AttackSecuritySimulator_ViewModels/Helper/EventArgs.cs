using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttackSecuritySimulator_ViewModels
{
    /// <summary>
    /// Internal event system for raising events within a relay command changing its Action condition.
    /// 
    /// MVVM Set up reference : https://www.technical-recipes.com/2016/switching-between-wpf-xaml-views-using-mvvm-datatemplate/
    /// </summary>
    public class EventArgs<T> : EventArgs
    {
        public T Value { get; private set; }

        public EventArgs(T value)
        {
            Value = value;
        }
    }
}
