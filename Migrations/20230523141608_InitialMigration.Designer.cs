﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentDeptWebAPI.Models;

namespace StudentDeptWebAPI.Migrations
{
    [DbContext(typeof(StudentDeptContext))]
    [Migration("20230523141608_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StudentDeptWebAPI.Models.Department", b =>
                {
                    b.Property<int>("DepartmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DepartmentName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentID");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            DepartmentID = 101,
                            DepartmentName = "Computer Science & Engineering"
                        },
                        new
                        {
                            DepartmentID = 102,
                            DepartmentName = "Mechanical Engineering"
                        });
                });

            modelBuilder.Entity("StudentDeptWebAPI.Models.Student", b =>
                {
                    b.Property<int>("StudentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Course")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<double>("Percentage")
                        .HasColumnType("float");

                    b.Property<string>("Specialization")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentID");

                    b.HasIndex("DepartmentID");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            StudentID = 1001,
                            Course = "B.E",
                            DepartmentID = 101,
                            Percentage = 70.5,
                            Specialization = "Computer Science",
                            StudentName = "Arun"
                        },
                        new
                        {
                            StudentID = 1002,
                            Course = "B.E",
                            DepartmentID = 102,
                            Percentage = 78.5,
                            Specialization = "Mechanical",
                            StudentName = "Balaji"
                        });
                });

            modelBuilder.Entity("StudentDeptWebAPI.Models.User", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Email");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("StudentDeptWebAPI.Models.Student", b =>
                {
                    b.HasOne("StudentDeptWebAPI.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });
#pragma warning restore 612, 618
        }
    }
}
