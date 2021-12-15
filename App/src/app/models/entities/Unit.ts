import { Guid } from 'guid-typescript';
import { CourseUnit } from './CourseUnit';
import { Shift } from './Shift';

export interface Unit {
  scheduleKey: Guid,
  scheduleVersion: number,
  unitKey: Guid,
  unitName: string,
  unitCourses: CourseUnit[],
  shifts: Shift[],
}

