import { EventCalendar } from './../../models/business/EventCalendar';
import { Component, OnInit } from '@angular/core';

import { SharedQualityScheduleService } from 'src/app/util/shared-quality-schedule/SharedQualitySchedule.service';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent implements OnInit {

  events: EventCalendar[] | undefined;

  constructor(private sharedQualityScheduleService: SharedQualityScheduleService) { }

  ngOnInit() {
    this.sharedQualityScheduleService.getGlobalQualitySchedule()?.eventsCalendar.forEach(eventCalendar => {
      console.log(eventCalendar)
      });

    this.events = this.sharedQualityScheduleService.getGlobalQualitySchedule()?.eventsCalendar;
    console.log(this.sharedQualityScheduleService.getGlobalQualitySchedule()?.eventsCalendar)
    console.log(this.events)
  }
}
