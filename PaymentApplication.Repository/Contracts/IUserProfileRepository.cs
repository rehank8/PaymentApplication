using PaymentApplication.Models;
using PaymentApplication.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentApplication.Repository
{
    public interface IUserProfileRepository : IGenericRepository<UserProfile>
    {
        LoginViewModel Authenticate(LoginViewModel loginViewModel);
    }
}
