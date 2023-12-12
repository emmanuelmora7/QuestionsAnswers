﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuestionsAnswers_API.Data;

#nullable disable

namespace QuestionsAnswers_API.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("QuestionsAnswers_API.Controllers.Models.Answer", b =>
                {
                    b.Property<int>("AnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AnswerId"));

                    b.Property<DateTime>("Creationdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("AnswerId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");

                    b.HasData(
                        new
                        {
                            AnswerId = 1,
                            Creationdate = new DateTime(2023, 12, 11, 18, 5, 44, 205, DateTimeKind.Local).AddTicks(9821),
                            Description = "This is the first answer for question 1?",
                            QuestionId = 1
                        },
                        new
                        {
                            AnswerId = 2,
                            Creationdate = new DateTime(2023, 12, 11, 18, 5, 44, 205, DateTimeKind.Local).AddTicks(9823),
                            Description = "This is the second answer for question 2?",
                            QuestionId = 2
                        });
                });

            modelBuilder.Entity("QuestionsAnswers_API.Controllers.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Creationdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Creationdate = new DateTime(2023, 12, 11, 18, 5, 44, 205, DateTimeKind.Local).AddTicks(9615),
                            Description = "This is the first question?"
                        },
                        new
                        {
                            Id = 2,
                            Creationdate = new DateTime(2023, 12, 11, 18, 5, 44, 205, DateTimeKind.Local).AddTicks(9631),
                            Description = "This is the second question?"
                        });
                });

            modelBuilder.Entity("QuestionsAnswers_API.Controllers.Models.QuestionTag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TagId"));

                    b.Property<DateTime>("Creationdate")
                        .HasColumnType("datetime2");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<string>("TagDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TagId");

                    b.HasIndex("QuestionId");

                    b.ToTable("QuestionTag");

                    b.HasData(
                        new
                        {
                            TagId = 1,
                            Creationdate = new DateTime(2023, 12, 11, 18, 5, 44, 207, DateTimeKind.Local).AddTicks(9219),
                            QuestionId = 1,
                            TagDescription = "Tag1"
                        },
                        new
                        {
                            TagId = 2,
                            Creationdate = new DateTime(2023, 12, 11, 18, 5, 44, 207, DateTimeKind.Local).AddTicks(9230),
                            QuestionId = 2,
                            TagDescription = "Tag2"
                        });
                });

            modelBuilder.Entity("QuestionsAnswers_API.Controllers.Models.Vote", b =>
                {
                    b.Property<int>("VoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VoteId"));

                    b.Property<int>("AnswerId")
                        .HasColumnType("int");

                    b.Property<int>("AnswerVotes")
                        .HasColumnType("int");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionVotes")
                        .HasColumnType("int");

                    b.HasKey("VoteId");

                    b.ToTable("Vote");

                    b.HasData(
                        new
                        {
                            VoteId = 1,
                            AnswerId = 1,
                            AnswerVotes = 2,
                            QuestionId = 1,
                            QuestionVotes = 3
                        },
                        new
                        {
                            VoteId = 2,
                            AnswerId = 2,
                            AnswerVotes = 1,
                            QuestionId = 2,
                            QuestionVotes = 4
                        });
                });

            modelBuilder.Entity("QuestionsAnswers_API.Controllers.Models.Answer", b =>
                {
                    b.HasOne("QuestionsAnswers_API.Controllers.Models.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("QuestionsAnswers_API.Controllers.Models.QuestionTag", b =>
                {
                    b.HasOne("QuestionsAnswers_API.Controllers.Models.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });
#pragma warning restore 612, 618
        }
    }
}
