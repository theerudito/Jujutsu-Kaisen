﻿// <auto-generated />
using System;
using JujutsuKaisen.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JujutsuKaisen.Database.Migrations
{
    [DbContext(typeof(ApplicationDB))]
    [Migration("20230809191919_Inicial4")]
    partial class Inicial4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.9");

            modelBuilder.Entity("JujutsuKaisen.Models.Model.Characters", b =>
                {
                    b.Property<int>("IdCharacter")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("IdClan")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("IdCharacter");

                    b.HasIndex("IdClan");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("JujutsuKaisen.Models.Model.Clan", b =>
                {
                    b.Property<int>("IdClan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClanName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("IdClan");

                    b.ToTable("Clan", (string)null);
                });

            modelBuilder.Entity("JujutsuKaisen.Models.Model.Characters", b =>
                {
                    b.HasOne("JujutsuKaisen.Models.Model.Clan", "Clan")
                        .WithMany("Characters")
                        .HasForeignKey("IdClan");

                    b.Navigation("Clan");
                });

            modelBuilder.Entity("JujutsuKaisen.Models.Model.Clan", b =>
                {
                    b.Navigation("Characters");
                });
#pragma warning restore 612, 618
        }
    }
}
