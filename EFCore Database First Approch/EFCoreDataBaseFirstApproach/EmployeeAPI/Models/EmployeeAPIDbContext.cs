using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EmployeeAPI.Models
{
    public partial class EmployeeAPIDbContext : DbContext
    {
        public EmployeeAPIDbContext()
        {
        }

        public EmployeeAPIDbContext(DbContextOptions<EmployeeAPIDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<EmployeeProjects> EmployeeProjects { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-MBONB33;Initial Catalog=EmployeeProject;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departments>(entity =>
            {
                entity.HasKey(e => e.DepartmentId)
                    .HasName("PK__Departme__B2079BED25E1450E");

                entity.Property(e => e.DepartmentName).HasMaxLength(100);
            });

            modelBuilder.Entity<EmployeeProjects>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.ProjectId })
                    .HasName("PK__Employee__6DB1E4FE2470D7B3");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeProjects)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeP__Emplo__2B3F6F97");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.EmployeeProjects)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeP__Proje__2C3393D0");
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("PK__Employee__7AD04F11340B43A4");

                entity.Property(e => e.EmployeeName).HasMaxLength(100);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK__Employees__Depar__286302EC");
            });

            modelBuilder.Entity<Projects>(entity =>
            {
                entity.HasKey(e => e.ProjectId)
                    .HasName("PK__Projects__761ABEF0803DC172");

                entity.Property(e => e.ProjectName).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
