using Finexa.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finexa.Data.Entities
{
    public abstract class Account
    {
        public int AccountId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public AccountType AccountType { get; set; }

        protected Account(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }
    }
}
