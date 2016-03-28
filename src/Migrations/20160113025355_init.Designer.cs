using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using EFCoreWebAPI.Data;

namespace EFCoreWebAPI.EFCoreWebAPI
{
    [DbContext(typeof(WeatherContext))]
    [Migration("20160113025355_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("EFCoreWebAPI.WeatherEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<bool>("Hooray");

                    b.Property<TimeSpan>("Time");

                    b.Property<int>("Type");

                    b.HasKey("Id");
                });
        }
    }
}
