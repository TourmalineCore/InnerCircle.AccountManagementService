﻿// <auto-generated />


#nullable disable

using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NodaTime;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
namespace UserManagementService.DataAccess.Migrations
{
    [DbContext(typeof(AccountsDbContext))]
    [Migration("20221221153309_AddActualRolesAndPrivileges")]
    partial class AddActualRolesAndPrivileges
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RolePrivileges", b =>
                {
                    b.Property<long>("PrivilegesId")
                        .HasColumnType("bigint");

                    b.Property<long>("RolesId")
                        .HasColumnType("bigint");

                    b.HasKey("PrivilegesId", "RolesId");

                    b.HasIndex("RolesId");

                    b.ToTable("RolePrivileges");

                    b.HasData(
                        new
                        {
                            PrivilegesId = 1L,
                            RolesId = 1L
                        },
                        new
                        {
                            PrivilegesId = 1L,
                            RolesId = 2L
                        },
                        new
                        {
                            PrivilegesId = 2L,
                            RolesId = 2L
                        },
                        new
                        {
                            PrivilegesId = 3L,
                            RolesId = 2L
                        },
                        new
                        {
                            PrivilegesId = 1L,
                            RolesId = 3L
                        });
                });

            modelBuilder.Entity("UserManagementService.Core.Entities.Privilege", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Privilege");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "CanManageEmployees"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "CanViewAnalytic"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "CanViewFinanceForPayroll"
                        });
                });

            modelBuilder.Entity("UserManagementService.Core.Entities.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NormalizedName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Admin",
                            NormalizedName = "Admin"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "CEO",
                            NormalizedName = "CEO"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "Manager",
                            NormalizedName = "Manager"
                        },
                        new
                        {
                            Id = 4L,
                            Name = "Employee",
                            NormalizedName = "Employee"
                        });
                });

            modelBuilder.Entity("UserManagementService.Core.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<Instant?>("DeletedAtUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("RolePrivileges", b =>
                {
                    b.HasOne("UserManagementService.Core.Entities.Privilege", null)
                        .WithMany()
                        .HasForeignKey("PrivilegesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UserManagementService.Core.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UserManagementService.Core.Entities.User", b =>
                {
                    b.HasOne("UserManagementService.Core.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });
#pragma warning restore 612, 618
        }
    }
}
