using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finexa.Data.Enums;

namespace Finexa.Data.Entities
{
    public class Zaba : BankAccount
    {
        public ICollection<BankCard> BankCards { get; set; }

        public Zaba(string firstname, string lastname) : base(firstname, lastname)
        {
            BankType = BankType.Zaba;
        }

        private ICollection<BankCard> GetZabaBankCards()
        {
            return 
        }
    }
}
