using Finexa.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finexa.Data.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string? Description { get; set; }

        public TransactionType Type { get; set; }

        public int WalletId { get; set; }
        public required Wallet Wallet { get; set; }

        public int? TargetWalletId { get; set; }
        public Wallet? TargetWallet { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } = new User();
    }
}
