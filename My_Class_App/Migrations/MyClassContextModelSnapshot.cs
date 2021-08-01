﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using My_Classes_App.Models;

namespace My_Classes_App.Migrations
{
    [DbContext(typeof(MyClassContext))]
    partial class MyClassContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                        .HasColumnType("nvarchar(55)")
                        .HasMaxLength(55);

                    b.Property<string>("ClassTypeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("NumberOfCredits")
                        .HasColumnType("int");

                    b.HasKey("ClassId");

                    b.HasIndex("ClassTypeId");

                    b.ToTable("Classes");

                    b.HasData(
                        new
                        {
                            ClassId = 1,
                            ClassTitle = "The College Experience",
                            ClassTypeId = "other",
                            NumberOfCredits = 1
                        },
                        new
                        {
                            ClassId = 2,
                            ClassTitle = "Intro To Occupational Health",
                            ClassTypeId = "health",
                            NumberOfCredits = 3
                        },
                        new
                        {
                            ClassId = 3,
                            ClassTitle = "Intro To Economics",
                            ClassTypeId = "economics",
                            NumberOfCredits = 3
                        },
                        new
                        {
                            ClassId = 4,
                            ClassTitle = "American History",
                            ClassTypeId = "history",
                            NumberOfCredits = 3
                        },
                        new
                        {
                            ClassId = 5,
                            ClassTitle = "Intro To C#",
                            ClassTypeId = "computerscience",
                            NumberOfCredits = 5
                        },
                        new
                        {
                            ClassId = 6,
                            ClassTitle = "Advanced C#",
                            ClassTypeId = "computerscience",
                            NumberOfCredits = 5
                        },
                        new
                        {
                            ClassId = 7,
                            ClassTitle = "Statistics",
                            ClassTypeId = "mathmatics ",
                            NumberOfCredits = 4
                        },
                        new
                        {
                            ClassId = 8,
                            ClassTitle = "Java",
                            ClassTypeId = "computerscience",
                            NumberOfCredits = 3
                        },
                        new
                        {
                            ClassId = 9,
                            ClassTitle = "Trigonometry",
                            ClassTypeId = "mathmatics",
                            NumberOfCredits = 2
                        },
                        new
                        {
                            ClassId = 10,
                            ClassTitle = "Geometry",
                            ClassTypeId = "mathmatics ",
                            NumberOfCredits = 3
                        },
                        new
                        {
                            ClassId = 11,
                            ClassTitle = "Intro To Film",
                            ClassTypeId = "art",
                            NumberOfCredits = 2
                        },
                        new
                        {
                            ClassId = 12,
                            ClassTitle = "Elementary French",
                            ClassTypeId = "other",
                            NumberOfCredits = 3
                        },
                        new
                        {
                            ClassId = 13,
                            ClassTitle = "Intro To Nursing",
                            ClassTypeId = "health",
                            NumberOfCredits = 3
                        },
                        new
                        {
                            ClassId = 14,
                            ClassTitle = "Intro To Literature",
                            ClassTypeId = "literature",
                            NumberOfCredits = 4
                        },
                        new
                        {
                            ClassId = 15,
                            ClassTitle = "Advanced Literature",
                            ClassTypeId = "literature",
                            NumberOfCredits = 5
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
                            TeacherId = 1
                        },
                        new
                        {
                            ClassId = 2,
                            TeacherId = 2
                        },
                        new
                        {
                            ClassId = 3,
                            TeacherId = 3
                        },
                        new
                        {
                            ClassId = 4,
                            TeacherId = 4
                        },
                        new
                        {
                            ClassId = 5,
                            TeacherId = 5
                        },
                        new
                        {
                            ClassId = 6,
                            TeacherId = 5
                        },
                        new
                        {
                            ClassId = 7,
                            TeacherId = 6
                        },
                        new
                        {
                            ClassId = 8,
                            TeacherId = 7
                        },
                        new
                        {
                            ClassId = 9,
                            TeacherId = 8
                        },
                        new
                        {
                            ClassId = 10,
                            TeacherId = 8
                        },
                        new
                        {
                            ClassId = 11,
                            TeacherId = 9
                        },
                        new
                        {
                            ClassId = 12,
                            TeacherId = 10
                        },
                        new
                        {
                            ClassId = 13,
                            TeacherId = 11
                        },
                        new
                        {
                            ClassId = 14,
                            TeacherId = 12
                        },
                        new
                        {
                            ClassId = 15,
                            TeacherId = 12
                        });
                });

            modelBuilder.Entity("My_Classes_App.Models.ClassType", b =>
                {
                    b.Property<string>("ClassTypeId")
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.HasKey("ClassTypeId");

                    b.ToTable("ClassTypes");

                    b.HasData(
                        new
                        {
                            ClassTypeId = "literature",
                            Name = "Literature"
                        },
                        new
                        {
                            ClassTypeId = "mathmatics ",
                            Name = "Mathmatics"
                        },
                        new
                        {
                            ClassTypeId = "economics",
                            Name = "Economics"
                        },
                        new
                        {
                            ClassTypeId = "computerscience",
                            Name = "Computer Science"
                        },
                        new
                        {
                            ClassTypeId = "history",
                            Name = "History"
                        },
                        new
                        {
                            ClassTypeId = "health",
                            Name = "Health"
                        },
                        new
                        {
                            ClassTypeId = "art",
                            Name = "Art"
                        },
                        new
                        {
                            ClassTypeId = "other",
                            Name = "Other"
                        });
                });

            modelBuilder.Entity("My_Classes_App.Models.Homework", b =>
                {
                    b.Property<int>("HomeworkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AssignmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(55)")
                        .HasMaxLength(55);

                    b.Property<DateTime?>("DueDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("HomeworkTypeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("PointValue")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("StatusId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("HomeworkId");

                    b.HasIndex("HomeworkTypeId");

                    b.HasIndex("StatusId");

                    b.ToTable("HomeworkAssignments");
                });

            modelBuilder.Entity("My_Classes_App.Models.HomeworkType", b =>
                {
                    b.Property<string>("HomeworkTypeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HomeworkTypeId");

                    b.ToTable("Sprints");

                    b.HasData(
                        new
                        {
                            HomeworkTypeId = "assignment",
                            Name = "Assignment"
                        },
                        new
                        {
                            HomeworkTypeId = "quiz",
                            Name = "Quiz"
                        },
                        new
                        {
                            HomeworkTypeId = "test",
                            Name = "Test"
                        },
                        new
                        {
                            HomeworkTypeId = "groupproject",
                            Name = "Group Project"
                        },
                        new
                        {
                            HomeworkTypeId = "finalproject",
                            Name = "Final Project"
                        });
                });

            modelBuilder.Entity("My_Classes_App.Models.Status", b =>
                {
                    b.Property<string>("StatusId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusId");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            StatusId = "t",
                            Name = "To Do"
                        },
                        new
                        {
                            StatusId = "i",
                            Name = "In progress"
                        },
                        new
                        {
                            StatusId = "redo",
                            Name = "Redo"
                        },
                        new
                        {
                            StatusId = "d",
                            Name = "Done"
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
                        .HasColumnType("nvarchar(55)")
                        .HasMaxLength(55);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(55)")
                        .HasMaxLength(55);

                    b.HasKey("TeacherId");

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            TeacherId = 1,
                            FirstName = "Ron",
                            LastName = "Thompson"
                        },
                        new
                        {
                            TeacherId = 2,
                            FirstName = "Grace",
                            LastName = "Beckman"
                        },
                        new
                        {
                            TeacherId = 3,
                            FirstName = "Margot",
                            LastName = "Fan"
                        },
                        new
                        {
                            TeacherId = 4,
                            FirstName = "Peter",
                            LastName = "Peteson"
                        },
                        new
                        {
                            TeacherId = 5,
                            FirstName = "Nala",
                            LastName = "Bean"
                        },
                        new
                        {
                            TeacherId = 6,
                            FirstName = "Joshua",
                            LastName = "Lampshade"
                        },
                        new
                        {
                            TeacherId = 7,
                            FirstName = "Tyler",
                            LastName = "Shera"
                        },
                        new
                        {
                            TeacherId = 8,
                            FirstName = "Tiffany",
                            LastName = "Fitzmagic"
                        },
                        new
                        {
                            TeacherId = 9,
                            FirstName = "Randy",
                            LastName = "Greteman"
                        },
                        new
                        {
                            TeacherId = 10,
                            FirstName = "Brittany",
                            LastName = "Lionbridge"
                        },
                        new
                        {
                            TeacherId = 11,
                            FirstName = "Michael",
                            LastName = "Michaelson"
                        },
                        new
                        {
                            TeacherId = 12,
                            FirstName = "Haley",
                            LastName = "Buschman"
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

            modelBuilder.Entity("My_Classes_App.Models.Homework", b =>
                {
                    b.HasOne("My_Classes_App.Models.HomeworkType", "HomeworkType")
                        .WithMany()
                        .HasForeignKey("HomeworkTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("My_Classes_App.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
