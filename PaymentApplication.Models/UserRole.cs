using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PaymentApplication.Models
{
    public class UserRole
    {
        [Key]
        public string PKRoleId { get; set; }
        public string RoleName { get; set; }

        public List<UserProfile> UserProfiles { get; set; }
    }
}
