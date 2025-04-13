using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Finexa.Data.Entities
{
    public class Day
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int MonthId { get; set; }
        public Month Month { get; set; } = new Month();

        public int? WeekId { get; set; }
        public Week? Week { get; set; }

        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
