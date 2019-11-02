using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttackSecuritySimulator_Models
{
    /// <summary>
    /// Class containing various websites as well as the IP address of the server the game is hosted on.
    /// 
    /// Default IP:     172.30.91.65
    /// Peter's IP:     123.211.10.65
    /// </summary>
    public class WebAddressLibraryModel
    {
        private Uri[] webAddresses;
        //private Uri[] serverAddresses;

        public WebAddressLibraryModel(string ipAddress = "123.211.10.65")
        {
            webAddresses = new Uri[5];
            webAddresses[0] = new Uri(@"https://www.youtube.com/");
            webAddresses[1] = new Uri(@"https://www.facebook.com/");
            webAddresses[2] = new Uri(@"https://www.anz.com/INETBANK/bankmain.asp");
            webAddresses[3] = new Uri(@"https://www.paypal.com/signin");
            //Home
            //Fake bank
            webAddresses[4] = new Uri($@"http://{ipAddress}/anz/anz.html");
            //Fake Paypal
            //TODO: Add 3 more array slots for web addresses and assign them to the server IPs.
        }

        public Uri RetrieveWebAddress(WebAddress indexer)
        {
            return webAddresses[(int)indexer];
        }
    }
}