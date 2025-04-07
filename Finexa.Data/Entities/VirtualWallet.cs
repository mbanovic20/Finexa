using Finexa.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finexa.Data.Entities
{
    public abstract class VirtualWallet : Wallet
    {
        protected VirtualWallet()
        {
            Type = WalletType.Virtual;
        }

        public int AccountId { get; set; }

        public Account Account { get; set; }
    }
}
