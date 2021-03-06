﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoradaGuia.API.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MoradaGuia.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190918180248_AddUserCommentImmobileEntity2")]
    partial class AddUserCommentImmobileEntity2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("MoradaGuia.API.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MoradaGuia.API.Models.Usuario", b =>
                {
                    b.Property<string>("Email")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(30);

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("sobrenome")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<int>("telefone")
                        .HasMaxLength(15);

                    b.HasKey("Email");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("MoradaGuia.API.Models.Value", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Values");
                });
#pragma warning restore 612, 618
        }
    }
}
