﻿// <auto-generated />
using System;
using Laba_OOP.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Laba4._5_OOP.Storage.Migrations
{
    [DbContext(typeof(LibraryDataContext))]
    [Migration("20200523232821_InicialCreate3")]
    partial class InicialCreate3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Laba4._5_OOP.Storage.Entity.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("gId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("szName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tblAuthor");
                });

            modelBuilder.Entity("Laba4._5_OOP.Storage.Entity.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("gId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthorId")
                        .HasColumnName("gAuthor")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnName("gCategory")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("szName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CategoryId");

                    b.ToTable("tblBook");
                });

            modelBuilder.Entity("Laba4._5_OOP.Storage.Entity.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("gId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LibraryId")
                        .HasColumnName("gLibrary")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("szName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnName("intQuantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LibraryId");

                    b.ToTable("tblCategory");
                });

            modelBuilder.Entity("Laba4._5_OOP.Storage.Entity.CopyOfBook", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("gId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ReaderId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("ReaderId");

                    b.ToTable("tblCopyOfBook");
                });

            modelBuilder.Entity("Laba4._5_OOP.Storage.Entity.Library", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("gId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("szName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tblLibrary");
                });

            modelBuilder.Entity("Laba4._5_OOP.Storage.Entity.Worker", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("gWorkerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LibraryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("szName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnName("szPosition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Salary")
                        .HasColumnName("intSalary")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LibraryId");

                    b.ToTable("tblWorker");
                });

            modelBuilder.Entity("Laba_OOP.Storage.Entity.Reader", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("gId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("szSName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("szName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Registration")
                        .HasColumnName("tmRegistration")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("tblReader");
                });

            modelBuilder.Entity("Laba4._5_OOP.Storage.Entity.Book", b =>
                {
                    b.HasOne("Laba4._5_OOP.Storage.Entity.Author", "author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Laba4._5_OOP.Storage.Entity.Category", "category")
                        .WithMany("Books")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Laba4._5_OOP.Storage.Entity.Category", b =>
                {
                    b.HasOne("Laba4._5_OOP.Storage.Entity.Library", "Library")
                        .WithMany("Categories")
                        .HasForeignKey("LibraryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Laba4._5_OOP.Storage.Entity.CopyOfBook", b =>
                {
                    b.HasOne("Laba4._5_OOP.Storage.Entity.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Laba_OOP.Storage.Entity.Reader", "Reader")
                        .WithMany()
                        .HasForeignKey("ReaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Laba4._5_OOP.Storage.Entity.Worker", b =>
                {
                    b.HasOne("Laba4._5_OOP.Storage.Entity.Library", "Library")
                        .WithMany("Workers")
                        .HasForeignKey("LibraryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
