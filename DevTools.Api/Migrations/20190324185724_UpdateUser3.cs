using Microsoft.EntityFrameworkCore.Migrations;

namespace DevTools.Api.Migrations
{
    public partial class UpdateUser3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Creation_Time",
                table: "tb_user",
                newName: "CreationTime");

            migrationBuilder.AlterColumn<string>(
                name: "Telephone",
                table: "tb_user",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MobilePhone",
                table: "tb_user",
                maxLength: 14,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "tb_user",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "tb_user",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "NickName",
                table: "tb_user",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusCode",
                table: "tb_user",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "tb_user");

            migrationBuilder.DropColumn(
                name: "NickName",
                table: "tb_user");

            migrationBuilder.DropColumn(
                name: "StatusCode",
                table: "tb_user");

            migrationBuilder.RenameColumn(
                name: "CreationTime",
                table: "tb_user",
                newName: "Creation_Time");

            migrationBuilder.AlterColumn<string>(
                name: "Telephone",
                table: "tb_user",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MobilePhone",
                table: "tb_user",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 14,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "tb_user",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 32,
                oldNullable: true);
        }
    }
}
