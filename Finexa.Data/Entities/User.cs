using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finexa.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string PasswordHashed { get; set; } = string.Empty;
        public string Salt { get; set; } = string.Empty;

        public ICollection<Wallet> Wallets { get; set; } = new List<Wallet>();
        public ICollection<Card> Cards { get; set; } = new List<Card>();
    }
}
