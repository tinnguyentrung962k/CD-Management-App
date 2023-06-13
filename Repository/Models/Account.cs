using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class Account
    {
        public int AccountId { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string RoleId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public virtual Role Role { get; set; }
    }
}
