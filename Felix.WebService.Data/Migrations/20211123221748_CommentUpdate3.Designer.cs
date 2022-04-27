﻿// <auto-generated />
using System;
using Felix.WebService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Felix.WebService.Data.Migrations
{
    [DbContext(typeof(FelixDbContext))]
    [Migration("20211123221748_CommentUpdate3")]
    partial class CommentUpdate3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Felix.WebService.Data.Models.Comment.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedById")
                        .HasColumnType("int");

                    b.Property<int>("EndFrame")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int>("ShotCutRelId")
                        .HasColumnType("int");

                    b.Property<int>("StartFrame")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ShotCutRelId");

                    b.ToTable("Comment", "comment");
                });

            modelBuilder.Entity("Felix.WebService.Data.Models.Identity.BusinessRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("InternalCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("BusinessRole", "business");
                });

            modelBuilder.Entity("Felix.WebService.Data.Models.Identity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BusinessRoleId")
                        .HasColumnType("int");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BusinessRoleId");

                    b.ToTable("User", "user");
                });

            modelBuilder.Entity("Felix.WebService.Data.Models.Movie.Cut", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("Cut", "movie");
                });

            modelBuilder.Entity("Felix.WebService.Data.Models.Movie.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CodeName")
                        .IsUnique();

                    b.ToTable("Movie", "movie");
                });

            modelBuilder.Entity("Felix.WebService.Data.Models.Movie.Shot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EndFrame")
                        .HasColumnType("int");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("StartFrame")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Shot", "movie");
                });

            modelBuilder.Entity("Felix.WebService.Data.Models.Movie.ShotCutRel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CutId")
                        .HasColumnType("int");

                    b.Property<int>("ShotId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CutId");

                    b.HasIndex("ShotId");

                    b.ToTable("ShotCutRel", "movie");
                });

            modelBuilder.Entity("Felix.WebService.Data.Models.Seed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Seed", "business");
                });

            modelBuilder.Entity("Felix.WebService.Data.Models.Comment.Comment", b =>
                {
                    b.HasOne("Felix.WebService.Data.Models.Identity.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Felix.WebService.Data.Models.Movie.ShotCutRel", "ShotCutRel")
                        .WithMany("Comments")
                        .HasForeignKey("ShotCutRelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("ShotCutRel");
                });

            modelBuilder.Entity("Felix.WebService.Data.Models.Identity.User", b =>
                {
                    b.HasOne("Felix.WebService.Data.Models.Identity.BusinessRole", "BusinessRole")
                        .WithMany("Users")
                        .HasForeignKey("BusinessRoleId");

                    b.Navigation("BusinessRole");
                });

            modelBuilder.Entity("Felix.WebService.Data.Models.Movie.Cut", b =>
                {
                    b.HasOne("Felix.WebService.Data.Models.Movie.Movie", "Movie")
                        .WithMany("Cuts")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("Felix.WebService.Data.Models.Movie.ShotCutRel", b =>
                {
                    b.HasOne("Felix.WebService.Data.Models.Movie.Cut", "Cut")
                        .WithMany("ShotCutRels")
                        .HasForeignKey("CutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Felix.WebService.Data.Models.Movie.Shot", "Shot")
                        .WithMany("ShotCutRels")
                        .HasForeignKey("ShotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cut");

                    b.Navigation("Shot");
                });

            modelBuilder.Entity("Felix.WebService.Data.Models.Identity.BusinessRole", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Felix.WebService.Data.Models.Movie.Cut", b =>
                {
                    b.Navigation("ShotCutRels");
                });

            modelBuilder.Entity("Felix.WebService.Data.Models.Movie.Movie", b =>
                {
                    b.Navigation("Cuts");
                });

            modelBuilder.Entity("Felix.WebService.Data.Models.Movie.Shot", b =>
                {
                    b.Navigation("ShotCutRels");
                });

            modelBuilder.Entity("Felix.WebService.Data.Models.Movie.ShotCutRel", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
