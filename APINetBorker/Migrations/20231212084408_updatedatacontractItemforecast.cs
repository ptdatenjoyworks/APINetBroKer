using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APINetBorker.Migrations
{
    /// <inheritdoc />
    public partial class updatedatacontractItemforecast : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ContractMargin",
                table: "ContractItems",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PercentageOfContractMargin",
                table: "ContractItems",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "ContractItemForecast",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ContractItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    ForecastDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ForecastMonth = table.Column<int>(type: "INTEGER", nullable: false),
                    ForecastYear = table.Column<int>(type: "INTEGER", nullable: false),
                    ForecastMonthOfYear = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractItemForecast", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractItemForecast_ContractItems_ContractItemId",
                        column: x => x.ContractItemId,
                        principalTable: "ContractItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "668f6c1b-94cf-491e-aa9f-082c84ab4219");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "413f8ad0-f98b-4bb8-869d-6f8cf1064e82");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "6d8f9164-7dd7-474d-b753-69ff146e9224");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "dfc0d299-d62f-4d7a-99a9-333775665e17");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "cfe02bad-554e-4b46-a467-c111dbaf605f");

            migrationBuilder.UpdateData(
                table: "Commisions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CommissionConfigurationTypeId",
                value: "PercentageContractResidual");

            migrationBuilder.UpdateData(
                table: "Commisions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CommissionConfigurationTypeId",
                value: "QuarterlyUpfront");

            migrationBuilder.UpdateData(
                table: "ContractItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ContractMargin", "PercentageOfContractMargin" },
                values: new object[] { 0m, 0m });

            migrationBuilder.UpdateData(
                table: "ContractItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ContractMargin", "PercentageOfContractMargin" },
                values: new object[] { 0m, 0m });

            migrationBuilder.UpdateData(
                table: "ContractItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ContractMargin", "PercentageOfContractMargin" },
                values: new object[] { 0m, 0m });

            migrationBuilder.UpdateData(
                table: "ContractItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ContractMargin", "PercentageOfContractMargin" },
                values: new object[] { 0m, 0m });

            migrationBuilder.UpdateData(
                table: "ContractItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ContractMargin", "PercentageOfContractMargin" },
                values: new object[] { 0m, 0m });

            migrationBuilder.UpdateData(
                table: "ContractItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ContractMargin", "PercentageOfContractMargin" },
                values: new object[] { 0m, 0m });

            migrationBuilder.UpdateData(
                table: "ContractItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ContractMargin", "PercentageOfContractMargin" },
                values: new object[] { 0m, 0m });

            migrationBuilder.UpdateData(
                table: "ContractItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ContractMargin", "PercentageOfContractMargin" },
                values: new object[] { 0m, 0m });

            migrationBuilder.UpdateData(
                table: "ContractItems",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ContractMargin", "PercentageOfContractMargin" },
                values: new object[] { 0m, 0m });

            migrationBuilder.UpdateData(
                table: "ContractItems",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ContractMargin", "PercentageOfContractMargin" },
                values: new object[] { 0m, 0m });

            migrationBuilder.CreateIndex(
                name: "IX_ContractItemForecast_ContractItemId",
                table: "ContractItemForecast",
                column: "ContractItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContractItemForecast");

            migrationBuilder.DropColumn(
                name: "ContractMargin",
                table: "ContractItems");

            migrationBuilder.DropColumn(
                name: "PercentageOfContractMargin",
                table: "ContractItems");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "4794fa3e-f025-4b3f-b909-d232335c1e90");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "c7bb4d73-4e74-4096-9c06-96bcfbea0d6e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "23269c17-40b6-496a-9417-217a2c7b158d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "6565fbee-fb7c-4539-b9f2-605b9268236a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "f5eb4ff3-4b9e-42cc-add9-ff0bc830c388");

            migrationBuilder.UpdateData(
                table: "Commisions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CommissionConfigurationTypeId",
                value: "ContractUpfront");

            migrationBuilder.UpdateData(
                table: "Commisions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CommissionConfigurationTypeId",
                value: "ContractUpfront");
        }
    }
}
