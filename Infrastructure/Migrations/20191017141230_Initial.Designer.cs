﻿// <auto-generated />
using System;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApiContext))]
    [Migration("20191017141230_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Domain.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AutorId");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(1200);

                    b.Property<Guid>("PublicationId");

                    b.HasKey("Id");

                    b.HasIndex("AutorId");

                    b.HasIndex("PublicationId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Domain.Publication", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AutorId");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(1200);

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<Guid?>("TopicId");

                    b.HasKey("Id");

                    b.HasIndex("AutorId");

                    b.HasIndex("TopicId");

                    b.ToTable("Publications");
                });

            modelBuilder.Entity("Domain.Topic", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Topics");

                    b.HasData(
                        new
                        {
                            Id = new Guid("025ed755-8dfe-48dd-87d8-f16da5de1522"),
                            Name = "Cultura"
                        },
                        new
                        {
                            Id = new Guid("d9eaa5d9-b871-4a1f-9287-f502cc6517b3"),
                            Name = "Economia"
                        },
                        new
                        {
                            Id = new Guid("468e40a9-368f-48ab-b525-68414e81eba0"),
                            Name = "Educação"
                        },
                        new
                        {
                            Id = new Guid("0e2ad91b-6a3c-4228-9006-b213b6857df0"),
                            Name = "Entretenimento"
                        },
                        new
                        {
                            Id = new Guid("d61d8c92-a7f5-496b-9559-cfa27e5033d3"),
                            Name = "Esporte"
                        },
                        new
                        {
                            Id = new Guid("7d1710aa-cde3-42a5-be34-eb0f7a3e167d"),
                            Name = "Política"
                        },
                        new
                        {
                            Id = new Guid("fae89cce-90ed-43a9-aa8d-5d7aafad7ced"),
                            Name = "Saúde"
                        },
                        new
                        {
                            Id = new Guid("4de6ef52-67f4-4ee7-81c7-44ec12f4c08e"),
                            Name = "Tecnologia"
                        },
                        new
                        {
                            Id = new Guid("4e9edd2c-55cb-467f-9755-25b0b520f134"),
                            Name = "Tempo"
                        });
                });

            modelBuilder.Entity("Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Comment", b =>
                {
                    b.HasOne("Domain.User", "Autor")
                        .WithMany()
                        .HasForeignKey("AutorId");

                    b.HasOne("Domain.Publication")
                        .WithMany("Comments")
                        .HasForeignKey("PublicationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Publication", b =>
                {
                    b.HasOne("Domain.User", "Autor")
                        .WithMany()
                        .HasForeignKey("AutorId");

                    b.HasOne("Domain.Topic", "Topic")
                        .WithMany()
                        .HasForeignKey("TopicId");
                });
#pragma warning restore 612, 618
        }
    }
}
