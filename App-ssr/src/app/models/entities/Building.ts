import { Guid } from 'guid-typescript';
import { Room } from './Room';

export interface Building {
  scheduleKey: Guid,
  scheduleVersion: number,
  buildingKey: Guid,
  buildingName: string,
  rooms: Room[]
}

