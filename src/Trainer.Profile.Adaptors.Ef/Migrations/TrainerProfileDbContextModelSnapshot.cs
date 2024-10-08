﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Trainer.Profile.Adaptors.Ef;

#nullable disable

namespace Trainer.Profile.Adaptors.Ef.Migrations
{
    [DbContext(typeof(TrainerProfileDbContext))]
    partial class TrainerProfileDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("profile")
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Trainer.Profile.Adaptors.Ef.Entities.TrainerEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateOnly?>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<Guid?>("TrainerSettingsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TrainerSettingsId");

                    b.ToTable("Trainer", "profile");
                });

            modelBuilder.Entity("Trainer.Profile.Adaptors.Ef.Entities.TrainerSettingsEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ClientCount")
                        .HasColumnType("int");

                    b.Property<Guid>("TrainerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TrainerId");

                    b.ToTable("TrainerSettings", "profile");
                });

            modelBuilder.Entity("Trainer.Profile.Adaptors.Ef.Entities.TrainerEntity", b =>
                {
                    b.HasOne("Trainer.Profile.Adaptors.Ef.Entities.TrainerSettingsEntity", "TrainerSettings")
                        .WithMany()
                        .HasForeignKey("TrainerSettingsId");

                    b.Navigation("TrainerSettings");
                });

            modelBuilder.Entity("Trainer.Profile.Adaptors.Ef.Entities.TrainerSettingsEntity", b =>
                {
                    b.HasOne("Trainer.Profile.Adaptors.Ef.Entities.TrainerEntity", "Trainer")
                        .WithMany()
                        .HasForeignKey("TrainerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trainer");
                });
#pragma warning restore 612, 618
        }
    }
}
