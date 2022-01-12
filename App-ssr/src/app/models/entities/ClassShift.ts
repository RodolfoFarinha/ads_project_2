import { Guid } from 'guid-typescript';
import { Shift } from './Shift';
import { Class } from './Class';

export interface ClassShift {
  classShiftKey: Guid,
  classKey: Guid,
  class: Class,
  shiftKey: Guid,
  shift: Shift
}

