import { Guid } from 'guid-typescript';
import { Room } from './Room';
import { Session } from './Session';

export interface Slot {
  scheduleKey: Guid,
  scheduleVersion: number,
  slotKey: Guid,
  sessionKey: Guid,
  session: Session,
  roomKey: Guid,
  room: Room,
  startDate: Date,
  endDate: Date
}

