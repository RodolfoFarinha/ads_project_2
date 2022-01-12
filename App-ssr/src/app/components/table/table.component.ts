import { Component, OnInit } from '@angular/core';

import { SharedQualityScheduleService } from 'src/app/util/shared-quality-schedule/SharedQualitySchedule.service';

import { QualitySchedule } from './../../models/entities/QualitySchedule';
import { EventCalendar } from './../../models/business/EventCalendar';

import { ScheduleType } from 'src/app/util/enums/ScheduleType.enum';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent implements OnInit {

  scheduleTypesEnum = ScheduleType;
  scheduleTypes: string[];

  events: EventCalendar[];
  eventsNormal: EventCalendar[];
  eventsOverBooking25: EventCalendar[];
  roomCloseCapacity: EventCalendar[];
  randomOrder: EventCalendar[];
  allVariables: EventCalendar[];

  qualitySchedules: QualitySchedule[] = [];

  constructor(private sharedQualityScheduleService: SharedQualityScheduleService) { }

  ngOnInit() {
    this.scheduleTypes = Object.keys(this.scheduleTypesEnum);

    this.sharedQualityScheduleService.getGlobalQualitySchedule()?.forEach(qualitySchedule => {

      this.qualitySchedules.push(qualitySchedule);

      switch (qualitySchedule.scheduleType.toString()) {
        case '0':
          this.eventsNormal = qualitySchedule.eventsCalendar;
          this.eventsNormal = this.eventsNormal?.sort((x, y) => x.start < y.end ? -1 : 1);
          break;
        case '1':
          this.eventsOverBooking25 = qualitySchedule.eventsCalendar;
          this.eventsOverBooking25 = this.eventsOverBooking25?.sort((x, y) => x.start < y.end ? -1 : 1);
          break;
        case '2':
          this.roomCloseCapacity = qualitySchedule.eventsCalendar;
          this.roomCloseCapacity = this.roomCloseCapacity?.sort((x, y) => x.start < y.end ? -1 : 1);
          break;
        case '3':
          this.randomOrder = qualitySchedule.eventsCalendar;
          this.randomOrder = this.randomOrder?.sort((x, y) => x.start < y.end ? -1 : 1);
          break;
        case '4':
          this.allVariables = qualitySchedule.eventsCalendar;
          this.allVariables = this.allVariables?.sort((x, y) => x.start < y.end ? -1 : 1);
          break;
      }
    });

    this.events = this.eventsNormal;
  }

  changeAlgorithm(event) {
    switch (event) {
      case "Normal":
        this.events = this.eventsNormal;
        break;
      case "OverBooking25":
        this.events = this.eventsOverBooking25;
        break;
      case "RoomCloseCapacity":
        this.events = this.roomCloseCapacity;
        break;
      case "RandomOrder":
        this.events = this.randomOrder;
        break;
      case "AllVariables":
        this.events = this.allVariables;
        break;
    }
  }
}
