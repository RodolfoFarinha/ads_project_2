using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Infra.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "BaseEntity",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        ModifyUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        Deleted = table.Column<bool>(type: "bit", nullable: false),
            //        DeleteUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_BaseEntity", x => x.Id);
            //    });

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyUser = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleteUser = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.BuildingKey);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreateUser = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyUser = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleteUser = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ClassKey);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreateUser = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyUser = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleteUser = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseKey);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PropertyName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PropertyDescription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PropertyStatus = table.Column<bool>(type: "bit", nullable: false),
                    AvailableManagement = table.Column<bool>(type: "bit", nullable: false),
                    AvailableRequest = table.Column<bool>(type: "bit", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyUser = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleteUser = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.PropertyKey);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnitName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreateUser = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyUser = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleteUser = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.UnitKey);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BuildingKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    NormalCapacity = table.Column<int>(type: "int", nullable: false),
                    ExamCapacity = table.Column<int>(type: "int", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyUser = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleteUser = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomKey);
                    table.ForeignKey(
                        name: "FK_Rooms_Buildings_BuildingKey",
                        column: x => x.BuildingKey,
                        principalTable: "Buildings",
                        principalColumn: "BuildingKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseUnitKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnitKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyUser = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleteUser = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseUnits", x => x.CourseUnitKey);
                    table.ForeignKey(
                        name: "FK_CourseUnits_Courses_CourseKey",
                        column: x => x.CourseKey,
                        principalTable: "Courses",
                        principalColumn: "CourseKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseUnits_Units_UnitKey",
                        column: x => x.UnitKey,
                        principalTable: "Units",
                        principalColumn: "UnitKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Shifts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnitKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnrolledStudents = table.Column<int>(type: "int", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyUser = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleteUser = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.ShiftKey);
                    table.ForeignKey(
                        name: "FK_Shifts_Units_UnitKey",
                        column: x => x.UnitKey,
                        principalTable: "Units",
                        principalColumn: "UnitKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoomProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomPropertyKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PropertyKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyUser = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleteUser = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomProperties", x => x.RoomPropertyKey);
                    table.ForeignKey(
                        name: "FK_RoomProperties_Properties_PropertyKey",
                        column: x => x.PropertyKey,
                        principalTable: "Properties",
                        principalColumn: "PropertyKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoomProperties_Rooms_RoomKey",
                        column: x => x.RoomKey,
                        principalTable: "Rooms",
                        principalColumn: "RoomKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClassShifts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassShiftKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShiftKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyUser = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleteUser = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassShifts", x => x.ClassShiftKey);
                    table.ForeignKey(
                        name: "FK_ClassShifts_Classes_ClassKey",
                        column: x => x.ClassKey,
                        principalTable: "Classes",
                        principalColumn: "ClassKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassShifts_Shifts_ShiftKey",
                        column: x => x.ShiftKey,
                        principalTable: "Shifts",
                        principalColumn: "ShiftKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShiftKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PropertyKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomKey = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyUser = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleteUser = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.SessionKey);
                    table.ForeignKey(
                        name: "FK_Sessions_Properties_PropertyKey",
                        column: x => x.PropertyKey,
                        principalTable: "Properties",
                        principalColumn: "PropertyKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sessions_Rooms_RoomKey",
                        column: x => x.RoomKey,
                        principalTable: "Rooms",
                        principalColumn: "RoomKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sessions_Shifts_ShiftKey",
                        column: x => x.ShiftKey,
                        principalTable: "Shifts",
                        principalColumn: "ShiftKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_Id",
                table: "Buildings",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Classes_Id",
                table: "Classes",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClassShifts_ClassKey_ShiftKey",
                table: "ClassShifts",
                columns: new[] { "ClassKey", "ShiftKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClassShifts_Id",
                table: "ClassShifts",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClassShifts_ShiftKey",
                table: "ClassShifts",
                column: "ShiftKey");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Id",
                table: "Courses",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseUnits_CourseKey_UnitKey",
                table: "CourseUnits",
                columns: new[] { "CourseKey", "UnitKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseUnits_Id",
                table: "CourseUnits",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseUnits_UnitKey",
                table: "CourseUnits",
                column: "UnitKey");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_Id",
                table: "Properties",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoomProperties_Id",
                table: "RoomProperties",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoomProperties_PropertyKey",
                table: "RoomProperties",
                column: "PropertyKey");

            migrationBuilder.CreateIndex(
                name: "IX_RoomProperties_RoomKey_PropertyKey",
                table: "RoomProperties",
                columns: new[] { "RoomKey", "PropertyKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_BuildingKey",
                table: "Rooms",
                column: "BuildingKey");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_Id",
                table: "Rooms",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_Id",
                table: "Sessions",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_PropertyKey",
                table: "Sessions",
                column: "PropertyKey");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_RoomKey",
                table: "Sessions",
                column: "RoomKey");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_ShiftKey",
                table: "Sessions",
                column: "ShiftKey");

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_Id",
                table: "Shifts",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_UnitKey",
                table: "Shifts",
                column: "UnitKey");

            migrationBuilder.CreateIndex(
                name: "IX_Units_Id",
                table: "Units",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseEntity");

            migrationBuilder.DropTable(
                name: "ClassShifts");

            migrationBuilder.DropTable(
                name: "CourseUnits");

            migrationBuilder.DropTable(
                name: "RoomProperties");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Shifts");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "Units");
        }
    }
}
