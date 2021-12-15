import { Guid } from 'guid-typescript';
import { EventColor } from './EventColor';
import { Resizable } from './Resizable';
import { SessionBasicInfo } from './SessionBasicInfo';

export interface EventCalendar {
  scheduleKey: Guid,
  scheduleVersion: number,
  title: string,
  totalSessionsWithoutRoom: number,
  start: Date,
  end: Date,
  color: EventColor,
  resizable: Resizable
  draggable: boolean,
  sessionsBasicInfo: SessionBasicInfo[]
}

