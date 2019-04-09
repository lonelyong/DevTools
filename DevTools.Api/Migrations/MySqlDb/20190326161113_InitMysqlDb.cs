using Microsoft.EntityFrameworkCore.Migrations;

namespace DevTools.Api.Migrations.MySqlDb
{
    public partial class InitMysqlDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_md5",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Txt = table.Column<string>(maxLength: 128, nullable: false),
                    Md5 = table.Column<string>(maxLength: 32, nullable: true),
                    CreationTime = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_md5", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_md5");
        }
    }
}
