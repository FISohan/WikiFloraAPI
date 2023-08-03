﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WikiFloraAPI.Data;

#nullable disable

namespace WikiFloraAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230803070242_FloraRelationship")]
    partial class FloraRelationship
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.9");

            modelBuilder.Entity("WikiFloraAPI.Models.Flora", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("AlphabetIndex")
                        .HasColumnType("INTEGER");

                    b.Property<string>("BanglaName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Contributer")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("OthersName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AlphabetIndex");

                    b.ToTable("Floras");
                });

            modelBuilder.Entity("WikiFloraAPI.Models.Hierarchy", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("BionomialName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Family")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("FloraId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Genus")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Kingdom")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Order")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Species")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FloraId")
                        .IsUnique();

                    b.ToTable("Hierarchy");
                });

            modelBuilder.Entity("WikiFloraAPI.Models.Photo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Credit")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("FloraId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Reference")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FloraId");

                    b.ToTable("Photo");
                });

            modelBuilder.Entity("WikiFloraAPI.Models.ScientificName", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("FloraId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Genus")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SpecificEpithet")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FloraId")
                        .IsUnique();

                    b.ToTable("ScientificName");
                });

            modelBuilder.Entity("WikiFloraAPI.Models.Hierarchy", b =>
                {
                    b.HasOne("WikiFloraAPI.Models.Flora", null)
                        .WithOne("Hierarchy")
                        .HasForeignKey("WikiFloraAPI.Models.Hierarchy", "FloraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WikiFloraAPI.Models.Photo", b =>
                {
                    b.HasOne("WikiFloraAPI.Models.Flora", "Flora")
                        .WithMany("Photos")
                        .HasForeignKey("FloraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flora");
                });

            modelBuilder.Entity("WikiFloraAPI.Models.ScientificName", b =>
                {
                    b.HasOne("WikiFloraAPI.Models.Flora", null)
                        .WithOne("ScientificName")
                        .HasForeignKey("WikiFloraAPI.Models.ScientificName", "FloraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WikiFloraAPI.Models.Flora", b =>
                {
                    b.Navigation("Hierarchy")
                        .IsRequired();

                    b.Navigation("Photos");

                    b.Navigation("ScientificName")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
