﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApplication4.Data;

#nullable disable

namespace WebApplication4.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230208094917_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseSerialColumns(modelBuilder);

            modelBuilder.Entity("WebApplication4.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("LastDateUpdatePoints")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Points")
                        .HasColumnType("integer");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LastDateUpdatePoints = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Points = 1000,
                            StudentName = "Виктор Корнеплод"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
