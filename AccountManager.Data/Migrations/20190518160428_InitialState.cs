﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountManager.Data.Migrations
{
    public partial class InitialState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    AccountTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_AccountType_AccountTypeId",
                        column: x => x.AccountTypeId,
                        principalTable: "AccountType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AccountType",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 1, "1.", "Activos" });

            migrationBuilder.InsertData(
                table: "AccountType",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 2, "2.", "Pasivos" });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "AccountTypeId", "Code", "Name" },
                values: new object[] { 1, 1, "1.1", "Caja y Bancos" });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "AccountTypeId", "Code", "Name" },
                values: new object[] { 2, 1, "1.2", "Activo Circulante" });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "AccountTypeId", "Code", "Name" },
                values: new object[] { 3, 1, "1.3", "Efectivo" });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "AccountTypeId", "Code", "Name" },
                values: new object[] { 4, 1, "1.4", "Cuentas por Cobrar" });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "AccountTypeId", "Code", "Name" },
                values: new object[] { 5, 2, "2.1", "Pasivo y Capital" });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "AccountTypeId", "Code", "Name" },
                values: new object[] { 6, 2, "2.2", "Cuentas por Pagar" });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "AccountTypeId", "Code", "Name" },
                values: new object[] { 7, 2, "2.3", "Efectos por Pagar" });

            migrationBuilder.CreateIndex(
                name: "IX_Account_AccountTypeId",
                table: "Account",
                column: "AccountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_Code",
                table: "Account",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AccountType_Code",
                table: "AccountType",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "AccountType");
        }
    }
}
