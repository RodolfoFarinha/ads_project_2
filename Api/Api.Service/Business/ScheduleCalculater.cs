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
                RoomViewModel generatedRoom = GetAvailableRoom(rooms, session, overBookingPercent);

                if (generatedRoom != null)
                {
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
                    qualitySchedule.TotalRoomsWithoutSession++;

                    if (session.Shift.Unit.UnitCourses.Where(x => x.Course.CourseType == CourseEnum.Master).Any())                   
                        qualitySchedule.TotalRoomsWithoutSessionMasters++; 
                    
                    else
                        qualitySchedule.TotalRoomsWithoutSessionDegrees++;
                    
                    if(session.Shift.ShiftType == ShiftEnum.Work)
                        qualitySchedule.TotalRoomsWithoutSessionWork++;
                    
                    else
                        qualitySchedule.TotalRoomsWithoutSessionAfterWork++;      
                }
            }

            qualitySchedule.TimeExecution = DateTime.Now.Subtract(exectutionStart);

            return sessions;
        }

        /// <summary>
        /// Get available room based in date
        /// </summary>
        public static RoomViewModel GetAvailableRoom(IEnumerable<RoomViewModel> rooms, SessionViewModel session, decimal overBookingPercent)
        {
            foreach (RoomViewModel room in rooms)
                if (!room.Slots.Where(x => x.StartDate > session.StartDate && x.EndDate < session.EndDate).Any() &&
                    room.RoomProperties.Where(x => x.Property.PropertyKey == session.PropertyKey).Any() &&
                    (room.NormalCapacity * (1 + overBookingPercent / 100)) >= session.Shift.EnrolledStudents)
                    return room;

            return null;
        }
    }
}