using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AngularDemo.Models
{
    public partial class myDBContext : DbContext
    {
        public myDBContext()
        {
        }

        public myDBContext(DbContextOptions<myDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DepartmentMaster> DepartmentMaster { get; set; }
        public virtual DbSet<EmployeeMaster> EmployeeMaster { get; set; }
        public virtual DbSet<Table> Table { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=E:\\Users\\dhavaljoshi\\source\\repos\\AngularDemo\\AngularDemo\\App_Data\\dbEmployee.mdf;Integrated Security=True;Connect Timeout=30");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DepartmentMaster>(entity =>
            {
                entity.HasKey(e => e.DepartmentId);

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmployeeMaster>(entity =>
            {
                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.ContactNumber)
                    .HasColumnName("Contact_Number")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DepartmentId).HasDefaultValueSql("((0))");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Qualification)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Table>(entity =>
            {
                entity.HasKey(e => e.DepartmentId);

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
