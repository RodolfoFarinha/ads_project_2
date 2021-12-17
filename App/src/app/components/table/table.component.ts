import { EventCalendar } from './../../models/business/EventCalendar';
import { Component, OnInit } from '@angular/core';

import { SharedQualityScheduleService } from 'src/app/util/shared-quality-schedule/SharedQualitySchedule.service';
import { ScheduleType } from 'src/app/util/enums/ScheduleType.enum';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent implements OnInit {

  algoritm: ScheduleType = ScheduleType.Normal;
  stateOptions: any[] = [];

  events: EventCalendar[] | undefined;
  eventsNormal: EventCalendar[] | undefined;
  eventsOverBooking25: EventCalendar[] | undefined;

  constructor(private sharedQualityScheduleService: SharedQualityScheduleService) { }

  ngOnInit() {
    this.stateOptions = [{ label: 'Normal', value: 0 }, { label: 'Over Booking 25%', value: 1 }];

    this.sharedQualityScheduleService.getGlobalQualitySchedule()?.forEach(qualitySchedule => {
      if (qualitySchedule.scheduleType == ScheduleType.Normal) {
        this.eventsNormal = qualitySchedule.eventsCalendar;
        this.eventsNormal = this.eventsNormal?.sort((x, y) => x.start < y.end ? -1 : 1);
      }
      else {
        this.eventsOverBooking25 = qualitySchedule.eventsCalendar;
        this.eventsOverBooking25 = this.eventsOverBooking25?.sort((x, y) => x.start < y.end ? -1 : 1);
      }
    });

    this.events = this.eventsNormal;
  }

  changeAlgoritm() {
    if (this.algoritm == ScheduleType.Normal){
      this.algoritm = ScheduleType.OverBooking25;
      this.events = this.eventsOverBooking25;
    }
    else
    {
      this.algoritm = ScheduleType.Normal
      this.events = this.eventsNormal;
    }
  }
}
