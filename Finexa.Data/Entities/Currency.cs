using Finexa.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finexa.Data.Entities
{
    public class Currency
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Symbol { get; set; } = string.Empty;
        public CurrencyType Type { get; set; }

        public ICollection<FiatWallet> FiatWallets { get; set; } = new List<FiatWallet>();
        public ICollection<DigitalWallet> DigitalWallets { get; set; } = new List<DigitalWallet>();
        public ICollection<Platform> SupportedPlatforms { get; set; } = new List<Platform>();
    }
}
