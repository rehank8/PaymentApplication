﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PaymentApplication.Models;

namespace PaymentApplication.Models.Migrations
{
    [DbContext(typeof(PaymentDBContext))]
    [Migration("20210405070532_AddedRole")]
    partial class AddedRole
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("PaymentApplication.Models.UserProfile", b =>
                {
                    b.Property<string>("PKUserId")
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<string>("EmailId")
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.Property<string>("FKRoleId")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastLoginDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<string>("MiddleName")
                        .HasColumnType("text");

                    b.Property<int>("OTP")
                        .HasColumnType("integer");

                    b.Property<DateTime>("OTPGeneratedDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<DateTime>("RegisteredDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("PKUserId");

                    b.HasIndex("EmailId")
                        .IsUnique();

                    b.HasIndex("FKRoleId");

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("PaymentApplication.Models.UserRole", b =>
                {
                    b.Property<string>("PKRoleId")
                        .HasColumnType("text");

                    b.Property<string>("RoleName")
                        .HasColumnType("text");

                    b.HasKey("PKRoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("PaymentApplication.Models.UserProfile", b =>
                {
                    b.HasOne("PaymentApplication.Models.UserRole", "UserRole")
                        .WithMany("UserProfiles")
                        .HasForeignKey("FKRoleId");

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("PaymentApplication.Models.UserRole", b =>
                {
                    b.Navigation("UserProfiles");
                });
#pragma warning restore 612, 618
        }
    }
}
