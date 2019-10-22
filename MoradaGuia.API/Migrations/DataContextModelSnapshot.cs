﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoradaGuia.API.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MoradaGuia.API.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("MoradaGuia.API.Models.Comentario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment");

                    b.Property<string>("Email_FK");

                    b.Property<int>("Id_FK");

                    b.HasKey("Id");

                    b.HasIndex("Email_FK");

                    b.HasIndex("Id_FK");

                    b.ToTable("Comentario");
                });

            modelBuilder.Entity("MoradaGuia.API.Models.Imovel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<DateTime>("Data");

                    b.Property<string>("Email_FK");

                    b.Property<int>("Garagem");

                    b.Property<byte[]>("Imagem")
                        .IsRequired();

                    b.Property<int>("Numero");

                    b.Property<int>("Qtd_Banheiro");

                    b.Property<int>("Qtd_Quarto");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<float>("Valor");

                    b.HasKey("Id");

                    b.HasIndex("Email_FK");

                    b.ToTable("Imovel");
                });

            modelBuilder.Entity("MoradaGuia.API.Models.User", b =>
                {
                    b.Property<string>("Email")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(30);

                    b.Property<int>("Id");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("sobrenome")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<int>("telefone")
                        .HasMaxLength(15);

                    b.HasKey("Email");

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

            modelBuilder.Entity("MoradaGuia.API.Models.Comentario", b =>
                {
                    b.HasOne("MoradaGuia.API.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("Email_FK");

                    b.HasOne("MoradaGuia.API.Models.Imovel", "Imovel")
                        .WithMany()
                        .HasForeignKey("Id_FK")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MoradaGuia.API.Models.Imovel", b =>
                {
                    b.HasOne("MoradaGuia.API.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("Email_FK");
                });
#pragma warning restore 612, 618
        }
    }
}
