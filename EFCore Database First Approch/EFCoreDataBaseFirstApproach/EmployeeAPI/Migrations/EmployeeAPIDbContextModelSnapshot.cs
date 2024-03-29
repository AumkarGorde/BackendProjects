﻿// <auto-generated />
using System;
using EmployeeAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmployeeAPI.Migrations
{
    [DbContext(typeof(EmployeeAPIDbContext))]
    partial class EmployeeAPIDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmployeeAPI.Models.Departments", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DepartmentName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("DepartmentId")
                        .HasName("PK__Departme__B2079BED25E1450E");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("EmployeeAPI.Models.EmployeeDetails", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("EmployeeId");

                    b.ToTable("EmployeeDetails");
                });

            modelBuilder.Entity("EmployeeAPI.Models.EmployeeProjects", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId", "ProjectId")
                        .HasName("PK__Employee__6DB1E4FE2470D7B3");

                    b.HasIndex("ProjectId");

                    b.ToTable("EmployeeProjects");
                });

            modelBuilder.Entity("EmployeeAPI.Models.Employees", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int?>("EmployeeDetailsId")
                        .HasColumnType("int");

                    b.Property<string>("EmployeeName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("EmployeeId")
                        .HasName("PK__Employee__7AD04F11340B43A4");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("EmployeeDetailsId")
                        .IsUnique()
                        .HasFilter("[EmployeeDetailsId] IS NOT NULL");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EmployeeAPI.Models.Projects", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProjectName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("ProjectId")
                        .HasName("PK__Projects__761ABEF0803DC172");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("EmployeeAPI.Models.EmployeeProjects", b =>
                {
                    b.HasOne("EmployeeAPI.Models.Employees", "Employee")
                        .WithMany("EmployeeProjects")
                        .HasForeignKey("EmployeeId")
                        .HasConstraintName("FK__EmployeeP__Emplo__2B3F6F97")
                        .IsRequired();

                    b.HasOne("EmployeeAPI.Models.Projects", "Project")
                        .WithMany("EmployeeProjects")
                        .HasForeignKey("ProjectId")
                        .HasConstraintName("FK__EmployeeP__Proje__2C3393D0")
                        .IsRequired();
                });

            modelBuilder.Entity("EmployeeAPI.Models.Employees", b =>
                {
                    b.HasOne("EmployeeAPI.Models.Departments", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .HasConstraintName("FK__Employees__Depar__286302EC");

                    b.HasOne("EmployeeAPI.Models.EmployeeDetails", "EmployeeDetails")
                        .WithOne()
                        .HasForeignKey("EmployeeAPI.Models.Employees", "EmployeeDetailsId")
                        .HasConstraintName("FK__Employees__EmployeeDetailsId__manual1");
                });
#pragma warning restore 612, 618
        }
    }
}
