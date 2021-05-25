using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace homework_20.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ServiceType",
                table: "ServiceItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "b9abbc38-47aa-4b64-86fe-7162f8b438b7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "756490cf-3c39-46ae-92b4-f4d4ee33a2eb", "AQAAAAEAACcQAAAAEFfsOQj39ngOFYqJOVZPfAJed6r4JX0XMNq90914loI3Gqax31BLq6MtcojnOrBzkA==" });

            migrationBuilder.UpdateData(
                table: "TextFileds",
                keyColumn: "Id",
                keyValue: new Guid("4aa76a4c-c59d-409a-84c1-06e6487a137a"),
                column: "DateAdd",
                value: new DateTime(2021, 5, 24, 18, 57, 28, 605, DateTimeKind.Local).AddTicks(6490));

            migrationBuilder.UpdateData(
                table: "TextFileds",
                keyColumn: "Id",
                keyValue: new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"),
                column: "DateAdd",
                value: new DateTime(2021, 5, 24, 18, 57, 28, 601, DateTimeKind.Local).AddTicks(8271));

            migrationBuilder.UpdateData(
                table: "TextFileds",
                keyColumn: "Id",
                keyValue: new Guid("70bf165a-700a-4156-91c0-e83fce0a277f"),
                column: "DateAdd",
                value: new DateTime(2021, 5, 24, 18, 57, 28, 605, DateTimeKind.Local).AddTicks(6398));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceType",
                table: "ServiceItems");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "abd197ef-22d6-4123-9b45-9000f5ad7d08");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "80a73526-ade2-4b80-a438-f302e7a6e9c8", "AQAAAAEAACcQAAAAEFA3Rc56yAnoKFsdga9IOCx/Zevwiy8YDtxU1laqIMrgrKr4Ak9a7sDe+FDSQIWJGw==" });

            migrationBuilder.UpdateData(
                table: "TextFileds",
                keyColumn: "Id",
                keyValue: new Guid("4aa76a4c-c59d-409a-84c1-06e6487a137a"),
                column: "DateAdd",
                value: new DateTime(2021, 5, 24, 15, 18, 21, 9, DateTimeKind.Local).AddTicks(9160));

            migrationBuilder.UpdateData(
                table: "TextFileds",
                keyColumn: "Id",
                keyValue: new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"),
                column: "DateAdd",
                value: new DateTime(2021, 5, 24, 15, 18, 21, 6, DateTimeKind.Local).AddTicks(6755));

            migrationBuilder.UpdateData(
                table: "TextFileds",
                keyColumn: "Id",
                keyValue: new Guid("70bf165a-700a-4156-91c0-e83fce0a277f"),
                column: "DateAdd",
                value: new DateTime(2021, 5, 24, 15, 18, 21, 9, DateTimeKind.Local).AddTicks(9066));
        }
    }
}
