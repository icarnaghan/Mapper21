﻿// <auto-generated />
using System;
using CurriculumStart.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CurriculumStart.API.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("CurriculumStart.API.Models.Element", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("SetId");

                    b.HasKey("Id");

                    b.HasIndex("SetId");

                    b.ToTable("Elements");
                });

            modelBuilder.Entity("CurriculumStart.API.Models.Field", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int?>("ElementId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("ElementId");

                    b.ToTable("Fields");
                });

            modelBuilder.Entity("CurriculumStart.API.Models.Map", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("GradeLower");

                    b.Property<string>("GradeUpper");

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("Subject");

                    b.HasKey("Id");

                    b.ToTable("Maps");
                });

            modelBuilder.Entity("CurriculumStart.API.Models.Module", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("Duration");

                    b.Property<int?>("MapId");

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("MapId");

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("CurriculumStart.API.Models.Set", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ModuleId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.ToTable("Sets");
                });

            modelBuilder.Entity("CurriculumStart.API.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CurriculumStart.API.Models.Value", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Values");
                });

            modelBuilder.Entity("CurriculumStart.API.Models.Element", b =>
                {
                    b.HasOne("CurriculumStart.API.Models.Set", "Set")
                        .WithMany()
                        .HasForeignKey("SetId");
                });

            modelBuilder.Entity("CurriculumStart.API.Models.Field", b =>
                {
                    b.HasOne("CurriculumStart.API.Models.Element", "Element")
                        .WithMany()
                        .HasForeignKey("ElementId");
                });

            modelBuilder.Entity("CurriculumStart.API.Models.Module", b =>
                {
                    b.HasOne("CurriculumStart.API.Models.Map", "Map")
                        .WithMany()
                        .HasForeignKey("MapId");
                });

            modelBuilder.Entity("CurriculumStart.API.Models.Set", b =>
                {
                    b.HasOne("CurriculumStart.API.Models.Module", "Module")
                        .WithMany()
                        .HasForeignKey("ModuleId");
                });
#pragma warning restore 612, 618
        }
    }
}