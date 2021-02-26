﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WorkOrderCore.Infrastructure.Persistence.DataContext
{
    public partial class WorkOrderDBContext : DbContext
    {
        public WorkOrderDBContext()
        {
        }

        public WorkOrderDBContext(DbContextOptions<WorkOrderDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AssignTransaction> AssignTransaction { get; set; }
        public virtual DbSet<BusinessUnit> BusinessUnit { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeOccupancy> EmployeeOccupancy { get; set; }
        public virtual DbSet<JobActivities> JobActivities { get; set; }
        public virtual DbSet<JobCards> JobCards { get; set; }
        public virtual DbSet<JobCardsTransactions> JobCardsTransactions { get; set; }
        public virtual DbSet<JobCardsTransactionsLobs> JobCardsTransactionsLobs { get; set; }
        public virtual DbSet<LookupMaster> LookupMaster { get; set; }
        public virtual DbSet<Lookups> Lookups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-3UG1LAV\\SQLEXPRESS;Database=WorkOrderDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.Firstname).HasMaxLength(100);

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AssignTransaction>(entity =>
            {
                entity.HasKey(e => e.TransactionId);

                entity.Property(e => e.TransactionId).ValueGeneratedNever();
            });

            modelBuilder.Entity<BusinessUnit>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Alias).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Remarks).HasMaxLength(200);

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.JobDescription).HasMaxLength(200);

                entity.Property(e => e.NationalityId).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);
            });

            modelBuilder.Entity<EmployeeOccupancy>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.LastAssignedDate).HasColumnType("date");

                entity.Property(e => e.LastCancelDate).HasColumnType("date");

                entity.Property(e => e.LastCompletedDate).HasColumnType("date");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.EmployeeOccupancy)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeOccupancy_Employee");
            });

            modelBuilder.Entity<JobActivities>(entity =>
            {
                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.JobActivitiesStatus).HasMaxLength(100);

                entity.Property(e => e.JobActivityDescriptioin).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.HasOne(d => d.BuninessUnit)
                    .WithMany(p => p.JobActivities)
                    .HasForeignKey(d => d.BuninessUnitId)
                    .HasConstraintName("FK_JobActivities_BusinessUnit");
            });

            modelBuilder.Entity<JobCards>(entity =>
            {
                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.JobCardsRemarks).HasMaxLength(200);

                entity.Property(e => e.JobDescription)
                    .HasMaxLength(200)
                    .IsFixedLength();

                entity.Property(e => e.JobNumber).HasMaxLength(500);

                entity.Property(e => e.JobStatus).HasMaxLength(100);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.HasOne(d => d.BuninessUnit)
                    .WithMany(p => p.JobCards)
                    .HasForeignKey(d => d.BuninessUnitId)
                    .HasConstraintName("FK_JobCards_BusinessUnit");
            });

            modelBuilder.Entity<JobCardsTransactions>(entity =>
            {
                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.JobCardsTransactionsEndDate).HasColumnType("date");

                entity.Property(e => e.JobCardsTransactionsRemarks).HasMaxLength(200);

                entity.Property(e => e.JobCardsTransactionsStartDate).HasColumnType("date");

                entity.Property(e => e.JobCardsTransactionsStatus).HasMaxLength(100);

                entity.Property(e => e.UpdatedBy).HasMaxLength(450);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.JobCardsTransactions)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JobCardsTranasctions_Employee");

                entity.HasOne(d => d.JobActivity)
                    .WithMany(p => p.JobCardsTransactions)
                    .HasForeignKey(d => d.JobActivityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JobCardsTranasctions_JobActivities");

                entity.HasOne(d => d.JobCard)
                    .WithMany(p => p.JobCardsTransactions)
                    .HasForeignKey(d => d.JobCardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JobCardsTranasctions_JobCards1");
            });

            modelBuilder.Entity<JobCardsTransactionsLobs>(entity =>
            {
                entity.ToTable("JobCardsTransactionsLOBs");

                entity.Property(e => e.DocumentDescription).HasMaxLength(200);

                entity.Property(e => e.FileType).HasMaxLength(500);

                entity.Property(e => e.Lobdata)
                    .IsRequired()
                    .HasColumnName("LOBData");

                entity.HasOne(d => d.JobCardsTransactions)
                    .WithMany(p => p.JobCardsTransactionsLobs)
                    .HasForeignKey(d => d.JobCardsTransactionsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JobCardsTranasctionsLOBs_JobCardsTranasctions");
            });

            modelBuilder.Entity<LookupMaster>(entity =>
            {
                entity.HasKey(e => e.Alias);

                entity.Property(e => e.Alias).HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Lookups>(entity =>
            {
                entity.Property(e => e.Alias)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.MasterName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.MasterNameNavigation)
                    .WithMany(p => p.Lookups)
                    .HasForeignKey(d => d.MasterName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lookups_MasterLookup");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
