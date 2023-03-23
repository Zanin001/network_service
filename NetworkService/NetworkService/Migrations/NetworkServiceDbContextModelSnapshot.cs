﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetworkService.Data;

#nullable disable

namespace NetworkService.Migrations
{
    [DbContext(typeof(NetworkServiceDbContext))]
    partial class NetworkServiceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("NetworkService.Models.SmtpSettings", b =>
                {
                    b.Property<int?>("SmtpSettingsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("SmtpSettingsId");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Email");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Password");

                    b.Property<int>("Port")
                        .HasColumnType("int")
                        .HasColumnName("Port");

                    b.Property<string>("SMTP")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("SMTP");

                    b.Property<bool>("SSL")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("SSL");

                    b.HasKey("SmtpSettingsId");

                    b.ToTable("SmtpSettings");
                });
#pragma warning restore 612, 618
        }
    }
}
