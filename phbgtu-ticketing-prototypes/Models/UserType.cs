using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace phbgtu_ticketing_prototypes.Models
{
    public class UserType
    {
        public int UserTypeID { get; set; }
        public string UserTypeName { get; set; }

        [NotMapped]
        public ICollection<UserAccount> UserAccounts { get; set; }

        public UserType()
        {

        }
    }
}
