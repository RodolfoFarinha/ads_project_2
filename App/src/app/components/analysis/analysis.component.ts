import { Component, OnInit } from '@angular/core';
import { ScheduleType } from 'src/app/util/enums/ScheduleType.enum';
import { SharedQualityScheduleService } from 'src/app/util/shared-quality-schedule/SharedQualitySchedule.service';

@Component({
  selector: 'app-analysis',
  templateUrl: './analysis.component.html',
  styleUrls: ['./analysis.component.css']
})
export class AnalysisComponent implements OnInit {

  totalNormal: number = 0;
  degreesNormal: number = 0;
  mastersNormal: number = 0;
  workNormal: number = 0;
  afterWorkNormal: number = 0;

  totalOverBooking25: number = 0;
  degreesOverBooking25: number = 0;
  mastersOverBooking25: number = 0;
  workOverBooking25: number = 0;
  afterWorkOverBooking25: number = 0;

  data: any;
  options: any;

  constructor(private sharedQualityScheduleService: SharedQualityScheduleService) { }

  ngOnInit(): void {



    this.sharedQualityScheduleService.getGlobalQualitySchedule()?.forEach(qualitySchedule => {
      if (qualitySchedule.scheduleType == ScheduleType.Normal) {
        this.totalNormal = qualitySchedule.totalRoomsWithoutSession;
        this.degreesNormal = qualitySchedule.totalRoomsWithoutSessionDegrees;
        this.mastersNormal = qualitySchedule.totalRoomsWithoutSessionMasters;
        this.workNormal = qualitySchedule.totalRoomsWithoutSessionWork;
        this.afterWorkNormal = qualitySchedule.totalRoomsWithoutSessionAfterWork;
      }
      else {
        this.totalOverBooking25 = qualitySchedule.totalRoomsWithoutSession;
        this.degreesOverBooking25 = qualitySchedule.totalRoomsWithoutSessionDegrees;
        this.mastersOverBooking25 = qualitySchedule.totalRoomsWithoutSessionMasters;
        this.workOverBooking25 = qualitySchedule.totalRoomsWithoutSessionWork;
        this.afterWorkOverBooking25 = qualitySchedule.totalRoomsWithoutSessionAfterWork;
      }
    });

    this.options = {
      plugins: {
        legend: {
          labels: {
            color: '#171a1c'
          }
        }
      },
      scales: {
        x: {
          ticks: {
            color: '#171a1c'
          },
          grid: {
            color: 'rgba(0,0,0,0.1)'
          }
        },
        y: {
          ticks: {
            color: '#171a1c'
          },
          grid: {
            color: 'rgba(0,0,0,0.1)'
          }
        }
      }
    };

    this.data = {
      labels: ['Total', 'Licenciaturas', 'Mestrados', 'Laboral', 'Pós-Laboral'],
      datasets: [
        {
          label: 'Normal',
          backgroundColor: '#42A5F5',
          data: [this.totalNormal, this.degreesNormal, this.mastersNormal, this.workNormal, this.afterWorkNormal]
        },
        {
          label: 'Over Booking 25%',
          backgroundColor: '#FFA726',
          data: [this.totalOverBooking25, this.degreesOverBooking25, this.mastersOverBooking25, this.workOverBooking25, this.afterWorkOverBooking25]
        }
      ]
    };
  }

}
