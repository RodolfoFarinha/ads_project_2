﻿// <auto-generated />
using System;
using Api.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Infra.Data.Migrations
{
    [DbContext(typeof(ApiDBContext))]
    [Migration("20211105225722_Init")]
    partial class Init
    {
        /// <summary>
        /// Build target model
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.11");

            //modelBuilder.Entity("Api.Domain.Entities.BaseEntity", b =>
            //    {
            //        b.Property<int>("Id")
            //            .ValueGeneratedOnAdd()
            //            .HasColumnType("int");

            //        b.Property<DateTime?>("CreateDate")
            //            .HasColumnType("datetime");

            //        b.Property<string>("CreateUser")
            //            .HasColumnType("text");

            //        b.Property<DateTime?>("DeleteDate")
            //            .HasColumnType("datetime");

            //        b.Property<string>("DeleteUser")
            //            .HasColumnType("text");

            //        b.Property<bool>("Deleted")
            //            .HasColumnType("tinyint(1)");

            //        b.Property<DateTime?>("ModifyDate")
            //            .HasColumnType("datetime");

            //        b.Property<string>("ModifyUser")
            //            .HasColumnType("text");

            //        b.HasKey("Id");

            //        b.ToTable("BaseEntity");
            //    });

            modelBuilder.Entity("Api.Domain.Entities.Configuration", b =>
            {
                b.Property<byte[]>("ConfigurationKey")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("varbinary(16)");

                b.Property<string>("Key")
                    .HasMaxLength(250)
                    .HasColumnType("varchar(250)");

                b.Property<string>("Value")
                    .HasMaxLength(250)
                    .HasColumnType("varchar(250)");

                b.Property<DateTime?>("CreateDate")
                    .HasColumnType("datetime");

                b.Property<string>("CreateUser")
                    .HasMaxLength(250)
                    .HasColumnType("varchar(250)");

                b.Property<DateTime?>("DeleteDate")
                    .HasColumnType("datetime");

                b.Property<string>("DeleteUser")
                    .HasMaxLength(250)
                    .HasColumnType("varchar(250)");

                b.Property<bool>("Deleted")
                    .HasColumnType("tinyint(1)");

                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                b.Property<DateTime?>("ModifyDate")
                    .HasColumnType("datetime");

                b.Property<string>("ModifyUser")
                    .HasMaxLength(250)
                    .HasColumnType("varchar(250)");

                b.HasKey("ConfigurationKey");

                b.HasIndex("Id")
                    .IsUnique();

                b.ToTable("Configurations");
            });

            modelBuilder.Entity("Api.Domain.Entities.Building", b =>
                {
                    b.Property<byte[]>("BuildingKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("BuildingName")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("CreateUser")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime");

                    b.Property<string>("DeleteUser")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime");

                    b.Property<string>("ModifyUser")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<byte[]>("ScheduleKey")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.Property<int>("ScheduleVersion")
                        .HasColumnType("int");

                    b.HasKey("BuildingKey");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("Api.Domain.Entities.Class", b =>
                {
                    b.Property<byte[]>("ClassKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("ClassName")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("CreateUser")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime");

                    b.Property<string>("DeleteUser")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime");

                    b.Property<string>("ModifyUser")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<byte[]>("ScheduleKey")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.Property<int>("ScheduleVersion")
                        .HasColumnType("int");

                    b.HasKey("ClassKey");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("Api.Domain.Entities.ClassShift", b =>
                {
                    b.Property<byte[]>("ClassShiftKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<byte[]>("ClassKey")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("CreateUser")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime");

                    b.Property<string>("DeleteUser")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime");

                    b.Property<string>("ModifyUser")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<byte[]>("ShiftKey")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.HasKey("ClassShiftKey");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("ShiftKey");

                    b.HasIndex("ClassKey", "ShiftKey")
                        .IsUnique();

                    b.ToTable("ClassShifts");
                });

            modelBuilder.Entity("Api.Domain.Entities.Course", b =>
                {
                    b.Property<byte[]>("CourseKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("CourseName")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("CreateUser")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime");

                    b.Property<string>("DeleteUser")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime");

                    b.Property<string>("ModifyUser")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<byte[]>("ScheduleKey")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.Property<int>("ScheduleVersion")
                        .HasColumnType("int");

                    b.Property<byte[]>("Type")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.HasKey("CourseKey");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Api.Domain.Entities.CourseUnit", b =>
                {
                    b.Property<byte[]>("CourseUnitKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<byte[]>("CourseKey")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("CreateUser")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime");

                    b.Property<string>("DeleteUser")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime");

                    b.Property<string>("ModifyUser")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<byte[]>("UnitKey")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.HasKey("CourseUnitKey");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("UnitKey");

                    b.HasIndex("CourseKey", "UnitKey")
                        .IsUnique();

                    b.ToTable("CourseUnits");
                });

            modelBuilder.Entity("Api.Domain.Entities.Property", b =>
                {
                    b.Property<byte[]>("PropertyKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<bool>("AvailableManagement")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("AvailableRequest")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("CreateUser")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime");

                    b.Property<string>("DeleteUser")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime");

                    b.Property<string>("ModifyUser")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("PropertyDescription")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("PropertyName")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<bool>("PropertyStatus")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("PropertyKey");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("Api.Domain.Entities.QualitySchedule", b =>
                {
                    b.Property<byte[]>("ScheduleKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<int>("AvarageGapBetweenSessionsByShift")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("CreateUser")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime");

                    b.Property<string>("DeleteUser")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime");

                    b.Property<string>("ModifyUser")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<int>("ScheduleVersion")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("TimeExecution")
                        .HasColumnType("time");

                    b.Property<int>("TotalRoomChangeBetweenSessions")
                        .HasColumnType("int");

                    b.Property<int>("TotalRoomChangeBetweenSessionsAfterWork")
                        .HasColumnType("int");

                    b.Property<int>("TotalRoomChangeBetweenSessionsDegrees")
                        .HasColumnType("int");

                    b.Property<int>("TotalRoomChangeBetweenSessionsMasters")
                        .HasColumnType("int");

                    b.Property<int>("TotalRoomChangeBetweenSessionsWork")
                        .HasColumnType("int");

                    b.Property<int>("TotalRoomChangeInSessions")
                        .HasColumnType("int");

                    b.Property<int>("TotalRoomChangeInSessionsAfterWork")
                        .HasColumnType("int");

                    b.Property<int>("TotalRoomChangeInSessionsDegrees")
                        .HasColumnType("int");

                    b.Property<int>("TotalRoomChangeInSessionsMasters")
                        .HasColumnType("int");

                    b.Property<int>("TotalRoomChangeInSessionsWork")
                        .HasColumnType("int");

                    b.Property<int>("TotalRoomChangeInShifts")
                        .HasColumnType("int");

                    b.Property<int>("TotalRoomChangeInShiftsAfterWork")
                        .HasColumnType("int");

                    b.Property<int>("TotalRoomChangeInShiftsDegrees")
                        .HasColumnType("int");

                    b.Property<int>("TotalRoomChangeInShiftsMasters")
                        .HasColumnType("int");

                    b.Property<int>("TotalRoomChangeInShiftsWork")
                        .HasColumnType("int");

                    b.Property<int>("TotalRoomsWithoutSession")
                        .HasColumnType("int");

                    b.Property<int>("TotalRoomsWithoutSessionAfterWork")
                        .HasColumnType("int");

                    b.Property<int>("TotalRoomsWithoutSessionDegrees")
                        .HasColumnType("int");

                    b.Property<int>("TotalRoomsWithoutSessionMasters")
                        .HasColumnType("int");

                    b.Property<int>("TotalRoomsWithoutSessionWork")
                        .HasColumnType("int");

                    b.HasKey("ScheduleKey");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("QualitySchedules");
                });

            modelBuilder.Entity("Api.Domain.Entities.Room", b =>
                {
                    b.Property<byte[]>("RoomKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<byte[]>("BuildingKey")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("CreateUser")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime");

                    b.Property<string>("DeleteUser")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("ExamCapacity")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime");

                    b.Property<string>("ModifyUser")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<int>("NormalCapacity")
                        .HasColumnType("int");

                    b.Property<string>("RoomName")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<byte[]>("ScheduleKey")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.Property<int>("ScheduleVersion")
                        .HasColumnType("int");

                    b.HasKey("RoomKey");

                    b.HasIndex("BuildingKey");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Api.Domain.Entities.RoomProperty", b =>
                {
                    b.Property<byte[]>("RoomPropertyKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("CreateUser")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime");

                    b.Property<string>("DeleteUser")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime");

                    b.Property<string>("ModifyUser")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<byte[]>("PropertyKey")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.Property<byte[]>("RoomKey")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.HasKey("RoomPropertyKey");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("PropertyKey");

                    b.HasIndex("RoomKey", "PropertyKey")
                        .IsUnique();

                    b.ToTable("RoomProperties");
                });

            modelBuilder.Entity("Api.Domain.Entities.Session", b =>
                {
                    b.Property<byte[]>("SessionKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("CreateUser")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime");

                    b.Property<string>("DeleteUser")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime");

                    b.Property<string>("ModifyUser")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<byte[]>("PropertyKey")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.Property<byte[]>("ScheduleKey")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.Property<int>("ScheduleVersion")
                        .HasColumnType("int");

                    b.Property<byte[]>("ShiftKey")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime");

                    b.HasKey("SessionKey");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("PropertyKey");

                    b.HasIndex("ShiftKey");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("Api.Domain.Entities.Shift", b =>
                {
                    b.Property<byte[]>("ShiftKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("CreateUser")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime");

                    b.Property<string>("DeleteUser")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("EnrolledStudents")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime");

                    b.Property<string>("ModifyUser")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<byte[]>("ScheduleKey")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.Property<int>("ScheduleVersion")
                        .HasColumnType("int");

                    b.Property<string>("ShiftName")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<byte[]>("ShiftType")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.Property<byte[]>("UnitKey")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.HasKey("ShiftKey");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("UnitKey");

                    b.ToTable("Shifts");
                });

            modelBuilder.Entity("Api.Domain.Entities.Slot", b =>
                {
                    b.Property<byte[]>("SlotKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("CreateUser")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime");

                    b.Property<string>("DeleteUser")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime");

                    b.Property<string>("ModifyUser")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<byte[]>("RoomKey")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.Property<byte[]>("ScheduleKey")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.Property<int>("ScheduleVersion")
                        .HasColumnType("int");

                    b.Property<byte[]>("SessionKey")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime");

                    b.HasKey("SlotKey");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("RoomKey");

                    b.HasIndex("SessionKey");

                    b.ToTable("Slots");
                });

            modelBuilder.Entity("Api.Domain.Entities.Unit", b =>
                {
                    b.Property<byte[]>("UnitKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("CreateUser")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime");

                    b.Property<string>("DeleteUser")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime");

                    b.Property<string>("ModifyUser")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<byte[]>("ScheduleKey")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.Property<int>("ScheduleVersion")
                        .HasColumnType("int");

                    b.Property<string>("UnitName")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.HasKey("UnitKey");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Units");
                });

            modelBuilder.Entity("Api.Domain.Entities.ClassShift", b =>
                {
                    b.HasOne("Api.Domain.Entities.Class", "Class")
                        .WithMany("ClassShifts")
                        .HasForeignKey("ClassKey")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Api.Domain.Entities.Shift", "Shift")
                        .WithMany("ShiftClasses")
                        .HasForeignKey("ShiftKey")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Shift");
                });

            modelBuilder.Entity("Api.Domain.Entities.CourseUnit", b =>
                {
                    b.HasOne("Api.Domain.Entities.Course", "Course")
                        .WithMany("CourseUnits")
                        .HasForeignKey("CourseKey")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Api.Domain.Entities.Unit", "Unit")
                        .WithMany("UnitCourses")
                        .HasForeignKey("UnitKey")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("Api.Domain.Entities.Room", b =>
                {
                    b.HasOne("Api.Domain.Entities.Building", "Building")
                        .WithMany("Rooms")
                        .HasForeignKey("BuildingKey")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Building");
                });

            modelBuilder.Entity("Api.Domain.Entities.RoomProperty", b =>
                {
                    b.HasOne("Api.Domain.Entities.Property", "Property")
                        .WithMany("PropertyRooms")
                        .HasForeignKey("PropertyKey")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Api.Domain.Entities.Room", "Room")
                        .WithMany("RoomProperties")
                        .HasForeignKey("RoomKey")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Property");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Api.Domain.Entities.Session", b =>
                {
                    b.HasOne("Api.Domain.Entities.Property", "Property")
                        .WithMany("Sessions")
                        .HasForeignKey("PropertyKey")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Api.Domain.Entities.Shift", "Shift")
                        .WithMany("Sessions")
                        .HasForeignKey("ShiftKey")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Property");

                    b.Navigation("Shift");
                });

            modelBuilder.Entity("Api.Domain.Entities.Shift", b =>
                {
                    b.HasOne("Api.Domain.Entities.Unit", "Unit")
                        .WithMany("Shifts")
                        .HasForeignKey("UnitKey")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("Api.Domain.Entities.Slot", b =>
                {
                    b.HasOne("Api.Domain.Entities.Room", "Room")
                        .WithMany("Slots")
                        .HasForeignKey("RoomKey")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Api.Domain.Entities.Session", "Session")
                        .WithMany("Slots")
                        .HasForeignKey("SessionKey")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Room");

                    b.Navigation("Session");
                });

            modelBuilder.Entity("Api.Domain.Entities.Building", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("Api.Domain.Entities.Class", b =>
                {
                    b.Navigation("ClassShifts");
                });

            modelBuilder.Entity("Api.Domain.Entities.Course", b =>
                {
                    b.Navigation("CourseUnits");
                });

            modelBuilder.Entity("Api.Domain.Entities.Property", b =>
                {
                    b.Navigation("PropertyRooms");

                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("Api.Domain.Entities.Room", b =>
                {
                    b.Navigation("RoomProperties");

                    b.Navigation("Slots");
                });

            modelBuilder.Entity("Api.Domain.Entities.Session", b =>
                {
                    b.Navigation("Slots");
                });

            modelBuilder.Entity("Api.Domain.Entities.Shift", b =>
                {
                    b.Navigation("Sessions");

                    b.Navigation("ShiftClasses");
                });

            modelBuilder.Entity("Api.Domain.Entities.Unit", b =>
                {
                    b.Navigation("Shifts");

                    b.Navigation("UnitCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
