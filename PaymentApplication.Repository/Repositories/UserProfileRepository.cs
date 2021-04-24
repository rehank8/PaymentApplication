using Microsoft.EntityFrameworkCore;
using PaymentApplication.Models;
using PaymentApplication.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaymentApplication.Repository
{
    public class UserProfileRepository : GenericRepository<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(DbContext db) : base(db)
        {

        }

        public LoginViewModel Authenticate(LoginViewModel loginViewModel)
        {
            var user = ds.FirstOrDefault(x => x.EmailId.ToLower() == (loginViewModel.UserName.ToLower()));
            if (user != null)
            {
                loginViewModel.IsValid = user.Password == loginViewModel.Password ? true : false;
                if (loginViewModel.IsValid)
                {
                    loginViewModel.RoleName = _db.Set<UserRole>().FirstOrDefault(x => x.PKRoleId == user.FKRoleId).RoleName;
                    loginViewModel.UserProfile = user;
                }
               
            }
            return loginViewModel;
        }
    }
}
