﻿// <auto-generated />
using System;
using HandasatTochnaProgect2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HandasatTochnaProgect2.Migrations
{
    [DbContext(typeof(dbContext))]
    [Migration("20230611102844_a")]
    partial class a
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("HandasatTochnaProgect2.Models.Avatar", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("bodyId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("name")
                        .HasColumnType("TEXT");

                    b.Property<int>("pantsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("shirtId")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.ToTable("Avatars");
                });

            modelBuilder.Entity("HandasatTochnaProgect2.Models.Item", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("ImageData")
                        .HasColumnType("BLOB");

                    b.Property<string>("name")
                        .HasColumnType("TEXT");

                    b.Property<int>("type")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("universal")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.ToTable("ItemsList");
                });

            modelBuilder.Entity("HandasatTochnaProgect2.Models.ItemToSell", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("cost")
                        .HasColumnType("INTEGER");

                    b.Property<int>("itemId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("sellerUserName")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Shop");
                });

            modelBuilder.Entity("HandasatTochnaProgect2.Models.User", b =>
                {
                    b.Property<string>("userName")
                        .HasColumnType("TEXT");

                    b.Property<int>("avatarId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("director")
                        .HasColumnType("INTEGER");

                    b.Property<string>("email")
                        .HasColumnType("TEXT");

                    b.Property<int>("money")
                        .HasColumnType("INTEGER");

                    b.Property<string>("name")
                        .HasColumnType("TEXT");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("phonNumber")
                        .HasColumnType("TEXT");

                    b.HasKey("userName");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HandasatTochnaProgect2.Models.User2Item", b =>
                {
                    b.Property<int>("itemId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("userName")
                        .HasColumnType("TEXT");

                    b.HasKey("itemId", "userName");

                    b.ToTable("Users2Items");
                });
#pragma warning restore 612, 618
        }
    }
}
