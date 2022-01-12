import { Guid } from 'guid-typescript';

export interface SessionBasicInfo {
  scheduleKey: Guid,
  scheduleVersion: number,
  sessionKey: Guid,
  shiftKey: Guid,
  shiftName: string,
  classKey: Guid,
  className: string,
  propertyKey: Guid,
  propertyName: string,
  buildingKey: Guid,
  buildingName: string,
  roomKey: Guid,
  roomName: string,
  roomCapacity: number,
  unitKey: Guid,
  unitName: string,
  startDate: Date,
  endDate: Date
  courseKey: Guid,
  courseName: string,
  enrollments: number
}

