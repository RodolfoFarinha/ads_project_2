import { Guid } from 'guid-typescript';
import { Time } from '@angular/common';
import { Shift } from './Shift';
import { Slot } from './Slot';
import { Property } from './Property';

export interface Session {
  scheduleKey: Guid,
  scheduleVersion: number,
  sessionKey: Guid,
  shiftKey: Guid,
  shift: Shift,
  propertyKey: Guid,
  property: Property,
  startDate: Date,
  endDate: Date,
  timeLength: Time,
  timeSlot: Time,
  sessionIsCompleted: boolean,
  slots: Slot[]
}
