import { Guid } from 'guid-typescript';
import { ClassShift } from './ClassShift';
import { Session } from './Session';
import { Unit } from './Unit';

export interface Shift {
  scheduleKey: Guid,
  scheduleVersion: number,
  shiftKey: Guid,
  unitKey: Guid,
  unit: Unit,
  shiftName: string,
  shiftType: number,
  enrolledStudents: number,
  shiftClasses: ClassShift[],
  sessions: Session[],
}

