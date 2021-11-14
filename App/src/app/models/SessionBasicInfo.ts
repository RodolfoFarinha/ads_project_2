import { Guid } from 'guid-typescript';

export interface SessionBasicInfo {
  scheduleKey: Guid,
  scheduleVersion: number,
  sessionKey: Guid,
  shiftKey: Guid,
  propertyKey: Guid,
  buildingKey: Guid,
  buildingName: string,
  roomKey: Guid,
  roomName: string,
  title: string,
  start: Date,
  end: Date
}

