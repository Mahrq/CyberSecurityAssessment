using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttackSecuritySimulator_Models
{
    /// <summary>
    /// Class containing various websites as well as the IP address of the server the game is hosted on.
    /// </summary>
    public class WebAddressLibraryModel
    {
        private Uri[] webAddresses;
        private Uri[] serverAddresses;

        public WebAddressLibraryModel()
        {
            webAddresses = new Uri[4];
            webAddresses[0] = new Uri(@"https://www.youtube.com/");
            webAddresses[1] = new Uri(@"https://www.facebook.com/");
            webAddresses[2] = new Uri(@"https://www.anz.com/INETBANK/bankmain.asp");
            webAddresses[3] = new Uri(@"https://www.paypal.com/signin");
            //TODO: Add 3 more array slots for web addresses and assign them to the server IPs.
        }

        public Uri RetrieveWebAddress(WebAddress indexer)
        {
            return webAddresses[(int)indexer];
        }
    }
}