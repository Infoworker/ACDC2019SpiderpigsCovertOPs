﻿// <auto-generated />
using System;
using ACDC2019SpiderpigsCovertOPs.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ACDC2019SpiderpigsCovertOPs.Migrations
{
    [DbContext(typeof(CovertOPsContext))]
    [Migration("20190301154614_NyDb3")]
    partial class NyDb3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ACDC2019SpiderpigsCovertOPs.Models.DbModels.Building", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Feed");

                    b.Property<string>("Icon");

                    b.Property<long?>("PositionId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("ACDC2019SpiderpigsCovertOPs.Models.DbModels.Incident", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<string>("Location");

                    b.Property<string>("Responsible");

                    b.Property<string>("Status");

                    b.Property<double>("Temperature");

                    b.HasKey("Id");

                    b.ToTable("Incidents");
                });

            modelBuilder.Entity("ACDC2019SpiderpigsCovertOPs.Models.DbModels.Location", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Lat");

                    b.Property<string>("Lng");

                    b.Property<DateTime>("Time");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("ACDC2019SpiderpigsCovertOPs.Models.DbModels.Person", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<long?>("LocationId");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("ACDC2019SpiderpigsCovertOPs.Models.DbModels.Position", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Lat");

                    b.Property<string>("Lng");

                    b.HasKey("Id");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("ACDC2019SpiderpigsCovertOPs.Models.DbModels.Sensordata", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<string>("Location");

                    b.Property<double>("Temperature");

                    b.HasKey("Id");

                    b.ToTable("Sensordatas");
                });

            modelBuilder.Entity("ACDC2019SpiderpigsCovertOPs.Models.DbModels.Building", b =>
                {
                    b.HasOne("ACDC2019SpiderpigsCovertOPs.Models.DbModels.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId");
                });

            modelBuilder.Entity("ACDC2019SpiderpigsCovertOPs.Models.DbModels.Person", b =>
                {
                    b.HasOne("ACDC2019SpiderpigsCovertOPs.Models.DbModels.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");
                });
#pragma warning restore 612, 618
        }
    }
}
