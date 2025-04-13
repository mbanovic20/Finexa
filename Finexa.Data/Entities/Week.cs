using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finexa.Data.Entities
{
    public class Week
    {
        public int Id { get; set; }
        public int WeekNumber { get; set; }

        public int MonthId { get; set; }
        public Month Month { get; set; } = new Month();

        public ICollection<Day> Days { get; set; } = new List<Day>();
    }
}
