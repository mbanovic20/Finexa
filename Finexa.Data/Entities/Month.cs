using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finexa.Data.Entities
{
    public class Month
    {
        public int Id { get; set; }
        public int Value { get; set; }

        public int YearId { get; set; }
        public Year Year { get; set; } = new Year();

        public ICollection<Week> Weeks { get; set; } = new List<Week>();
        public ICollection<Day> Days { get; set; } = new List<Day>();
    }
}
