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

        public WebAddressLibraryModel(string ipAddress = "123.211.10.65")
        {
            webAddresses = new Uri[7];
            webAddresses[0] = new Uri(@"https://www.youtube.com/");
            webAddresses[1] = new Uri(@"https://www.facebook.com/");
            webAddresses[2] = new Uri(@"https://www.anz.com/INETBANK/bankmain.asp");
            webAddresses[3] = new Uri(@"https://www.paypal.com/signin");
            //Fake bank
            webAddresses[4] = new Uri($@"http://{ipAddress}/anz/ANZ%20Internet%20Banking.php");
            //Fake Paypal
            webAddresses[5] = new Uri($@"http://{ipAddress}/paypal/Log%20in%20to%20your%20PayPal%20account.php");
            //Home
            webAddresses[6] = new Uri($@"http://{ipAddress}/dashboard/");
        }

        public Uri RetrieveWebAddress(WebAddress indexer)
        {
            return webAddresses[(int)indexer];
        }

        //If the Ip address has changed, overwrite 
        public void RebuildAddressLibrary(string ipAddress)
        {
            webAddresses = new Uri[7];
            webAddresses[0] = new Uri(@"https://www.youtube.com/");
            webAddresses[1] = new Uri(@"https://www.facebook.com/");
            webAddresses[2] = new Uri(@"https://www.anz.com/INETBANK/bankmain.asp");
            webAddresses[3] = new Uri(@"https://www.paypal.com/signin");
            //Fake bank
            webAddresses[4] = new Uri($@"http://{ipAddress}/anz/ANZ%20Internet%20Banking.php");
            //Fake Paypal
            webAddresses[5] = new Uri($@"http://{ipAddress}/paypal/Log%20in%20to%20your%20PayPal%20account.php");
            //Home
            webAddresses[6] = new Uri($@"http://{ipAddress}/dashboard/");
        }
    }
}