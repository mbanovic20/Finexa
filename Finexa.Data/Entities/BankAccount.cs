using Finexa.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finexa.Data.Entities
{
    public abstract class BankAccount : Account
    {
        public BankType BankType { get; set; }

        protected BankAccount(string firstname, string lastname) : base(firstname, lastname)
        {
        }
    }
}
