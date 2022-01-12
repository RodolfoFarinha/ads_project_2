using Api.Domain.Enum;
using Api.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.Service.Business
{
    /// <summary>
    /// 
    /// </summary>
    public static class ScheduleCalculater
    {
        /// <summary>
        /// Generate calendar based on sessions and rooms 
        /// </summary>
        public static List<SessionViewModel> CreateSessionSlots(QualityScheduleViewModel qualitySchedule, List<SessionViewModel> sessions, List<RoomViewModel> rooms, decimal overBookingPercent)
        {
            DateTime exectutionStart = DateTime.Now;

            //recebo um conjunto de sessions e um conjunto de rooms
            // com base no start date e no end date
            // aceder a slot -> room
            foreach (SessionViewModel session in sessions)
            {
                RoomViewModel generatedRoom = GetAvailableRoom(qualitySchedule, rooms, session, overBookingPercent);

                if (generatedRoom != null)
                {
                    qualitySchedule.TotalRoomsHours += session.TimeLength.TotalHours;

                    if(!qualitySchedule.RoomsBasicInfo.Where(x => x.RoomKey == generatedRoom.RoomKey).Any())
                    {
                        qualitySchedule.RoomsBasicInfo.Add(
                            new RoomBasicInfoViewModel
                            {
                                RoomKey = generatedRoom.RoomKey,
                                RoomName = generatedRoom.RoomName,
                                RoomCapacity = generatedRoom.NormalCapacity,
                                BuildingKey = generatedRoom.BuildingKey,
                                BuildingName = generatedRoom.Building.BuildingName,
                                TotalHoursAllocated = session.TimeLength.TotalHours,
                                AllocationPercentage = session.TimeLength.TotalHours / qualitySchedule.TotalRoomsHours * 100
                            });
                    }
                    else
                    {
                        qualitySchedule.RoomsBasicInfo.FirstOrDefault(x => x.RoomKey == generatedRoom.RoomKey).TotalHoursAllocated
                            += session.TimeLength.TotalHours;

                        qualitySchedule.RoomsBasicInfo.FirstOrDefault(x => x.RoomKey == generatedRoom.RoomKey).AllocationPercentage
                             = qualitySchedule.RoomsBasicInfo.FirstOrDefault(x => x.RoomKey == generatedRoom.RoomKey).TotalHoursAllocated
                             / qualitySchedule.TotalRoomsHours * 100;
                    }

                    SlotViewModel slot = new SlotViewModel()
                    {
                        SlotKey = Guid.NewGuid(),
                        SessionKey = session.SessionKey,
                        Session = session,
                        RoomKey = generatedRoom.RoomKey,
                        Room = generatedRoom,
                        StartDate = session.StartDate,
                        EndDate = session.EndDate
                    };
                    
                    session.Slots.Add(slot);
                }
                else
                {
                    if (session.Shift.EnrolledStudents >= 5)
                    {
                        qualitySchedule.TotalRoomsWithoutSession++;

                        if (session.Shift.Unit.UnitCourses.Where(x => x.Course.CourseType == CourseEnum.Master).Any())
                            qualitySchedule.TotalRoomsWithoutSessionMasters++;
                        else
                            qualitySchedule.TotalRoomsWithoutSessionDegrees++;

                        if (session.Shift.ShiftType == ShiftEnum.Work)
                            qualitySchedule.TotalRoomsWithoutSessionWork++;
                        else
                            qualitySchedule.TotalRoomsWithoutSessionAfterWork++;
                    } 
                }
            }

            qualitySchedule.TimeExecution = DateTime.Now.Subtract(exectutionStart);

            return sessions;
        }

        /// <summary>
        /// Get available room based in date
        /// </summary>
        public static RoomViewModel GetAvailableRoom(QualityScheduleViewModel qualitySchedule, IEnumerable<RoomViewModel> rooms, SessionViewModel session, decimal overBookingPercent)
        {

            if (session.Shift.EnrolledStudents < 5)
                return null;

            RoomViewModel roomResult = null;
            decimal enrolledStudents = session.Shift.EnrolledStudents * (1 - overBookingPercent / 100);

            if (qualitySchedule.ScheduleType == ScheduleTypeEnum.RandomOrder || qualitySchedule.ScheduleType == ScheduleTypeEnum.AllVariables)
            {
                Random rnd = new Random();
                rooms = rooms.OrderBy((item) => rnd.Next());
            }

            foreach (RoomViewModel room in rooms)
            {
                if (
                    !room.Slots.Where(x => x.StartDate > session.StartDate && x.EndDate < session.EndDate).Any() &&
                    room.RoomProperties.Where(x => x.Property.PropertyKey == session.PropertyKey).Any() &&
                    room.NormalCapacity >= enrolledStudents
                    )
                {
                    if(room.RoomProperties.FirstOrDefault(x => x.PropertyKey == session.PropertyKey).Property.AvailableManagement)
                    {
                        if (qualitySchedule.ScheduleType == ScheduleTypeEnum.RoomCloseCapacity || qualitySchedule.ScheduleType == ScheduleTypeEnum.AllVariables)
                        {
                            if (roomResult == null || roomResult.NormalCapacity - enrolledStudents > room.NormalCapacity - enrolledStudents)
                                roomResult = room;
                        }
                        else
                        {
                            return room;
                        }
                    } 
                }
            }

            return roomResult;
        }
    }
}