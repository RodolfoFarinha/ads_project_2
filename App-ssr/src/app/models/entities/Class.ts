import { Guid } from "guid-typescript";
import { ClassShift } from './ClassShift';

export interface Class {
  scheduleKey: Guid,
  scheduleVersion: number,
  classKey: Guid,
  className: string,
  classShifts: ClassShift[]
}
