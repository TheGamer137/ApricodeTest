﻿// <auto-generated />
using System;
using ApricodeTest._Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApricodeTest.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221017154637__initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc.2.22472.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApricodeTest.Models.DeveloperStudio", b =>
                {
                    b.Property<int>("DeveloperId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeveloperId"));

                    b.Property<string>("DeveloperStudioName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DeveloperId");

                    b.ToTable("DeveloperStudios");
                });

            modelBuilder.Entity("ApricodeTest.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DeveloperStudioDeveloperId")
                        .HasColumnType("int");

                    b.Property<string>("GameName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DeveloperStudioDeveloperId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("ApricodeTest.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenreId"));

                    b.Property<int?>("GameId")
                        .HasColumnType("int");

                    b.Property<string>("GenreName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenreId");

                    b.HasIndex("GameId");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("ApricodeTest.Models.Game", b =>
                {
                    b.HasOne("ApricodeTest.Models.DeveloperStudio", "DeveloperStudio")
                        .WithMany()
                        .HasForeignKey("DeveloperStudioDeveloperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeveloperStudio");
                });

            modelBuilder.Entity("ApricodeTest.Models.Genre", b =>
                {
                    b.HasOne("ApricodeTest.Models.Game", null)
                        .WithMany("Genre")
                        .HasForeignKey("GameId");
                });

            modelBuilder.Entity("ApricodeTest.Models.Game", b =>
                {
                    b.Navigation("Genre");
                });
#pragma warning restore 612, 618
        }
    }
}
