﻿// <auto-generated />
using System;
using Demo.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Demo.Persistence.Migrations
{
    [DbContext(typeof(DemoDbContext))]
    [Migration("20240224163555_SeedingBooks")]
    partial class SeedingBooks
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Demo.Domain.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Count = 10,
                            CreateDate = new DateTime(2024, 2, 24, 20, 5, 55, 280, DateTimeKind.Local).AddTicks(7746),
                            IsDeleted = false,
                            Title = "Love"
                        },
                        new
                        {
                            Id = 2,
                            Count = 20,
                            CreateDate = new DateTime(2024, 2, 24, 20, 5, 55, 280, DateTimeKind.Local).AddTicks(7762),
                            IsDeleted = false,
                            Title = "Hate"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
