using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttackSecuritySimulator_Models
{
    //used to index the WebAddressLibrary
    public enum WebAddress
    {
        //Real web addresses
        Youtube,
        FaceBook,
        ANZBank,
        PayPal,
        //Fake, set up, server addresses
        FakeBank,
        FakePayPal,
        Home

    }
}
