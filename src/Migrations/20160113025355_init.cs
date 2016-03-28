using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace EFCoreWebAPI.EFCoreWebAPI
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeatherEvent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:Serial", true),
                    Date = table.Column<DateTime>(nullable: false),
                    Hooray = table.Column<bool>(nullable: false),
                    Time = table.Column<TimeSpan>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherEvent", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("WeatherEvent");
        }
    }
}
