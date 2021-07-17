﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

namespace Repository.Migrations
{
    [DbContext(typeof(SQLServerContext))]
    [Migration("20210717152727_added_Session_Result")]
    partial class added_Session_Result
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.Answer", b =>
                {
                    b.Property<string>("AnswerID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CategoryID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Correct")
                        .HasColumnType("bit");

                    b.Property<string>("TurnID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("WordAnswered")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WordID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AnswerID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("TurnID");

                    b.HasIndex("WordID");

                    b.ToTable("Answer");
                });

            modelBuilder.Entity("Models.Category", b =>
                {
                    b.Property<string>("CategoryID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Models.Letter", b =>
                {
                    b.Property<string>("LetterID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LetterName")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("LetterID");

                    b.ToTable("Letter");
                });

            modelBuilder.Entity("Models.Player", b =>
                {
                    b.Property<string>("PlayerID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlayerName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlayerID");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("Models.PlayerSession", b =>
                {
                    b.Property<string>("PlayerSessionID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PlayerID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SessionID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("PlayerSessionID");

                    b.HasIndex("PlayerID");

                    b.HasIndex("SessionID");

                    b.ToTable("PlayerSession");
                });

            modelBuilder.Entity("Models.Round", b =>
                {
                    b.Property<string>("RoundID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Finished")
                        .HasColumnType("bit");

                    b.Property<string>("LetterID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SessionID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("roundNumber")
                        .HasColumnType("int");

                    b.HasKey("RoundID");

                    b.HasIndex("LetterID");

                    b.HasIndex("SessionID");

                    b.ToTable("Round");
                });

            modelBuilder.Entity("Models.RoundCategory", b =>
                {
                    b.Property<string>("RoundCategoryID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CategoryID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoundID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("RoundCategoryID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("RoundID");

                    b.ToTable("RoundCategory");
                });

            modelBuilder.Entity("Models.Session", b =>
                {
                    b.Property<string>("SessionID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("SessionID");

                    b.ToTable("Session");
                });

            modelBuilder.Entity("Models.SessionResult", b =>
                {
                    b.Property<string>("SessionResultID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PlayerID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SessionID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("StatusPlayer")
                        .HasColumnType("int");

                    b.HasKey("SessionResultID");

                    b.HasIndex("PlayerID");

                    b.HasIndex("SessionID");

                    b.ToTable("SessionResult");
                });

            modelBuilder.Entity("Models.Turn", b =>
                {
                    b.Property<string>("TurnID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PlayerID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoundID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("correctAnswers")
                        .HasColumnType("int");

                    b.Property<float>("finishTime")
                        .HasColumnType("real");

                    b.Property<bool>("finished")
                        .HasColumnType("bit");

                    b.HasKey("TurnID");

                    b.HasIndex("PlayerID");

                    b.HasIndex("RoundID");

                    b.ToTable("Turn");
                });

            modelBuilder.Entity("Models.Word", b =>
                {
                    b.Property<string>("WordID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LetterID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("WordName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WordID");

                    b.HasIndex("LetterID");

                    b.ToTable("Word");
                });

            modelBuilder.Entity("Models.WordCategory", b =>
                {
                    b.Property<string>("WordCategoryID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CategoryID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("WordID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("WordCategoryID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("WordID");

                    b.ToTable("WordCategory");
                });

            modelBuilder.Entity("Models.Answer", b =>
                {
                    b.HasOne("Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID");

                    b.HasOne("Models.Turn", null)
                        .WithMany("Answers")
                        .HasForeignKey("TurnID");

                    b.HasOne("Models.Word", "Word")
                        .WithMany()
                        .HasForeignKey("WordID");

                    b.Navigation("Category");

                    b.Navigation("Word");
                });

            modelBuilder.Entity("Models.PlayerSession", b =>
                {
                    b.HasOne("Models.Player", null)
                        .WithMany("PlayerSessions")
                        .HasForeignKey("PlayerID");

                    b.HasOne("Models.Session", "Session")
                        .WithMany()
                        .HasForeignKey("SessionID");

                    b.Navigation("Session");
                });

            modelBuilder.Entity("Models.Round", b =>
                {
                    b.HasOne("Models.Letter", "Letter")
                        .WithMany()
                        .HasForeignKey("LetterID");

                    b.HasOne("Models.Session", null)
                        .WithMany("Rounds")
                        .HasForeignKey("SessionID");

                    b.Navigation("Letter");
                });

            modelBuilder.Entity("Models.RoundCategory", b =>
                {
                    b.HasOne("Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID");

                    b.HasOne("Models.Round", "Round")
                        .WithMany()
                        .HasForeignKey("RoundID");

                    b.Navigation("Category");

                    b.Navigation("Round");
                });

            modelBuilder.Entity("Models.SessionResult", b =>
                {
                    b.HasOne("Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerID");

                    b.HasOne("Models.Session", null)
                        .WithMany("SessionResults")
                        .HasForeignKey("SessionID");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("Models.Turn", b =>
                {
                    b.HasOne("Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerID");

                    b.HasOne("Models.Round", null)
                        .WithMany("Turns")
                        .HasForeignKey("RoundID");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("Models.Word", b =>
                {
                    b.HasOne("Models.Letter", "Letter")
                        .WithMany()
                        .HasForeignKey("LetterID");

                    b.Navigation("Letter");
                });

            modelBuilder.Entity("Models.WordCategory", b =>
                {
                    b.HasOne("Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID");

                    b.HasOne("Models.Word", "Word")
                        .WithMany()
                        .HasForeignKey("WordID");

                    b.Navigation("Category");

                    b.Navigation("Word");
                });

            modelBuilder.Entity("Models.Player", b =>
                {
                    b.Navigation("PlayerSessions");
                });

            modelBuilder.Entity("Models.Round", b =>
                {
                    b.Navigation("Turns");
                });

            modelBuilder.Entity("Models.Session", b =>
                {
                    b.Navigation("Rounds");

                    b.Navigation("SessionResults");
                });

            modelBuilder.Entity("Models.Turn", b =>
                {
                    b.Navigation("Answers");
                });
#pragma warning restore 612, 618
        }
    }
}
