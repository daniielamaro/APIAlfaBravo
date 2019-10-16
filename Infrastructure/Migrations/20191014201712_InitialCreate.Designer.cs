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
    [Migration("20191014201712_InitialCreate")]
    partial class InitialCreate
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

                    b.Property<Guid?>("PublicationId");

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
                            Id = new Guid("f2462ffe-5c0e-447c-9c22-8a697fafa276"),
                            Name = "Cultura"
                        },
                        new
                        {
                            Id = new Guid("f6480e1f-80de-4a90-9ebf-d65e74aed60d"),
                            Name = "Economia"
                        },
                        new
                        {
                            Id = new Guid("86a473ae-b87f-478c-b710-ffa5b07060a0"),
                            Name = "Educação"
                        },
                        new
                        {
                            Id = new Guid("60b173df-ce3f-4275-9349-df4068921321"),
                            Name = "Entretenimento"
                        },
                        new
                        {
                            Id = new Guid("e5aa4451-38d2-4a24-9b80-84f360b795ec"),
                            Name = "Esporte"
                        },
                        new
                        {
                            Id = new Guid("67dcaf8d-7863-4580-babe-c6d8b0b5dee5"),
                            Name = "Política"
                        },
                        new
                        {
                            Id = new Guid("1422cf7b-53fc-4b45-aa0a-9bf70b6fab2b"),
                            Name = "Saúde"
                        },
                        new
                        {
                            Id = new Guid("9b80ee97-7800-42e1-9566-5a9255e1d1dd"),
                            Name = "Tecnologia"
                        },
                        new
                        {
                            Id = new Guid("d07e87e9-64d1-4c3a-b1de-627bfd5f3670"),
                            Name = "Tempo"
                        });
                });

            modelBuilder.Entity("Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Birthdate");

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
                        .WithMany("Comments")
                        .HasForeignKey("AutorId");

                    b.HasOne("Domain.Publication")
                        .WithMany("Comments")
                        .HasForeignKey("PublicationId");
                });

            modelBuilder.Entity("Domain.Publication", b =>
                {
                    b.HasOne("Domain.User", "Autor")
                        .WithMany("Publications")
                        .HasForeignKey("AutorId");

                    b.HasOne("Domain.Topic", "Topic")
                        .WithMany()
                        .HasForeignKey("TopicId");
                });
#pragma warning restore 612, 618
        }
    }
}
