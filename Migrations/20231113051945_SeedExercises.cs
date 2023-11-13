using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Liftr.Migrations
{
    /// <inheritdoc />
    public partial class SeedExercises : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("056f80ec-226d-4e45-a071-47f4bf2838a6"), "Bench Press" },
                    { new Guid("57aeb0af-1178-454f-a941-4a826cf8039b"), "Deadlift" },
                    { new Guid("6747faba-5f84-44d2-88fa-9a7670ea69c3"), "Squat" },
                    { new Guid("700190a7-a117-477a-8bf5-655bfa263dc7"), "Overhead Press" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("056f80ec-226d-4e45-a071-47f4bf2838a6"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("57aeb0af-1178-454f-a941-4a826cf8039b"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("6747faba-5f84-44d2-88fa-9a7670ea69c3"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("700190a7-a117-477a-8bf5-655bfa263dc7"));
        }
    }
}
