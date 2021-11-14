import { Guid } from "guid-typescript";
import { Time } from "@angular/common";
import { SessionBasicInfo } from "./SessionBasicInfo";

export interface QualitySchedule {
  scheduleKey: Guid,
  scheduleVersion: number,
  timeExecution: Time,
  totalRoomsWithoutSession: number,
  totalRoomsWithoutSessionMasters: number,
  totalRoomsWithoutSessionDegrees: number,
  totalRoomsWithoutSessionWork: number,
  totalRoomsWithoutSessionAfterWor: number,
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
  basicSessions: SessionBasicInfo[]
}

