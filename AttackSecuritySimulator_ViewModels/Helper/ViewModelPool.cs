using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttackSecuritySimulator_ViewModels
{
    /// <summary>
    /// Collection system stores instances of all the ViewModels that subscribe to the pool for easier access to them
    /// and less reliance on static properties
    /// </summary>
    public static class ViewModelPool
    {
        private static readonly Dictionary<string, IPoolSubscriber> viewModelCollection = new Dictionary<string, IPoolSubscriber>();

        public static void AddToPool(string key, IPoolSubscriber instance)
        {
            if (viewModelCollection.ContainsKey(key))
            {
                viewModelCollection[key] = instance;
            }
            else
            {
                viewModelCollection.Add(key, instance);
            }
        }

        public static IPoolSubscriber GetInstance(string key)
        {
            if (viewModelCollection.ContainsKey(key))
            {
                if (viewModelCollection[key] != null)
                {
                    return viewModelCollection[key];
                }
            }
            return null;
        }
    }
}
