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
    [Migration("20210630212215_word")]
    partial class word
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.Property<string>("PlayerName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlayerID");

                    b.ToTable("Player");
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

            modelBuilder.Entity("Models.Word", b =>
                {
                    b.HasOne("Models.Letter", "Letter")
                        .WithMany()
                        .HasForeignKey("LetterID");

                    b.Navigation("Letter");
                });
#pragma warning restore 612, 618
        }
    }
}
