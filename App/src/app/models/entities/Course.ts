import { Guid } from 'guid-typescript';
import { CourseUnit } from './CourseUnit';

export interface Course {
  scheduleKey: Guid,
  scheduleVersion: number,
  courseKey: Guid,
  courseName: string,
  type: number,
  courseUnits: CourseUnit[]
}

