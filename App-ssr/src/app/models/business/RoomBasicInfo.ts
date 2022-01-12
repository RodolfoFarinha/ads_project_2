import { Guid } from "guid-typescript";

export interface RoomBasicInfo {
  roomKey: Guid,
  roomName: string,
  roomCapacity: number,
  buildingKey: Guid,
  buildingName: string,
  totalHoursAllocated: number,
  allocationPercentage: number
}
