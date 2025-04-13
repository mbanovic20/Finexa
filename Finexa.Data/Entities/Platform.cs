using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finexa.Data.Entities
{
    public class Platform
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;
        public string IconPath { get; set; } = string.Empty;

        public ICollection<DigitalWallet> DigitalWallets { get; set; } = new List<DigitalWallet>();
        public ICollection<Card> Cards { get; set; } = new List<Card>();
        public ICollection<Currency> SupportedCurrencies { get; set; } = new List<Currency>();
    }
}
