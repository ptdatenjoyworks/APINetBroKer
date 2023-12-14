using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APINetBorker.Migrations
{
    /// <inheritdoc />
    public partial class updateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commision_DateConfigs_DateConfigId",
                table: "Commision");

            migrationBuilder.DropForeignKey(
                name: "FK_Commision_SalePrograms_SalesProgramId",
                table: "Commision");

            migrationBuilder.DropForeignKey(
                name: "FK_DateConfigs_Commision_CommisionId",
                table: "DateConfigs");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierDeposit_Suppliers_SupplierId",
                table: "SupplierDeposit");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierDeposit_Suppliers_SupplierId1",
                table: "SupplierDeposit");

            migrationBuilder.DropIndex(
                name: "IX_DateConfigs_CommisionId",
                table: "DateConfigs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SupplierDeposit",
                table: "SupplierDeposit");

            migrationBuilder.DropIndex(
                name: "IX_SupplierDeposit_SupplierId1",
                table: "SupplierDeposit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Commision",
                table: "Commision");

            migrationBuilder.DropIndex(
                name: "IX_Commision_DateConfigId",
                table: "Commision");
        
            migrationBuilder.DropColumn(
                name: "SupplierId1",
                table: "SupplierDeposit");

            migrationBuilder.DropColumn(
                name: "DateConfigId",
                table: "Commision");

            migrationBuilder.RenameTable(
                name: "SupplierDeposit",
                newName: "SupplierDeposits");

            migrationBuilder.RenameTable(
                name: "Commision",
                newName: "Commisions");

            migrationBuilder.RenameIndex(
                name: "IX_SupplierDeposit_SupplierId",
                table: "SupplierDeposits",
                newName: "IX_SupplierDeposits_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_Commision_SalesProgramId",
                table: "Commisions",
                newName: "IX_Commisions_SalesProgramId");

            migrationBuilder.AlterColumn<int>(
                name: "ControlDateOffsetValue",
                table: "DateConfigs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SupplierId",
                table: "Contracts",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Contracts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UtilityAccountNumber",
                table: "ContractItems",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ForecastState",
                table: "ContractItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SaleProgramId",
                table: "ContractItems",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SalesProgramId",
                table: "ContractItems",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ContractItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Path",
                table: "ContractItemAttchment",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Commisions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SupplierDeposits",
                table: "SupplierDeposits",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Commisions",
                table: "Commisions",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "a679ec92-cd5c-46b8-8296-4bda7fe449a4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "31d0d66e-4de3-4f97-bb76-c06efa2f2f18");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "e9a14471-c3d2-4c6c-a87e-e922d556c2de");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "b7425d0e-313e-4cd3-831a-8e73d7f00a9c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "8a9861b3-01ed-4ef0-9f72-4031a58e7eb0");

            migrationBuilder.UpdateData(
                table: "ContractItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Adder", "AnnualUsage", "EndDate", "ForecastState", "Rate", "SaleProgramId", "SalesProgramId", "StartDate", "Status", "TermMonth", "UtilityAccountNumber" },
                values: new object[] { 0.0075m, 58398, new DateTime(2025, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0.01275m, null, null, new DateTime(2023, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 24, "9138014006" });

            migrationBuilder.UpdateData(
                table: "ContractItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Adder", "AnnualUsage", "ContractsId", "EndDate", "EnergyUnitType", "ForecastState", "Rate", "SaleProgramId", "SalesProgramId", "StartDate", "Status", "TermMonth", "UtilityAccountNumber" },
                values: new object[] { 0.073m, 12303, 1, new DateTime(2024, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0, 0.2275m, null, null, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 16, "9138014006" });

            migrationBuilder.UpdateData(
                table: "ContractItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Adder", "AnnualUsage", "ContractsId", "EndDate", "EnergyUnitType", "ForecastState", "ProductType", "Rate", "SaleProgramId", "SalesProgramId", "StartDate", "Status", "TermMonth", "UtilityAccountNumber" },
                values: new object[] { 6.3m, 835, 1, new DateTime(2024, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 0, 1, 23m, null, null, new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 12, "9138014006" });

            migrationBuilder.UpdateData(
                table: "ContractItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Adder", "AnnualUsage", "ContractsId", "EndDate", "ForecastState", "Rate", "SaleProgramId", "SalesProgramId", "StartDate", "Status", "TermMonth", "UtilityAccountNumber" },
                values: new object[] { 0.0073m, 160880, 1, new DateTime(2024, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0.02275m, null, null, new DateTime(2023, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 15, "9138014006" });

            migrationBuilder.UpdateData(
                table: "ContractItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Adder", "AnnualUsage", "ContractsId", "EndDate", "EnergyUnitType", "ForecastState", "ProductType", "Rate", "SaleProgramId", "SalesProgramId", "StartDate", "Status", "TermMonth", "UtilityAccountNumber" },
                values: new object[] { 0.083m, 89340, 1, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0, 2, 0.3275m, null, null, new DateTime(2023, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 12, "9138014006" });

            migrationBuilder.InsertData(
                table: "ContractItems",
                columns: new[] { "Id", "Adder", "AnnualUsage", "ContractsId", "EndDate", "EnergyUnitType", "ForecastState", "IsActive", "ProductType", "Rate", "SaleProgramId", "SalesProgramId", "StartDate", "Status", "TermMonth", "UtilityAccountNumber" },
                values: new object[,]
                {
                    { 6, 0.003m, 36000, 2, new DateTime(2024, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 0, true, 1, 0.0225m, null, null, new DateTime(2023, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 17, "177478640021" },
                    { 7, 0.073m, 4200, 2, new DateTime(2024, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 0, true, 2, 2.275m, null, null, new DateTime(2023, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 14, "177478640021" },
                    { 8, 5.32m, 1500, 2, new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 0, true, 1, 20.75m, null, null, new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 16, "177478640021" },
                    { 9, 0.053m, 60000, 2, new DateTime(2024, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0, true, 2, 0.1275m, null, null, new DateTime(2023, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 18, "177478640021" },
                    { 10, 0.0033m, 15000, 2, new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 0, true, 1, 0.04275m, null, null, new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 15, "177478640021" }
                });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BillingChargeType", "BillingType", "EnrollmentType", "LegalEntityName", "PricingType", "SoldDate", "StartDate" },
                values: new object[] { 1, 1, 1, "John A", 1, new DateTime(2023, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BillingChargeType", "BillingType", "ContactId", "CustomerId", "EnrollmentType", "LegalEntityName", "PricingType", "StartDate" },
                values: new object[] { 1, 1, 1, 1, 1, "Jelly B", 1, null });

            migrationBuilder.InsertData(
                table: "SalePrograms",
                columns: new[] { "Id", "Description", "EnergyUnitType", "SalesProgramType" },
                values: new object[,]
                {
                    { 1, "50% contract upfront then residual", 4, "PercentageContractUpfront + PercentageContractResidual" },
                    { 2, "Forecast annual margin divided by four", 2, "QuarterlyUpfront" }
                });

            migrationBuilder.InsertData(
                table: "Commisions",
                columns: new[] { "Id", "CommissionConfigurationTypeId", "Discriminator", "MarginPercent", "ProgramAdder", "ProgramAdderType", "SalesProgramId" },
                values: new object[,]
                {
                    { 1, "ContractUpfront", "Commision", 0.5m, 0.007m, 1, 1 },
                    { 2, "PercentageContractResidual", "Commision", 0.5m, 0.007m, 1, 1 },
                    { 3, "QuarterlyUpfront", "Commision", 0m, 0.007m, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "DateConfigs",
                columns: new[] { "Id", "CommisionId", "ControlDateModifierType", "ControlDateOffsetType", "ControlDateOffsetValue", "ControlDateType" },
                values: new object[,]
                {
                    { 1, 1, 0, 1, 2, 1 },
                    { 2, 2, 0, 0, 0, 1 },
                    { 3, 3, 0, 0, 0, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DateConfigs_CommisionId",
                table: "DateConfigs",
                column: "CommisionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContractItems_SalesProgramId",
                table: "ContractItems",
                column: "SalesProgramId");

            migrationBuilder.AddForeignKey(
                name: "FK_Commisions_SalePrograms_SalesProgramId",
                table: "Commisions",
                column: "SalesProgramId",
                principalTable: "SalePrograms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractItems_SalePrograms_SalesProgramId",
                table: "ContractItems",
                column: "SalesProgramId",
                principalTable: "SalePrograms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DateConfigs_Commisions_CommisionId",
                table: "DateConfigs",
                column: "CommisionId",
                principalTable: "Commisions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierDeposits_Suppliers_SupplierId",
                table: "SupplierDeposits",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.DeleteData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: 5);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commisions_SalePrograms_SalesProgramId",
                table: "Commisions");

            migrationBuilder.DropForeignKey(
                name: "FK_ContractItems_SalePrograms_SalesProgramId",
                table: "ContractItems");

            migrationBuilder.DropForeignKey(
                name: "FK_DateConfigs_Commisions_CommisionId",
                table: "DateConfigs");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierDeposits_Suppliers_SupplierId",
                table: "SupplierDeposits");

            migrationBuilder.DropIndex(
                name: "IX_DateConfigs_CommisionId",
                table: "DateConfigs");

            migrationBuilder.DropIndex(
                name: "IX_ContractItems_SalesProgramId",
                table: "ContractItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SupplierDeposits",
                table: "SupplierDeposits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Commisions",
                table: "Commisions");

            migrationBuilder.DeleteData(
                table: "ContractItems",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ContractItems",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ContractItems",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ContractItems",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ContractItems",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "DateConfigs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DateConfigs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DateConfigs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Commisions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Commisions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Commisions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SalePrograms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SalePrograms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "ForecastState",
                table: "ContractItems");

            migrationBuilder.DropColumn(
                name: "SaleProgramId",
                table: "ContractItems");

            migrationBuilder.DropColumn(
                name: "SalesProgramId",
                table: "ContractItems");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ContractItems");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Commisions");

            migrationBuilder.RenameTable(
                name: "SupplierDeposits",
                newName: "SupplierDeposit");

            migrationBuilder.RenameTable(
                name: "Commisions",
                newName: "Commision");

            migrationBuilder.RenameIndex(
                name: "IX_SupplierDeposits_SupplierId",
                table: "SupplierDeposit",
                newName: "IX_SupplierDeposit_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_Commisions_SalesProgramId",
                table: "Commision",
                newName: "IX_Commision_SalesProgramId");

            migrationBuilder.AlterColumn<int>(
                name: "ControlDateOffsetValue",
                table: "DateConfigs",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "SupplierId",
                table: "Contracts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UtilityAccountNumber",
                table: "ContractItems",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Path",
                table: "ContractItemAttchment",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SupplierId1",
                table: "SupplierDeposit",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DateConfigId",
                table: "Commision",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SupplierDeposit",
                table: "SupplierDeposit",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Commision",
                table: "Commision",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "9f51968a-023c-48af-8778-6d1f9f896058");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "ad9a41dd-f54c-4db6-85a6-77df1403370a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "5a378440-b3a1-4345-8631-0e7e1c699f06");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "c4c5d301-3008-460c-a44c-babe83b9d7e2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "a176ded4-7e44-4185-bb48-5adddb39affa");

            migrationBuilder.UpdateData(
                table: "ContractItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Adder", "AnnualUsage", "EndDate", "Rate", "StartDate", "TermMonth", "UtilityAccountNumber" },
                values: new object[] { 1m, 1, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1m, new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1 });

            migrationBuilder.UpdateData(
                table: "ContractItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Adder", "AnnualUsage", "ContractsId", "EndDate", "EnergyUnitType", "Rate", "StartDate", "TermMonth", "UtilityAccountNumber" },
                values: new object[] { 2m, 2, 2, new DateTime(2023, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2m, new DateTime(2023, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2 });

            migrationBuilder.UpdateData(
                table: "ContractItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Adder", "AnnualUsage", "ContractsId", "EndDate", "EnergyUnitType", "ProductType", "Rate", "StartDate", "TermMonth", "UtilityAccountNumber" },
                values: new object[] { 3m, 3, 3, new DateTime(2023, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 3m, new DateTime(2023, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 3 });

            migrationBuilder.UpdateData(
                table: "ContractItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Adder", "AnnualUsage", "ContractsId", "EndDate", "Rate", "StartDate", "TermMonth", "UtilityAccountNumber" },
                values: new object[] { 4m, 4, 4, new DateTime(2023, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 4m, new DateTime(2023, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 4 });

            migrationBuilder.UpdateData(
                table: "ContractItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Adder", "AnnualUsage", "ContractsId", "EndDate", "EnergyUnitType", "ProductType", "Rate", "StartDate", "TermMonth", "UtilityAccountNumber" },
                values: new object[] { 5m, 5, 5, new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1, 5m, new DateTime(2023, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 5 });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BillingChargeType", "BillingType", "EnrollmentType", "LegalEntityName", "PricingType", "SoldDate" },
                values: new object[] { 0, 0, 0, "a", 0, new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BillingChargeType", "BillingType", "ContactId", "CustomerId", "EnrollmentType", "LegalEntityName", "PricingType" },
                values: new object[] { 0, 0, 2, 2, 0, "b", 0 });

            migrationBuilder.InsertData(
                table: "Contracts",
                columns: new[] { "Id", "ApplicationUserId", "BillingChargeType", "BillingType", "CloserId", "ContactId", "CustomerId", "EnrollmentType", "FronterId", "IsActive", "LegalEntityName", "PricingType", "SoldDate", "Stage", "SupplierId" },
                values: new object[,]
                {
                    { 3, null, 0, 0, 3, 3, 3, 0, 3, true, "c", 0, new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 3 },
                    { 4, null, 0, 0, 4, 4, 4, 0, 4, true, "d", 0, new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 4 },
                    { 5, null, 0, 0, 5, 5, 5, 0, 5, true, "f", 0, new DateTime(2023, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 5 }
                });

            migrationBuilder.UpdateData(
                table: "SupplierDeposit",
                keyColumn: "Id",
                keyValue: 1,
                column: "SupplierId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "SupplierDeposit",
                keyColumn: "Id",
                keyValue: 2,
                column: "SupplierId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "SupplierDeposit",
                keyColumn: "Id",
                keyValue: 3,
                column: "SupplierId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "SupplierDeposit",
                keyColumn: "Id",
                keyValue: 4,
                column: "SupplierId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "SupplierDeposit",
                keyColumn: "Id",
                keyValue: 5,
                column: "SupplierId1",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_DateConfigs_CommisionId",
                table: "DateConfigs",
                column: "CommisionId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierDeposit_SupplierId1",
                table: "SupplierDeposit",
                column: "SupplierId1");

            migrationBuilder.CreateIndex(
                name: "IX_Commision_DateConfigId",
                table: "Commision",
                column: "DateConfigId");

            migrationBuilder.AddForeignKey(
                name: "FK_Commision_DateConfigs_DateConfigId",
                table: "Commision",
                column: "DateConfigId",
                principalTable: "DateConfigs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Commision_SalePrograms_SalesProgramId",
                table: "Commision",
                column: "SalesProgramId",
                principalTable: "SalePrograms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DateConfigs_Commision_CommisionId",
                table: "DateConfigs",
                column: "CommisionId",
                principalTable: "Commision",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierDeposit_Suppliers_SupplierId",
                table: "SupplierDeposit",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierDeposit_Suppliers_SupplierId1",
                table: "SupplierDeposit",
                column: "SupplierId1",
                principalTable: "Suppliers",
                principalColumn: "Id");
        }
    }
}
