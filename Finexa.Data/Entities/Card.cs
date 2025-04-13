using Finexa.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finexa.Data.Entities
{
    public class Card
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Last4 { get; set; } = string.Empty;
        public CardType Type { get; set; }

        public int PlatformId { get; set; }
        public Platform Platform { get; set; } = new Platform();

        public int UserId { get; set; }
        public User User { get; set; } = new User();
    }
}
