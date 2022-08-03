﻿// <auto-generated />
using System;
using DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220803134420_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entities.Concrete.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthorId"), 1L, 1);

                    b.Property<string>("Life")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("YearOfBirth")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            AuthorId = 1,
                            Life = "Trabzonda doğdu ilk kitabı",
                            Name = "Ahmet",
                            Surname = "Hamdi",
                            YearOfBirth = "2002"
                        },
                        new
                        {
                            AuthorId = 2,
                            Life = "Trabzonda doğdu ilk kitabı",
                            Name = "Samet",
                            Surname = "Uslu",
                            YearOfBirth = "1987"
                        },
                        new
                        {
                            AuthorId = 3,
                            Life = "Trabzonda doğdu ilk kitabı",
                            Name = "Doğan",
                            Surname = "Atalar",
                            YearOfBirth = "1965"
                        },
                        new
                        {
                            AuthorId = 4,
                            Life = "Trabzonda doğdu ilk kitabı",
                            Name = "Cevher",
                            Surname = "Küçük",
                            YearOfBirth = "1980"
                        },
                        new
                        {
                            AuthorId = 5,
                            Life = "Trabzonda doğdu ilk kitabı",
                            Name = "Nafize",
                            Surname = "Tezyürek",
                            YearOfBirth = "1957"
                        },
                        new
                        {
                            AuthorId = 6,
                            Life = "Trabzonda doğdu ilk kitabı",
                            Name = "ceyhan",
                            Surname = "Karslıoğlu",
                            YearOfBirth = "1993"
                        },
                        new
                        {
                            AuthorId = 7,
                            Life = "Trabzonda doğdu ilk kitabı",
                            Name = "Yusuf",
                            Surname = "Hacıoğlu",
                            YearOfBirth = "1990"
                        },
                        new
                        {
                            AuthorId = 8,
                            Life = "Trabzonda doğdu ilk kitabı",
                            Name = "Ahmet",
                            Surname = "Fazıl",
                            YearOfBirth = "1986"
                        },
                        new
                        {
                            AuthorId = 9,
                            Life = "Trabzonda doğdu ilk kitabı",
                            Name = "selçuk",
                            Surname = "Bulut",
                            YearOfBirth = "1967"
                        },
                        new
                        {
                            AuthorId = 10,
                            Life = "Trabzonda doğdu ilk kitabı",
                            Name = "Arda",
                            Surname = "Yılmaz",
                            YearOfBirth = "1965"
                        });
                });

            modelBuilder.Entity("Entities.Concrete.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"), 1L, 1);

                    b.Property<string>("BookName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("BookSummary")
                        .IsRequired()
                        .HasMaxLength(1500)
                        .HasColumnType("nvarchar(1500)");

                    b.Property<int>("IsbnId")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<string>("NumberOfPages")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.HasKey("BookId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            BookName = "Küçükler",
                            BookSummary = "Güzel bir kitap",
                            IsbnId = 123456,
                            NumberOfPages = "365"
                        },
                        new
                        {
                            BookId = 2,
                            BookName = "Küçükler",
                            BookSummary = "Güzel bir kitap",
                            IsbnId = 126523,
                            NumberOfPages = "365"
                        },
                        new
                        {
                            BookId = 3,
                            BookName = "Küçükler",
                            BookSummary = "Güzel bir kitap",
                            IsbnId = 789653,
                            NumberOfPages = "365"
                        },
                        new
                        {
                            BookId = 4,
                            BookName = "Küçükler",
                            BookSummary = "Güzel bir kitap",
                            IsbnId = 986547,
                            NumberOfPages = "365"
                        },
                        new
                        {
                            BookId = 5,
                            BookName = "Küçükler",
                            BookSummary = "Güzel bir kitap",
                            IsbnId = 120365,
                            NumberOfPages = "365"
                        },
                        new
                        {
                            BookId = 6,
                            BookName = "Küçükler",
                            BookSummary = "Güzel bir kitap",
                            IsbnId = 986325,
                            NumberOfPages = "365"
                        },
                        new
                        {
                            BookId = 7,
                            BookName = "Küçükler",
                            BookSummary = "Güzel bir kitap",
                            IsbnId = 456378,
                            NumberOfPages = "365"
                        },
                        new
                        {
                            BookId = 8,
                            BookName = "Küçükler",
                            BookSummary = "Güzel bir kitap",
                            IsbnId = 986514,
                            NumberOfPages = "365"
                        },
                        new
                        {
                            BookId = 9,
                            BookName = "Küçükler",
                            BookSummary = "Güzel bir kitap",
                            IsbnId = 203654,
                            NumberOfPages = "365"
                        },
                        new
                        {
                            BookId = 10,
                            BookName = "Küçükler",
                            BookSummary = "Güzel bir kitap",
                            IsbnId = 745822,
                            NumberOfPages = "365"
                        });
                });

            modelBuilder.Entity("Entities.Concrete.BookAuthor", b =>
                {
                    b.Property<int>("BookAuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookAuthorId"), 1L, 1);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.HasKey("BookAuthorId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BookId");

                    b.ToTable("BookAuthors");

                    b.HasData(
                        new
                        {
                            BookAuthorId = 1,
                            AuthorId = 1,
                            BookId = 1
                        },
                        new
                        {
                            BookAuthorId = 2,
                            AuthorId = 1,
                            BookId = 2
                        },
                        new
                        {
                            BookAuthorId = 3,
                            AuthorId = 1,
                            BookId = 3
                        },
                        new
                        {
                            BookAuthorId = 4,
                            AuthorId = 2,
                            BookId = 1
                        },
                        new
                        {
                            BookAuthorId = 5,
                            AuthorId = 2,
                            BookId = 4
                        },
                        new
                        {
                            BookAuthorId = 6,
                            AuthorId = 2,
                            BookId = 5
                        },
                        new
                        {
                            BookAuthorId = 7,
                            AuthorId = 3,
                            BookId = 5
                        },
                        new
                        {
                            BookAuthorId = 8,
                            AuthorId = 3,
                            BookId = 6
                        },
                        new
                        {
                            BookAuthorId = 9,
                            AuthorId = 4,
                            BookId = 7
                        },
                        new
                        {
                            BookAuthorId = 10,
                            AuthorId = 5,
                            BookId = 8
                        },
                        new
                        {
                            BookAuthorId = 11,
                            AuthorId = 6,
                            BookId = 9
                        },
                        new
                        {
                            BookAuthorId = 12,
                            AuthorId = 7,
                            BookId = 10
                        });
                });

            modelBuilder.Entity("Entities.Concrete.BookType", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("BookId", "TypeId");

                    b.HasIndex("TypeId");

                    b.ToTable("BookTypes");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            TypeId = 1
                        },
                        new
                        {
                            BookId = 1,
                            TypeId = 2
                        },
                        new
                        {
                            BookId = 2,
                            TypeId = 1
                        },
                        new
                        {
                            BookId = 3,
                            TypeId = 4
                        },
                        new
                        {
                            BookId = 6,
                            TypeId = 8
                        },
                        new
                        {
                            BookId = 5,
                            TypeId = 3
                        },
                        new
                        {
                            BookId = 3,
                            TypeId = 5
                        },
                        new
                        {
                            BookId = 9,
                            TypeId = 2
                        },
                        new
                        {
                            BookId = 6,
                            TypeId = 1
                        },
                        new
                        {
                            BookId = 4,
                            TypeId = 1
                        });
                });

            modelBuilder.Entity("Entities.Concrete.Member", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MemberId"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("MemberId");

                    b.ToTable("Members");

                    b.HasData(
                        new
                        {
                            MemberId = 1,
                            Address = "Trabzon",
                            Lastname = "Revi",
                            Name = "Ahmet",
                            isActive = true
                        },
                        new
                        {
                            MemberId = 2,
                            Address = "Trabzon",
                            Lastname = "Korkmaz",
                            Name = "Cemil",
                            isActive = true
                        },
                        new
                        {
                            MemberId = 3,
                            Address = "Trabzon",
                            Lastname = "Salihoğlu",
                            Name = "Ahmet",
                            isActive = true
                        },
                        new
                        {
                            MemberId = 4,
                            Address = "Trabzon",
                            Lastname = "Ağaoğlu",
                            Name = "Serkan",
                            isActive = true
                        },
                        new
                        {
                            MemberId = 5,
                            Address = "Trabzon",
                            Lastname = "Durak",
                            Name = "Zeynep",
                            isActive = true
                        },
                        new
                        {
                            MemberId = 6,
                            Address = "Trabzon",
                            Lastname = "Pınar",
                            Name = "Özgür",
                            isActive = true
                        },
                        new
                        {
                            MemberId = 7,
                            Address = "Trabzon",
                            Lastname = "Olgun",
                            Name = "Cemile",
                            isActive = true
                        },
                        new
                        {
                            MemberId = 8,
                            Address = "Trabzon",
                            Lastname = "Civelek",
                            Name = "Mehmet",
                            isActive = true
                        },
                        new
                        {
                            MemberId = 9,
                            Address = "Trabzon",
                            Lastname = "Akkaya",
                            Name = "Dursun",
                            isActive = true
                        },
                        new
                        {
                            MemberId = 10,
                            Address = "Trabzon",
                            Lastname = "Kurumlu",
                            Name = "Fazlı",
                            isActive = true
                        });
                });

            modelBuilder.Entity("Entities.Concrete.Onloan", b =>
                {
                    b.Property<int>("OnloanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OnloanId"), 1L, 1);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("DeliveryTime")
                        .HasColumnType("int");

                    b.Property<DateTime>("LendingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<int>("StateEnum")
                        .HasColumnType("int");

                    b.HasKey("OnloanId");

                    b.HasIndex("BookId");

                    b.HasIndex("MemberId");

                    b.ToTable("Onloans");

                    b.HasData(
                        new
                        {
                            OnloanId = 1,
                            BookId = 1,
                            DeliveryTime = 15,
                            LendingDate = new DateTime(2022, 8, 3, 16, 44, 20, 178, DateTimeKind.Local).AddTicks(5002),
                            MemberId = 1,
                            StateEnum = 0
                        },
                        new
                        {
                            OnloanId = 2,
                            BookId = 2,
                            DeliveryTime = 15,
                            LendingDate = new DateTime(2022, 8, 3, 16, 44, 20, 178, DateTimeKind.Local).AddTicks(5019),
                            MemberId = 2,
                            StateEnum = 0
                        },
                        new
                        {
                            OnloanId = 3,
                            BookId = 3,
                            DeliveryTime = 15,
                            LendingDate = new DateTime(2022, 8, 3, 16, 44, 20, 178, DateTimeKind.Local).AddTicks(5022),
                            MemberId = 3,
                            StateEnum = 0
                        },
                        new
                        {
                            OnloanId = 4,
                            BookId = 4,
                            DeliveryTime = 15,
                            LendingDate = new DateTime(2022, 8, 3, 16, 44, 20, 178, DateTimeKind.Local).AddTicks(5024),
                            MemberId = 4,
                            StateEnum = 0
                        },
                        new
                        {
                            OnloanId = 5,
                            BookId = 5,
                            DeliveryTime = 15,
                            LendingDate = new DateTime(2022, 8, 3, 16, 44, 20, 178, DateTimeKind.Local).AddTicks(5025),
                            MemberId = 5,
                            StateEnum = 0
                        },
                        new
                        {
                            OnloanId = 6,
                            BookId = 6,
                            DeliveryTime = 15,
                            LendingDate = new DateTime(2022, 8, 3, 16, 44, 20, 178, DateTimeKind.Local).AddTicks(5028),
                            MemberId = 8,
                            StateEnum = 0
                        });
                });

            modelBuilder.Entity("Entities.Concrete.Type", b =>
                {
                    b.Property<int>("TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TypeId"), 1L, 1);

                    b.Property<string>("TypeExplanation")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("TypeId");

                    b.ToTable("Types");

                    b.HasData(
                        new
                        {
                            TypeId = 1,
                            TypeExplanation = "Polisiye"
                        },
                        new
                        {
                            TypeId = 2,
                            TypeExplanation = "Roman"
                        },
                        new
                        {
                            TypeId = 3,
                            TypeExplanation = "Masal"
                        },
                        new
                        {
                            TypeId = 4,
                            TypeExplanation = "Hikaye"
                        },
                        new
                        {
                            TypeId = 5,
                            TypeExplanation = "Tarih"
                        },
                        new
                        {
                            TypeId = 6,
                            TypeExplanation = "Ekonomi"
                        },
                        new
                        {
                            TypeId = 7,
                            TypeExplanation = "Genel Kültür"
                        },
                        new
                        {
                            TypeId = 8,
                            TypeExplanation = "Şiir"
                        },
                        new
                        {
                            TypeId = 9,
                            TypeExplanation = "Makale"
                        },
                        new
                        {
                            TypeId = 10,
                            TypeExplanation = "Sağlık"
                        });
                });

            modelBuilder.Entity("Entities.Concrete.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RefreshTokenEndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Entities.Concrete.BookAuthor", b =>
                {
                    b.HasOne("Entities.Concrete.Author", "Author")
                        .WithMany("BookAuthors")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Concrete.Book", "Book")
                        .WithMany("BookAuthors")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Entities.Concrete.BookType", b =>
                {
                    b.HasOne("Entities.Concrete.Book", "Book")
                        .WithMany("BookTypes")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Entities.Concrete.Type", "Type")
                        .WithMany("BookTypes")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("Entities.Concrete.Onloan", b =>
                {
                    b.HasOne("Entities.Concrete.Book", "Book")
                        .WithMany("Onloans")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Concrete.Member", "Member")
                        .WithMany("Onloans")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("Entities.Concrete.Author", b =>
                {
                    b.Navigation("BookAuthors");
                });

            modelBuilder.Entity("Entities.Concrete.Book", b =>
                {
                    b.Navigation("BookAuthors");

                    b.Navigation("BookTypes");

                    b.Navigation("Onloans");
                });

            modelBuilder.Entity("Entities.Concrete.Member", b =>
                {
                    b.Navigation("Onloans");
                });

            modelBuilder.Entity("Entities.Concrete.Type", b =>
                {
                    b.Navigation("BookTypes");
                });
#pragma warning restore 612, 618
        }
    }
}
