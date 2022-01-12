import { Guid } from 'guid-typescript';
import { Property } from './Property';
import { Room } from './Room';

export interface RoomProperty {
  roomPropertyKey: Guid,
  roomKey: Guid,
  room: Room,
  propertyKey: Guid,
  property: Property,
}

