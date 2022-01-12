import { Guid } from 'guid-typescript';
import { Session } from './Session';
import { RoomProperty } from './RoomProperty';

export interface Property {
  propertyKey: Guid,
  propertyName: string,
  propertyDescription: string,
  propertyStatus: number,
  availableManagement: boolean,
  availableRequest: boolean,
  propertyRooms: RoomProperty[],
  sessions: Session[]
}

