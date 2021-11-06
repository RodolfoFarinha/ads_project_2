using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace Api.Infra.Data.Migrations
{
    /// <summary>
    /// Init migration
    /// </summary>
    public partial class Init : Migration
    {
        /// <summary>
        /// Up migration
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ScheduleKey = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    ScheduleVersion = table.Column<int>(type: "int", nullable: false),
                    BuildingKey = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    BuildingName = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    CreateUser = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyUser = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Deleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleteUser = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime", nullable: true),               
                },
                constraints: table =>
                {
                    table.UniqueConstraint("AK_BuildingsId", x => x.Id);
                    table.PrimaryKey("PK_Buildings", x => x.BuildingKey);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ScheduleKey = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    ScheduleVersion = table.Column<int>(type: "int", nullable: false),
                    ClassKey = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    ClassName = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    CreateUser = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyUser = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Deleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleteUser = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.UniqueConstraint("AK_ClassesId", x => x.Id);
                    table.PrimaryKey("PK_Classes", x => x.ClassKey);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ScheduleKey = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    ScheduleVersion = table.Column<int>(type: "int", nullable: false),
                    CourseKey = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    CourseName = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    Type = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    CreateUser = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyUser = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Deleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleteUser = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.UniqueConstraint("AK_CoursesId", x => x.Id);
                    table.PrimaryKey("PK_Courses", x => x.CourseKey);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PropertyKey = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    PropertyName = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    PropertyDescription = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    PropertyStatus = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AvailableManagement = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AvailableRequest = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreateUser = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyUser = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Deleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleteUser = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.UniqueConstraint("AK_PropertiesId", x => x.Id);
                    table.PrimaryKey("PK_Properties", x => x.PropertyKey);
                });

            migrationBuilder.CreateTable(
                name: "QualitySchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ScheduleKey = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    ScheduleVersion = table.Column<int>(type: "int", nullable: false),
                    TimeExecution = table.Column<TimeSpan>(type: "time", nullable: false),
                    TotalRoomsWithoutSession = table.Column<int>(type: "int", nullable: false),
                    TotalRoomsWithoutSessionMasters = table.Column<int>(type: "int", nullable: false),
                    TotalRoomsWithoutSessionDegrees = table.Column<int>(type: "int", nullable: false),
                    TotalRoomsWithoutSessionWork = table.Column<int>(type: "int", nullable: false),
                    TotalRoomsWithoutSessionAfterWork = table.Column<int>(type: "int", nullable: false),
                    TotalRoomChangeInSessions = table.Column<int>(type: "int", nullable: false),
                    TotalRoomChangeInSessionsMasters = table.Column<int>(type: "int", nullable: false),
                    TotalRoomChangeInSessionsDegrees = table.Column<int>(type: "int", nullable: false),
                    TotalRoomChangeInSessionsWork = table.Column<int>(type: "int", nullable: false),
                    TotalRoomChangeInSessionsAfterWork = table.Column<int>(type: "int", nullable: false),
                    TotalRoomChangeBetweenSessions = table.Column<int>(type: "int", nullable: false),
                    TotalRoomChangeBetweenSessionsMasters = table.Column<int>(type: "int", nullable: false),
                    TotalRoomChangeBetweenSessionsDegrees = table.Column<int>(type: "int", nullable: false),
                    TotalRoomChangeBetweenSessionsWork = table.Column<int>(type: "int", nullable: false),
                    TotalRoomChangeBetweenSessionsAfterWork = table.Column<int>(type: "int", nullable: false),
                    TotalRoomChangeInShifts = table.Column<int>(type: "int", nullable: false),
                    TotalRoomChangeInShiftsMasters = table.Column<int>(type: "int", nullable: false),
                    TotalRoomChangeInShiftsDegrees = table.Column<int>(type: "int", nullable: false),
                    TotalRoomChangeInShiftsWork = table.Column<int>(type: "int", nullable: false),
                    TotalRoomChangeInShiftsAfterWork = table.Column<int>(type: "int", nullable: false),
                    AvarageGapBetweenSessionsByShift = table.Column<int>(type: "int", nullable: false),
                    CreateUser = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyUser = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Deleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleteUser = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.UniqueConstraint("AK_QualitySchedulesId", x => x.Id);
                    table.PrimaryKey("PK_QualitySchedules", x => x.ScheduleKey);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ScheduleKey = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    ScheduleVersion = table.Column<int>(type: "int", nullable: false),
                    UnitKey = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    UnitName = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    CreateUser = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyUser = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Deleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleteUser = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.UniqueConstraint("AK_UnitsId", x => x.Id);
                    table.PrimaryKey("PK_Units", x => x.UnitKey);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ScheduleKey = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    ScheduleVersion = table.Column<int>(type: "int", nullable: false),
                    RoomKey = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    BuildingKey = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    RoomName = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    NormalCapacity = table.Column<int>(type: "int", nullable: false),
                    ExamCapacity = table.Column<int>(type: "int", nullable: false),
                    CreateUser = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyUser = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Deleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleteUser = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.UniqueConstraint("AK_RoomsId", x => x.Id);
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
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CourseUnitKey = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    CourseKey = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    UnitKey = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    CreateUser = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyUser = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Deleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleteUser = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.UniqueConstraint("AK_CourseUnitsId", x => x.Id);
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
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ScheduleKey = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    ScheduleVersion = table.Column<int>(type: "int", nullable: false),
                    ShiftKey = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    UnitKey = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    ShiftType = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    EnrolledStudents = table.Column<int>(type: "int", nullable: false),
                    CreateUser = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyUser = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Deleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleteUser = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.UniqueConstraint("AK_ShiftsId", x => x.Id);
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
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RoomPropertyKey = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    RoomKey = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    PropertyKey = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    CreateUser = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyUser = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Deleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleteUser = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.UniqueConstraint("AK_RoomPropertiesId", x => x.Id);
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
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ClassShiftKey = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    ClassKey = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    ShiftKey = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    CreateUser = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyUser = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Deleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleteUser = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.UniqueConstraint("AK_ClassShiftsId", x => x.Id);
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
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ScheduleKey = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    ScheduleVersion = table.Column<int>(type: "int", nullable: false),
                    SessionKey = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    ShiftKey = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    PropertyKey = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreateUser = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyUser = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Deleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleteUser = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.UniqueConstraint("AK_SessionsId", x => x.Id);
                    table.PrimaryKey("PK_Sessions", x => x.SessionKey);
                    table.ForeignKey(
                        name: "FK_Sessions_Properties_PropertyKey",
                        column: x => x.PropertyKey,
                        principalTable: "Properties",
                        principalColumn: "PropertyKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sessions_Shifts_ShiftKey",
                        column: x => x.ShiftKey,
                        principalTable: "Shifts",
                        principalColumn: "ShiftKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Slots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ScheduleKey = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    ScheduleVersion = table.Column<int>(type: "int", nullable: false),
                    SlotKey = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    SessionKey = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    RoomKey = table.Column<byte[]>(type: "varbinary(16)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreateUser = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifyUser = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Deleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleteUser = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.UniqueConstraint("AK_SlotsId", x => x.Id);
                    table.PrimaryKey("PK_Slots", x => x.SlotKey);
                    table.ForeignKey(
                        name: "FK_Slots_Rooms_RoomKey",
                        column: x => x.RoomKey,
                        principalTable: "Rooms",
                        principalColumn: "RoomKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Slots_Sessions_SessionKey",
                        column: x => x.SessionKey,
                        principalTable: "Sessions",
                        principalColumn: "SessionKey",
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
                name: "IX_QualitySchedules_Id",
                table: "QualitySchedules",
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
                name: "IX_Slots_Id",
                table: "Slots",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Slots_RoomKey",
                table: "Slots",
                column: "RoomKey");

            migrationBuilder.CreateIndex(
                name: "IX_Slots_SessionKey",
                table: "Slots",
                column: "SessionKey");

            migrationBuilder.CreateIndex(
                name: "IX_Units_Id",
                table: "Units",
                column: "Id",
                unique: true);
        }

        /// <summary>
        /// Down migration
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseEntity");

            migrationBuilder.DropTable(
                name: "ClassShifts");

            migrationBuilder.DropTable(
                name: "CourseUnits");

            migrationBuilder.DropTable(
                name: "QualitySchedules");

            migrationBuilder.DropTable(
                name: "RoomProperties");

            migrationBuilder.DropTable(
                name: "Slots");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Shifts");

            migrationBuilder.DropTable(
                name: "Units");
        }
    }
}
