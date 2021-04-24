using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaymentApplication.Models
{
    public static class DBInitializer
    {
        public static void Initialize(PaymentDBContext context)
        {
            context.Database.EnsureCreated();
            context.Database.Migrate();
            if (!context.UserRoles.Any())
            {
                var userRoles = new UserRole[]
                {
                new UserRole
                {
                    PKRoleId="1a680fef-030e-4abc-8a56-e4ffd8a52131",
                    RoleName="Admin"
                },
                new UserRole
                {
                    PKRoleId="40c2b055-5df7-4775-a781-9878ac5dbf29",
                    RoleName="User"
                },

                };
                foreach (UserRole role in userRoles)
                {
                    context.UserRoles.Add(role);
                }
                context.SaveChanges();

            }
            if (!context.UserProfiles.Any())
            {
                var userProfiles = new UserProfile[]
                {
                new UserProfile
                {
                    PKUserId="8bbc5a46-aa2c-4920-87bf-480f8e4a0b48",
                    FirstName="santosh",
                    MiddleName="",
                    LastName="test",
                    Password="abc@123",
                    RegisteredDate=DateTime.Now,
                    Location="Butwal",
                    Country="Nepal",
                    IsActive=true,
                    PhoneNumber="9876678766",
                    EmailId="test@gmail.com",
                    FKRoleId="1a680fef-030e-4abc-8a56-e4ffd8a52131"
                },

                new UserProfile
                {
                    PKUserId="7c226ba7-491b-4ce5-abb4-cc72994711eb",
                    FirstName="Sandeep",
                    MiddleName="",
                    LastName="test",
                    Password="abc@123",
                    RegisteredDate=DateTime.Now,
                    Location="Butwal",
                    Country="Nepal",
                    IsActive=true,
                    PhoneNumber="9876678766",
                    EmailId="test1@gmail.com",
                    FKRoleId="40c2b055-5df7-4775-a781-9878ac5dbf29"
                },

                };
                foreach (UserProfile user in userProfiles)
                {
                    context.UserProfiles.Add(user);
                }
                context.SaveChanges();

            }
        }
    }
}
