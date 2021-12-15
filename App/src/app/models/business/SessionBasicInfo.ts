import { Guid } from 'guid-typescript';

export interface SessionBasicInfo {
  scheduleKey: Guid,
  scheduleVersion: number,
  sessionKey: Guid,
  shiftKey: Guid,
  shiftName: string,
  propertyKey: Guid,
  propertyName: string,
  buildingKey: Guid,
  buildingName: string,
  roomKey: Guid,
  roomName: string,
  unitKey: Guid,
  unitName: string,
  startDate: Date,
  endDate: Date
}

