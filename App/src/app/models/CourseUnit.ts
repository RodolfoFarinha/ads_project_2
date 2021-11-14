import { Guid } from 'guid-typescript';
import { Unit } from './Unit';
import { Course } from './Course';

export interface CourseUnit {
  courseUnitKey: Guid,
  courseKey: Guid,
  course: Course,
  unitKey: Guid,
  unit: Unit
}

