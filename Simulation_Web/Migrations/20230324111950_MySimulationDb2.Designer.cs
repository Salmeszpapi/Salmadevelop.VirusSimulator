﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Simulation_Web.Db;

#nullable disable

namespace Simulation_Web.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230324111950_MySimulationDb2")]
    partial class MySimulationDb2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("Simulation_Web.Models.SimulationData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AllDeadPeoples")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AllHealthyPeoples")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AllInfectedPeoples")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AllPeople")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("simulationDatas");
                });

            modelBuilder.Entity("Simulation_Web.Models.SimulationRun", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateOfRun")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("simulationRuns");
                });
#pragma warning restore 612, 618
        }
    }
}
