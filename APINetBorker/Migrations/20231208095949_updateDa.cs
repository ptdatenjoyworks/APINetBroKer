using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APINetBorker.Migrations
{
    /// <inheritdoc />
    public partial class updateDa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "a908dbb0-c6f3-4a1b-97af-c80a6cb26686");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "034df09b-d2c9-4fe2-a16a-859647b95d86");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "645aadbd-b552-419c-aa96-a34987748ba6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "204b2f84-c578-4187-84ad-ab56a4dce6c7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "e8509706-0f87-487d-b910-0527982295cb");

            migrationBuilder.UpdateData(
                table: "Commisions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Discriminator",
                value: "ContractUpfront");

            migrationBuilder.UpdateData(
                table: "Commisions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Discriminator",
                value: "PercentageContractResidual");
            migrationBuilder.UpdateData(
                table: "Commisions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Discriminator",
                value: "QuarterlyUpfront");


            migrationBuilder.InsertData(
                table: "Qualifications",
                columns: new[] { "Id", "Discriminator", "EffectiveDate", "ExpiryDate", "SalesProgramId" },
                values: new object[,]
                {
                    { 1, "QualificationDate", new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2199, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, "QualificationDate", new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "Qualifications",
                columns: new[] { "Id", "Discriminator", "FromAnnualUsage", "SalesProgramId", "ToAnnualUsage" },
                values: new object[] { 3, "QualificationAnnualUsage", 50000, null, 100000 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
          
            migrationBuilder.DeleteData(
                table: "Qualifications",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Qualifications",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Qualifications",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "a63bd3e9-f857-4291-8e72-b3c786d5fa8a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "8a35ef13-e1c9-41de-9655-df1eb52c37fe");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "1c5f18ab-9286-4ec0-9736-2ca657d46ad9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "2f095bae-3149-4b58-8427-181bb7f2da33");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "53bccd36-f31c-44e5-9030-3e609150bc6c");
        }
    }
}
