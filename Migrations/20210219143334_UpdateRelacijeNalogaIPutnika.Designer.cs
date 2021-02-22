﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PutniNalozi.Data;

namespace PutniNaloziManager.Migrations
{
    [DbContext(typeof(PutniNaloziDBContext))]
    [Migration("20210219143334_UpdateRelacijeNalogaIPutnika")]
    partial class UpdateRelacijeNalogaIPutnika
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("PutniNalogPutnik", b =>
                {
                    b.Property<int>("NaloziRedniBrojNaloga")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PutniciID")
                        .HasColumnType("TEXT");

                    b.HasKey("NaloziRedniBrojNaloga", "PutniciID");

                    b.HasIndex("PutniciID");

                    b.ToTable("PutniNalogPutnik");
                });

            modelBuilder.Entity("PutniNalozi.Models.Automobil", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Kilometraza")
                        .HasColumnType("TEXT");

                    b.Property<string>("Marka")
                        .HasColumnType("TEXT");

                    b.Property<string>("Naziv")
                        .HasColumnType("TEXT");

                    b.Property<string>("RegistracijskaOznaka")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Automobili");
                });

            modelBuilder.Entity("PutniNalozi.Models.PutniNalog", b =>
                {
                    b.Property<int>("RedniBrojNaloga")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AutomobilID")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmailZaOdobrenje")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsLocked")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Komentar")
                        .HasColumnType("TEXT");

                    b.Property<string>("Odrediste")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("PocetnaKilometraza")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Polazak")
                        .HasColumnType("TEXT");

                    b.Property<string>("Polaziste")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Povratak")
                        .HasColumnType("TEXT");

                    b.Property<string>("Prijevoz")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RazlogPutovanja")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("ZavrsnaKilometraza")
                        .HasColumnType("TEXT");

                    b.HasKey("RedniBrojNaloga");

                    b.HasIndex("AutomobilID");

                    b.ToTable("PutniNalozi");
                });

            modelBuilder.Entity("PutniNalozi.Models.Putnik", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Ime")
                        .HasColumnType("TEXT");

                    b.Property<int>("NaloziID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Prezime")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Putnici");
                });

            modelBuilder.Entity("PutniNalogPutnik", b =>
                {
                    b.HasOne("PutniNalozi.Models.PutniNalog", null)
                        .WithMany()
                        .HasForeignKey("NaloziRedniBrojNaloga")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PutniNalozi.Models.Putnik", null)
                        .WithMany()
                        .HasForeignKey("PutniciID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PutniNalozi.Models.PutniNalog", b =>
                {
                    b.HasOne("PutniNalozi.Models.Automobil", "Automobil")
                        .WithMany()
                        .HasForeignKey("AutomobilID");

                    b.Navigation("Automobil");
                });
#pragma warning restore 612, 618
        }
    }
}
