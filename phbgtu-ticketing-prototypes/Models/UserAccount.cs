using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace phbgtu_ticketing_prototypes.Models
{
    public class UserAccount
    {
        public int UserAccountID { get; set; }
        public int UserTypeID { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string PasswordHint { get; set; }

        [NotMapped]
        public UserType UserType { get; set; }

        public ICollection<Ticket> Tickets { get; set; } //this is the physical relation - one UserAccount to many Tickets

        public UserAccount()
        {

        }
    }
}
