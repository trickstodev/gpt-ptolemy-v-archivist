﻿// <auto-generated />
using ConsoleArchivist.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConsoleArchivist.Migrations
{
    [DbContext(typeof(ArchivistDbContext))]
    [Migration("20240201192533_Initial Migration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("ConsoleArchivist.Models.Translation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("GPTTranslationInYaml")
                        .HasColumnType("TEXT");

                    b.Property<bool>("InGitHub")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsToSentToGitHub")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LangTag")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Notes")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Translations");
                });
#pragma warning restore 612, 618
        }
    }
}
