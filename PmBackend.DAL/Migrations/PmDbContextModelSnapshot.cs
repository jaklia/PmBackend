﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PmBackend.DAL;

namespace PmBackend.DAL.Migrations
{
    [DbContext(typeof(PmDbContext))]
    partial class PmDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PmBackend.DAL.Entities.Issue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EstimatedHours")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Issues");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DueDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EstimatedHours = 0,
                            ProjectId = 1,
                            StartDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Subject = "Sample Issue 1"
                        },
                        new
                        {
                            Id = 2,
                            DueDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EstimatedHours = 0,
                            ProjectId = 1,
                            StartDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Subject = "Sample Issue 2"
                        });
                });

            modelBuilder.Entity("PmBackend.DAL.Entities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Sample Project 1"
                        });
                });

            modelBuilder.Entity("PmBackend.DAL.Entities.TimeEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2021, 2, 23, 22, 13, 27, 56, DateTimeKind.Local).AddTicks(3363));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Hours")
                        .HasColumnType("int");

                    b.Property<int>("IssueId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IssueId");

                    b.ToTable("TimeEntries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateTime(2021, 2, 23, 22, 13, 27, 83, DateTimeKind.Local).AddTicks(3692),
                            Hours = 2,
                            IssueId = 1
                        },
                        new
                        {
                            Id = 2,
                            Date = new DateTime(2021, 2, 23, 22, 13, 27, 83, DateTimeKind.Local).AddTicks(5429),
                            Hours = 5,
                            IssueId = 1
                        },
                        new
                        {
                            Id = 3,
                            Date = new DateTime(2021, 2, 23, 22, 13, 27, 83, DateTimeKind.Local).AddTicks(5509),
                            Hours = 10,
                            IssueId = 2
                        });
                });

            modelBuilder.Entity("PmBackend.DAL.Entities.Issue", b =>
                {
                    b.HasOne("PmBackend.DAL.Entities.Project", "Project")
                        .WithMany("Issues")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("PmBackend.DAL.Entities.TimeEntry", b =>
                {
                    b.HasOne("PmBackend.DAL.Entities.Issue", "Issue")
                        .WithMany("timeEntries")
                        .HasForeignKey("IssueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Issue");
                });

            modelBuilder.Entity("PmBackend.DAL.Entities.Issue", b =>
                {
                    b.Navigation("timeEntries");
                });

            modelBuilder.Entity("PmBackend.DAL.Entities.Project", b =>
                {
                    b.Navigation("Issues");
                });
#pragma warning restore 612, 618
        }
    }
}
