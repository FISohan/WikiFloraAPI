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

            modelBuilder.Entity("WikiFloraAPI.Models.Flora", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ScientificNameId")
                        .HasColumnType("TEXT");

                    b.Property<string>("banglaName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("contributer")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("englishName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("floraPhotoId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("hierarchyId")
                        .HasColumnType("TEXT");

                    b.Property<string>("othersName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ScientificNameId");

                    b.HasIndex("floraPhotoId");

                    b.HasIndex("hierarchyId");

                    b.ToTable("Floras");
                });

            modelBuilder.Entity("WikiFloraAPI.Models.FloraPhoto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("coverPhotoUrlId")
                        .HasColumnType("TEXT");

                    b.Property<string>("floraId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("floraName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("coverPhotoUrlId");

                    b.ToTable("FloraPhoto");
                });

            modelBuilder.Entity("WikiFloraAPI.Models.Hierarchy", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("bionomialName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("family")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("genus")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("kingdom")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("order")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("species")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Hierarchy");
                });

            modelBuilder.Entity("WikiFloraAPI.Models.Photo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("FloraPhotoId")
                        .HasColumnType("TEXT");

                    b.Property<string>("url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FloraPhotoId");

                    b.ToTable("Photo");
                });

            modelBuilder.Entity("WikiFloraAPI.Models.ScientificName", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("genus")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("specificEpithet")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ScientificName");
                });

            modelBuilder.Entity("WikiFloraAPI.Models.Flora", b =>
                {
                    b.HasOne("WikiFloraAPI.Models.ScientificName", "ScientificName")
                        .WithMany()
                        .HasForeignKey("ScientificNameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WikiFloraAPI.Models.FloraPhoto", "floraPhoto")
                        .WithMany()
                        .HasForeignKey("floraPhotoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WikiFloraAPI.Models.Hierarchy", "hierarchy")
                        .WithMany()
                        .HasForeignKey("hierarchyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ScientificName");

                    b.Navigation("floraPhoto");

                    b.Navigation("hierarchy");
                });

            modelBuilder.Entity("WikiFloraAPI.Models.FloraPhoto", b =>
                {
                    b.HasOne("WikiFloraAPI.Models.Photo", "coverPhotoUrl")
                        .WithMany()
                        .HasForeignKey("coverPhotoUrlId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("coverPhotoUrl");
                });

            modelBuilder.Entity("WikiFloraAPI.Models.Photo", b =>
                {
                    b.HasOne("WikiFloraAPI.Models.FloraPhoto", null)
                        .WithMany("photoUrls")
                        .HasForeignKey("FloraPhotoId");
                });

            modelBuilder.Entity("WikiFloraAPI.Models.FloraPhoto", b =>
                {
                    b.Navigation("photoUrls");
                });
#pragma warning restore 612, 618
        }
    }
}