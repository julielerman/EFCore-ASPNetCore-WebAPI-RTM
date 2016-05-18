using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EFCoreWebAPI.Data;

namespace src.Migrations
{
    [DbContext(typeof(WeatherContext))]
    [Migration("20160518125026_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20896");

            modelBuilder.Entity("EFCoreWebAPI.Reaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Quote");

                    b.Property<int>("WeatherEventId");

                    b.HasKey("Id");

                    b.HasIndex("WeatherEventId");

                    b.ToTable("Reactions");
                });

            modelBuilder.Entity("EFCoreWebAPI.WeatherEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<bool>("Hooray");

                    b.Property<string>("MostCommonWord");

                    b.Property<TimeSpan>("Time");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("WeatherEvents");
                });

            modelBuilder.Entity("EFCoreWebAPI.Reaction", b =>
                {
                    b.HasOne("EFCoreWebAPI.WeatherEvent")
                        .WithMany()
                        .HasForeignKey("WeatherEventId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
