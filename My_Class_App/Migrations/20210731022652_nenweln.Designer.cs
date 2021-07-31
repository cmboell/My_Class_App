﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using My_Classes_App.Models;

namespace My_Classes_App.Migrations
{
    [DbContext(typeof(MyClassContext))]
    [Migration("20210731022652_nenweln")]
    partial class nenweln
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("My_Classes_App.Models.Class", b =>
                {
                    b.Property<int>("ClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClassTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("ClassTypeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.Property<double>("NumberOfCredits")
                        .HasColumnType("float");

                    b.HasKey("ClassId");

                    b.HasIndex("ClassTypeId");

                    b.ToTable("Classes");

                    b.HasData(
                        new
                        {
                            ClassId = 1,
                            ClassTitle = "1776",
                            ClassTypeId = "history",
                            NumberOfCredits = 18.0
                        },
                        new
                        {
                            ClassId = 2,
                            ClassTitle = "1984",
                            ClassTypeId = "scifi",
                            NumberOfCredits = 5.5
                        },
                        new
                        {
                            ClassId = 3,
                            ClassTitle = "And Then There Were None",
                            ClassTypeId = "mystery",
                            NumberOfCredits = 4.5
                        },
                        new
                        {
                            ClassId = 4,
                            ClassTitle = "Band of Brothers",
                            ClassTypeId = "history",
                            NumberOfCredits = 11.5
                        },
                        new
                        {
                            ClassId = 5,
                            ClassTitle = "Beloved",
                            ClassTypeId = "novel",
                            NumberOfCredits = 10.99
                        },
                        new
                        {
                            ClassId = 6,
                            ClassTitle = "Between the World and Me",
                            ClassTypeId = "memoir",
                            NumberOfCredits = 13.5
                        },
                        new
                        {
                            ClassId = 7,
                            ClassTitle = "Bossypants",
                            ClassTypeId = "memoir",
                            NumberOfCredits = 4.25
                        },
                        new
                        {
                            ClassId = 8,
                            ClassTitle = "Brave New World",
                            ClassTypeId = "scifi",
                            NumberOfCredits = 16.25
                        },
                        new
                        {
                            ClassId = 9,
                            ClassTitle = "D-Day",
                            ClassTypeId = "history",
                            NumberOfCredits = 15.0
                        },
                        new
                        {
                            ClassId = 10,
                            ClassTitle = "Down and Out in Paris and London",
                            ClassTypeId = "memoir",
                            NumberOfCredits = 12.5
                        },
                        new
                        {
                            ClassId = 11,
                            ClassTitle = "Dune",
                            ClassTypeId = "scifi",
                            NumberOfCredits = 8.75
                        },
                        new
                        {
                            ClassId = 12,
                            ClassTitle = "Emma",
                            ClassTypeId = "novel",
                            NumberOfCredits = 9.0
                        },
                        new
                        {
                            ClassId = 13,
                            ClassTitle = "Frankenstein",
                            ClassTypeId = "scifi",
                            NumberOfCredits = 6.5
                        },
                        new
                        {
                            ClassId = 14,
                            ClassTitle = "Go Tell it on the Mountain",
                            ClassTypeId = "novel",
                            NumberOfCredits = 10.25
                        },
                        new
                        {
                            ClassId = 15,
                            ClassTitle = "Guns, Germs, and Steel",
                            ClassTypeId = "history",
                            NumberOfCredits = 15.5
                        },
                        new
                        {
                            ClassId = 16,
                            ClassTitle = "Hunger",
                            ClassTypeId = "memoir",
                            NumberOfCredits = 14.5
                        },
                        new
                        {
                            ClassId = 17,
                            ClassTitle = "Murder on the Orient Express",
                            ClassTypeId = "mystery",
                            NumberOfCredits = 6.75
                        },
                        new
                        {
                            ClassId = 18,
                            ClassTitle = "Pride and Prejudice",
                            ClassTypeId = "novel",
                            NumberOfCredits = 8.5
                        },
                        new
                        {
                            ClassId = 19,
                            ClassTitle = "Rebecca",
                            ClassTypeId = "mystery",
                            NumberOfCredits = 10.99
                        },
                        new
                        {
                            ClassId = 20,
                            ClassTitle = "The Art of War",
                            ClassTypeId = "history",
                            NumberOfCredits = 5.75
                        },
                        new
                        {
                            ClassId = 21,
                            ClassTitle = "The Girl with the Dragon Tattoo",
                            ClassTypeId = "mystery",
                            NumberOfCredits = 8.5
                        },
                        new
                        {
                            ClassId = 22,
                            ClassTitle = "The Handmaid's Tale",
                            ClassTypeId = "scifi",
                            NumberOfCredits = 12.5
                        },
                        new
                        {
                            ClassId = 23,
                            ClassTitle = "The Maltese Falcon",
                            ClassTypeId = "mystery",
                            NumberOfCredits = 10.99
                        },
                        new
                        {
                            ClassId = 24,
                            ClassTitle = "The New Jim Crow",
                            ClassTypeId = "history",
                            NumberOfCredits = 13.75
                        },
                        new
                        {
                            ClassId = 25,
                            ClassTitle = "The Year of Magical Thinking",
                            ClassTypeId = "memoir",
                            NumberOfCredits = 13.5
                        },
                        new
                        {
                            ClassId = 26,
                            ClassTitle = "Wuthering Heights",
                            ClassTypeId = "novel",
                            NumberOfCredits = 9.0
                        },
                        new
                        {
                            ClassId = 27,
                            ClassTitle = "Running With Scissors",
                            ClassTypeId = "memoir",
                            NumberOfCredits = 11.0
                        },
                        new
                        {
                            ClassId = 28,
                            ClassTitle = "Pride and Prejudice and Zombies",
                            ClassTypeId = "novel",
                            NumberOfCredits = 8.75
                        },
                        new
                        {
                            ClassId = 29,
                            ClassTitle = "Harry Potter and the Sorcerer's Stone",
                            ClassTypeId = "novel",
                            NumberOfCredits = 9.75
                        });
                });

            modelBuilder.Entity("My_Classes_App.Models.ClassTeacher", b =>
                {
                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("ClassId", "TeacherId");

                    b.HasIndex("TeacherId");

                    b.ToTable("ClassTeachers");

                    b.HasData(
                        new
                        {
                            ClassId = 1,
                            TeacherId = 18
                        },
                        new
                        {
                            ClassId = 2,
                            TeacherId = 20
                        },
                        new
                        {
                            ClassId = 3,
                            TeacherId = 7
                        },
                        new
                        {
                            ClassId = 4,
                            TeacherId = 2
                        },
                        new
                        {
                            ClassId = 5,
                            TeacherId = 19
                        },
                        new
                        {
                            ClassId = 6,
                            TeacherId = 8
                        },
                        new
                        {
                            ClassId = 7,
                            TeacherId = 12
                        },
                        new
                        {
                            ClassId = 8,
                            TeacherId = 16
                        },
                        new
                        {
                            ClassId = 9,
                            TeacherId = 2
                        },
                        new
                        {
                            ClassId = 10,
                            TeacherId = 20
                        },
                        new
                        {
                            ClassId = 11,
                            TeacherId = 15
                        },
                        new
                        {
                            ClassId = 12,
                            TeacherId = 4
                        },
                        new
                        {
                            ClassId = 13,
                            TeacherId = 21
                        },
                        new
                        {
                            ClassId = 14,
                            TeacherId = 5
                        },
                        new
                        {
                            ClassId = 15,
                            TeacherId = 9
                        },
                        new
                        {
                            ClassId = 16,
                            TeacherId = 13
                        },
                        new
                        {
                            ClassId = 17,
                            TeacherId = 7
                        },
                        new
                        {
                            ClassId = 18,
                            TeacherId = 4
                        },
                        new
                        {
                            ClassId = 19,
                            TeacherId = 11
                        },
                        new
                        {
                            ClassId = 20,
                            TeacherId = 22
                        },
                        new
                        {
                            ClassId = 21,
                            TeacherId = 17
                        },
                        new
                        {
                            ClassId = 22,
                            TeacherId = 3
                        },
                        new
                        {
                            ClassId = 23,
                            TeacherId = 14
                        },
                        new
                        {
                            ClassId = 24,
                            TeacherId = 1
                        },
                        new
                        {
                            ClassId = 25,
                            TeacherId = 10
                        },
                        new
                        {
                            ClassId = 26,
                            TeacherId = 6
                        },
                        new
                        {
                            ClassId = 27,
                            TeacherId = 23
                        },
                        new
                        {
                            ClassId = 28,
                            TeacherId = 4
                        },
                        new
                        {
                            ClassId = 28,
                            TeacherId = 26
                        },
                        new
                        {
                            ClassId = 29,
                            TeacherId = 25
                        });
                });

            modelBuilder.Entity("My_Classes_App.Models.ClassType", b =>
                {
                    b.Property<string>("ClassTypeId")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.HasKey("ClassTypeId");

                    b.ToTable("ClassTypes");

                    b.HasData(
                        new
                        {
                            ClassTypeId = "novel",
                            Name = "Novel"
                        },
                        new
                        {
                            ClassTypeId = "memoir",
                            Name = "Memoir"
                        },
                        new
                        {
                            ClassTypeId = "mystery",
                            Name = "Mystery"
                        },
                        new
                        {
                            ClassTypeId = "scifi",
                            Name = "Science Fiction"
                        },
                        new
                        {
                            ClassTypeId = "history",
                            Name = "History"
                        });
                });

            modelBuilder.Entity("My_Classes_App.Models.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("TeacherId");

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            TeacherId = 1,
                            FirstName = "Michelle",
                            LastName = "Alexander"
                        },
                        new
                        {
                            TeacherId = 2,
                            FirstName = "Stephen E.",
                            LastName = "Ambrose"
                        },
                        new
                        {
                            TeacherId = 3,
                            FirstName = "Margaret",
                            LastName = "Atwood"
                        },
                        new
                        {
                            TeacherId = 4,
                            FirstName = "Jane",
                            LastName = "Austen"
                        },
                        new
                        {
                            TeacherId = 5,
                            FirstName = "James",
                            LastName = "Baldwin"
                        },
                        new
                        {
                            TeacherId = 6,
                            FirstName = "Emily",
                            LastName = "Bronte"
                        },
                        new
                        {
                            TeacherId = 7,
                            FirstName = "Agatha",
                            LastName = "Christie"
                        },
                        new
                        {
                            TeacherId = 8,
                            FirstName = "Ta-Nehisi",
                            LastName = "Coates"
                        },
                        new
                        {
                            TeacherId = 9,
                            FirstName = "Jared",
                            LastName = "Diamond"
                        },
                        new
                        {
                            TeacherId = 10,
                            FirstName = "Joan",
                            LastName = "Didion"
                        },
                        new
                        {
                            TeacherId = 11,
                            FirstName = "Daphne",
                            LastName = "Du Maurier"
                        },
                        new
                        {
                            TeacherId = 12,
                            FirstName = "Tina",
                            LastName = "Fey"
                        },
                        new
                        {
                            TeacherId = 13,
                            FirstName = "Roxane",
                            LastName = "Gay"
                        },
                        new
                        {
                            TeacherId = 14,
                            FirstName = "Dashiel",
                            LastName = "Hammett"
                        },
                        new
                        {
                            TeacherId = 15,
                            FirstName = "Frank",
                            LastName = "Herbert"
                        },
                        new
                        {
                            TeacherId = 16,
                            FirstName = "Aldous",
                            LastName = "Huxley"
                        },
                        new
                        {
                            TeacherId = 17,
                            FirstName = "Stieg",
                            LastName = "Larsson"
                        },
                        new
                        {
                            TeacherId = 18,
                            FirstName = "David",
                            LastName = "McCullough"
                        },
                        new
                        {
                            TeacherId = 19,
                            FirstName = "Toni",
                            LastName = "Morrison"
                        },
                        new
                        {
                            TeacherId = 20,
                            FirstName = "George",
                            LastName = "Orwell"
                        },
                        new
                        {
                            TeacherId = 21,
                            FirstName = "Mary",
                            LastName = "Shelley"
                        },
                        new
                        {
                            TeacherId = 22,
                            FirstName = "Sun",
                            LastName = "Tzu"
                        },
                        new
                        {
                            TeacherId = 23,
                            FirstName = "Augusten",
                            LastName = "Burroughs"
                        },
                        new
                        {
                            TeacherId = 25,
                            FirstName = "JK",
                            LastName = "Rowling"
                        },
                        new
                        {
                            TeacherId = 26,
                            FirstName = "Seth",
                            LastName = "Grahame-Smith"
                        });
                });

            modelBuilder.Entity("My_Classes_App.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("My_Classes_App.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("My_Classes_App.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("My_Classes_App.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("My_Classes_App.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("My_Classes_App.Models.Class", b =>
                {
                    b.HasOne("My_Classes_App.Models.ClassType", "ClassType")
                        .WithMany("Classes")
                        .HasForeignKey("ClassTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("My_Classes_App.Models.ClassTeacher", b =>
                {
                    b.HasOne("My_Classes_App.Models.Class", "Class")
                        .WithMany("ClassTeachers")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("My_Classes_App.Models.Teacher", "Teacher")
                        .WithMany("ClassTeachers")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
