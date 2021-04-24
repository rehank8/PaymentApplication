using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentApplication.Models
{
    public class PaymentDBContext : DbContext
    {
        public PaymentDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProfile>().HasIndex(x => x.EmailId).IsUnique(true);

            modelBuilder.Entity<UserProfile>().HasOne(I => I.UserRole).WithMany(o => o.UserProfiles).HasForeignKey(x => x.FKRoleId);
        }
    }
}
