﻿using Finexa.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finexa.Data.Entities
{
    public abstract class Wallet
    {
        public int WalletId { get; set; }
        public WalletType Type { get; set; }
        public decimal Balance { get; set; }
    }
}
