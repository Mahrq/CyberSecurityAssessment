using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttackSecuritySimulator_ViewModels
{
    /// <summary>
    /// Static event class that checks if there are any subscribers to an eventhandler before excuting the event.
    /// 
    /// MVVM Set up reference : https://www.technical-recipes.com/2016/switching-between-wpf-xaml-views-using-mvvm-datatemplate/
    /// </summary>
    public static class EventRaiser
    {
        public static void RaiseEvent(this EventHandler handler, object sender)
        {
            if (handler != null)
            {
                handler(sender, EventArgs.Empty);
            }
        }

        public static void RaiseEvent<T>(this EventHandler<EventArgs<T>> handler, object sender, T value)
        {
            if (handler != null)
            {
                handler(sender, new EventArgs<T>(value));
            }
        }

        public static void RaiseEvent<T>(this EventHandler<T> handler, object sender, T value) where T : EventArgs
        {
            if (handler != null)
            {
                handler(sender, value);
            }
        }

        public static void RaiseEvent<T>(this EventHandler<EventArgs<T>> handler, object sender, EventArgs<T> value)
        {
            if (handler != null)
            {
                handler(sender, value);
            }
        }
    }
}
