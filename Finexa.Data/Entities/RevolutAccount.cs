using Finexa.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finexa.Data.Entities
{
    public class RevolutAccount : Account
    {
        public RevolutType Type { get; set; }

        public RevolutAccount(string firstname, string lastname, RevolutType revolutType) : base(firstname, lastname)
        {
            AccountType = AccountType.Revolut;
            Type = revolutType;
        }
    }
}
