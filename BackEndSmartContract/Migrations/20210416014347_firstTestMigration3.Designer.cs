﻿// <auto-generated />
using System;
using BackEndSmartContract.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BackEndSmartContract.Migrations
{
    [DbContext(typeof(SmartPropDbContext))]
    [Migration("20210416014347_firstTestMigration3")]
    partial class firstTestMigration3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BackEndSmartContract.Models.RealState", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ambientes")
                        .HasColumnType("int");

                    b.Property<bool>("Available")
                        .HasColumnType("bit");

                    b.Property<int>("BathRoomQty")
                        .HasColumnType("int");

                    b.Property<int>("BedRoomQty")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Garage")
                        .HasColumnType("bit");

                    b.Property<int>("RentDurationDays")
                        .HasColumnType("int");

                    b.Property<int>("RentFee")
                        .HasColumnType("int");

                    b.Property<int>("RentPaymentSchedule")
                        .HasColumnType("int");

                    b.Property<float>("SqMtrs")
                        .HasColumnType("real");

                    b.Property<int?>("userID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("userID");

                    b.ToTable("RealStates");
                });

            modelBuilder.Entity("BackEndSmartContract.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("NVARCHAR(100)");

                    b.Property<int>("PersonalID")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .HasColumnType("NVARCHAR(100)");

                    b.Property<string>("WalletAdress")
                        .HasColumnType("NVARCHAR(42)");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BackEndSmartContract.Models.RealState", b =>
                {
                    b.HasOne("BackEndSmartContract.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("userID");

                    b.Navigation("user");
                });
#pragma warning restore 612, 618
        }
    }
}
