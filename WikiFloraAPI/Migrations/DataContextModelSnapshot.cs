﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WikiFloraAPI.Data;

#nullable disable

namespace WikiFloraAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.9");

            modelBuilder.Entity("WikiFloraAPI.Models.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("CommentBody")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("FloraId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Comments");
                });

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

                    b.Property<string>("ContributerName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("GenusIndex")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsApprove")
                        .HasColumnType("INTEGER");

                    b.Property<string>("OthersName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Reference")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AlphabetIndex", "GenusIndex");

                    b.ToTable("Floras");
                });

            modelBuilder.Entity("WikiFloraAPI.Models.Hierarchy", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
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

                    b.Property<Guid>("FloraId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsCoverPhoto")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FloraId");

                    b.ToTable("Photo");
                });

            modelBuilder.Entity("WikiFloraAPI.Models.Reply", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CommentId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ReplyBody")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ReplyerId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.ToTable("Replies");
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

            modelBuilder.Entity("WikiFloraAPI.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("ContributionPoints")
                        .HasColumnType("INTEGER");

                    b.Property<string>("GivenName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SocialLink")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
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
                    b.HasOne("WikiFloraAPI.Models.Flora", null)
                        .WithMany("Photos")
                        .HasForeignKey("FloraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WikiFloraAPI.Models.Reply", b =>
                {
                    b.HasOne("WikiFloraAPI.Models.Comment", null)
                        .WithMany("Replies")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WikiFloraAPI.Models.ScientificName", b =>
                {
                    b.HasOne("WikiFloraAPI.Models.Flora", null)
                        .WithOne("ScientificName")
                        .HasForeignKey("WikiFloraAPI.Models.ScientificName", "FloraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WikiFloraAPI.Models.Comment", b =>
                {
                    b.Navigation("Replies");
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
