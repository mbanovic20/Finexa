using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finexa.Data.Entities
{
    public class FiatWallet : Wallet
    {
        public Currency? Currency { get; set; }
    }
}
