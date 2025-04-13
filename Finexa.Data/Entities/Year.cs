using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finexa.Data.Entities
{
    public class Year
    {
        public int Id { get; set; }
        public int Value { get; set; }

        public ICollection<Month> Months { get; set; } = new List<Month>();
    }
}
