using Microsoft.EntityFrameworkCore;
using PaymentApplication.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentApplication.Repository
{
    public class UserRoleRepository : GenericRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(DbContext db) : base(db)
        {

        }
    }
}
