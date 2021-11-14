using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Infra.Data.Migrations
{
    public partial class Enums : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Key",
                table: "Configurations");

            migrationBuilder.AlterColumn<int>(
                name: "ShiftType",
                table: "Shifts",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(16)");

            migrationBuilder.AddColumn<int>(
                name: "CourseType",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ConfigurationType",
                table: "Configurations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            //migrationBuilder.CreateTable(
            //    name: "BaseEntity",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
            //        CreateUser = table.Column<string>(type: "text", nullable: true),
            //        CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
            //        ModifyUser = table.Column<string>(type: "text", nullable: true),
            //        ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
            //        Deleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
            //        DeleteUser = table.Column<string>(type: "text", nullable: true),
            //        DeleteDate = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_BaseEntity", x => x.Id);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "CourseType",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ConfigurationType",
                table: "Configurations");

            migrationBuilder.AlterColumn<byte[]>(
                name: "ShiftType",
                table: "Shifts",
                type: "varbinary(16)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<byte[]>(
                name: "Type",
                table: "Courses",
                type: "varbinary(16)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "Configurations",
                type: "varchar(250)",
                maxLength: 250,
                nullable: true);
        }
    }
}
