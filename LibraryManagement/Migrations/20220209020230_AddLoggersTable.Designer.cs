// <auto-generated />
using System;
using LibraryManagement.Models.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LibraryManagement.Migrations
{
    [DbContext(typeof(MyPostgreSQLContext))]
    [Migration("20220209020230_AddLoggersTable")]
    partial class AddLoggersTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("LibraryManagement.Models.Author", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.HasKey("Id");

                    b.ToTable("author");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            FirstName = "Machado",
                            LastName = "de Assis"
                        },
                        new
                        {
                            Id = 2L,
                            FirstName = "Joanne",
                            LastName = "Rowling"
                        },
                        new
                        {
                            Id = 3L,
                            FirstName = "Clarice",
                            LastName = "Lispector"
                        });
                });

            modelBuilder.Entity("LibraryManagement.Models.Book", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("AuthorId")
                        .HasColumnType("bigint")
                        .HasColumnName("author_id");

                    b.Property<long>("GenreId")
                        .HasColumnType("bigint")
                        .HasColumnName("genre_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("GenreId");

                    b.ToTable("book");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            AuthorId = 2L,
                            GenreId = 3L,
                            Name = "Harry Potter e a Pedra filosofal"
                        },
                        new
                        {
                            Id = 2L,
                            AuthorId = 1L,
                            GenreId = 2L,
                            Name = "O Alienista"
                        },
                        new
                        {
                            Id = 3L,
                            AuthorId = 3L,
                            GenreId = 1L,
                            Name = "A Hora da Estrela"
                        });
                });

            modelBuilder.Entity("LibraryManagement.Models.Genre", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("genre");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Romance"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Science Fiction"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "Fantasy"
                        });
                });

            modelBuilder.Entity("LibraryManagement.Models.Logger", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("action");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("path");

                    b.Property<string>("RequestValue")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("request_value");

                    b.Property<string>("ResponseValue")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("response_value");

                    b.Property<string>("StatusCode")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("status_code");

                    b.Property<DateTime>("TimeIncluded")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("hora_inclusao");

                    b.HasKey("Id");

                    b.ToTable("logger");
                });

            modelBuilder.Entity("LibraryManagement.Models.Book", b =>
                {
                    b.HasOne("LibraryManagement.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryManagement.Models.Genre", "Genre")
                        .WithMany("Books")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("LibraryManagement.Models.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("LibraryManagement.Models.Genre", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
