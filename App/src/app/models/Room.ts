import { Guid } from 'guid-typescript';
import { Building } from './Building';
import { RoomProperty } from './RoomProperty';
import { Slot } from "./Slot";

export interface Room {
  scheduleKey: Guid,
  scheduleVersion: number,
  roomKey: Guid,
  buildingKey: Guid,
  building: Building,
  roomName: string,
  normalCapacity: number,
  examCapacity: number,
  roomProperties: RoomProperty[],
  slots: Slot[]
}
