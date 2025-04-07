using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finexa.Data.Entities
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public DateTime Date { get; set; }      
        public decimal Amount { get; set; }
        public string? Description { get; set; }
    }
}
