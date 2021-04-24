using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PaymentApplication.Models
{
    public class UserProfile
    {
        [Key]
        public string PKUserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public DateTime RegisteredDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public string Location { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }

        public string ImageUrl { get; set; }

        public string Gender { get; set; }

        [StringLength(300)]
        public string EmailId { get; set; }

        public string FKRoleId { get; set; }
        public UserRole UserRole { get; set; }
        public int OTP { get; set; }
        public DateTime OTPGeneratedDateTime { get; set; }
    }
}
