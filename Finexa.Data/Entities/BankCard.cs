using Finexa.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finexa.Data.Entities
{
    public class BankCard
    {
        public int BankCardId { get; set; }
        public string CardNumber { get; set; }
        public DateTime ExpirationDate { get; set; }

        public BankType CardType { get; set; }

        public int BankAccountId { get; set; }
        public BankAccount BankAccount { get; set; }
    }
}
