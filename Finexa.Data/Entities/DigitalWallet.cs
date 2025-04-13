using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finexa.Data.Entities
{
    public class DigitalWallet : Wallet
    {
        public string WalletAddress { get; set; } = string.Empty;

        public int PlatformId { get; set; }
        public Platform Platform { get; set; } = new Platform();

        public int CurrencyId { get; set; }
        public Currency Currency { get; set; } = new Currency(); 
        
        public int? CardId { get; set; }
        public Card? Card { get; set; }
    }
}
