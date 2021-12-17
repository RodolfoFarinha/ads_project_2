import { Guid } from "guid-typescript";
import { Time } from "@angular/common";
import { EventCalendar } from '../business/EventCalendar';
import { ScheduleType } from "src/app/util/enums/ScheduleType.enum";

export interface QualitySchedule {
  scheduleKey: Guid,
  scheduleVersion: number,
  timeExecution: Time,
  scheduleType: ScheduleType,
  totalRoomsWithoutSession: number,
  totalRoomsWithoutSessionMasters: number,
  totalRoomsWithoutSessionDegrees: number,
  totalRoomsWithoutSessionWork: number,
  totalRoomsWithoutSessionAfterWork: number,
  totalRoomChangeInSessions: number,
  totalRoomChangeInSessionsMasters: number,
  totalRoomChangeInSessionsDegrees: number,
  totalRoomChangeInSessionsWork: number,
  totalRoomChangeInSessionsAfterWork: number,
  totalRoomChangeBetweenSessions: number,
  totalRoomChangeBetweenSessionsMasters: number,
  totalRoomChangeBetweenSessionsDegrees: number,
  totalRoomChangeBetweenSessionsWork: number,
  totalRoomChangeBetweenSessionsAfterWork: number,
  totalRoomChangeInShifts: number,
  totalRoomChangeInShiftsMasters: number,
  totalRoomChangeInShiftsDegrees: number,
  totalRoomChangeInShiftsWork: number,
  totalRoomChangeInShiftsAfterWork: number,
  avarageGapBetweenSessionsByShift: number,
  eventsCalendar: EventCalendar[]
}

