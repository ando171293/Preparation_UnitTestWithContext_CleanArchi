﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Preparation.Models;

#nullable disable

namespace Preparation.Migrations
{
    [DbContext(typeof(Context))]
    partial class PreparationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Preparation.Models.Parents", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("Adresse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mere")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pere")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Parents", (string)null);
                });

            modelBuilder.Entity("Preparation.Models.Personnes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adresse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Fonction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Id_Parent")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentsId");

                    b.ToTable("Personnes", (string)null);
                });

            modelBuilder.Entity("Preparation.Models.Personnes", b =>
                {
                    b.HasOne("Preparation.Models.Parents", "Parents")
                        .WithMany("Personnes")
                        .HasForeignKey("ParentsId");

                    b.Navigation("Parents");
                });

            modelBuilder.Entity("Preparation.Models.Parents", b =>
                {
                    b.Navigation("Personnes");
                });
#pragma warning restore 612, 618
        }
    }
}
