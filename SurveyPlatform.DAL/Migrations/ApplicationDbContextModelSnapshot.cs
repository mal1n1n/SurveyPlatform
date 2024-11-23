﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SurveyPlatform.DAL.Data;

#nullable disable

namespace SurveyPlatform.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SurveyPlatform.DAL.Entities.Poll", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AuthorID");

                    b.ToTable("Polls");
                });

            modelBuilder.Entity("SurveyPlatform.DAL.Entities.PollOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PollId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PollId");

                    b.ToTable("PollOptions");
                });

            modelBuilder.Entity("SurveyPlatform.DAL.Entities.PollResponse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("OptionId")
                        .HasColumnType("integer");

                    b.Property<int>("PollId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OptionId");

                    b.HasIndex("PollId");

                    b.HasIndex("UserId");

                    b.ToTable("PollResponses");
                });

            modelBuilder.Entity("SurveyPlatform.DAL.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.PrimitiveCollection<string[]>("Roles")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text[]")
                        .HasDefaultValue(new[] { "User" });

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SurveyPlatform.DAL.Entities.Poll", b =>
                {
                    b.HasOne("SurveyPlatform.DAL.Entities.User", "Author")
                        .WithMany("Polls")
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("SurveyPlatform.DAL.Entities.PollOption", b =>
                {
                    b.HasOne("SurveyPlatform.DAL.Entities.Poll", "Poll")
                        .WithMany("Options")
                        .HasForeignKey("PollId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Poll");
                });

            modelBuilder.Entity("SurveyPlatform.DAL.Entities.PollResponse", b =>
                {
                    b.HasOne("SurveyPlatform.DAL.Entities.PollOption", "Option")
                        .WithMany("Responses")
                        .HasForeignKey("OptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SurveyPlatform.DAL.Entities.Poll", "Poll")
                        .WithMany("Responses")
                        .HasForeignKey("PollId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SurveyPlatform.DAL.Entities.User", "User")
                        .WithMany("Responses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Option");

                    b.Navigation("Poll");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SurveyPlatform.DAL.Entities.Poll", b =>
                {
                    b.Navigation("Options");

                    b.Navigation("Responses");
                });

            modelBuilder.Entity("SurveyPlatform.DAL.Entities.PollOption", b =>
                {
                    b.Navigation("Responses");
                });

            modelBuilder.Entity("SurveyPlatform.DAL.Entities.User", b =>
                {
                    b.Navigation("Polls");

                    b.Navigation("Responses");
                });
#pragma warning restore 612, 618
        }
    }
}