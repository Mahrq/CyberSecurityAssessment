using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttackSecuritySimulator_ViewModels
{
    //Interface label that helps the ViewModelPool to collect instances of viewModels
    public interface IPoolSubscriber
    {
        /// <summary>
        /// Pass this method as a parameter when subscribing to the ViewModelPool
        /// </summary>
        string InstanceKey();
    }
}
