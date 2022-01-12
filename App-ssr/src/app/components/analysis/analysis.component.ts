import { RoomBasicInfo } from './../../models/business/RoomBasicInfo';
import { Component, OnInit } from '@angular/core';
import { QualitySchedule } from 'src/app/models/entities/QualitySchedule';
import { SharedQualityScheduleService } from 'src/app/util/shared-quality-schedule/SharedQualitySchedule.service';
import { ScheduleType } from 'src/app/util/enums/ScheduleType.enum';

@Component({
  selector: 'app-analysis',
  templateUrl: './analysis.component.html',
  styleUrls: ['./analysis.component.css']
})
export class AnalysisComponent implements OnInit {

  qualitySchedules: QualitySchedule[] = [];

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

  totalRoomCloseCapacity: number = 0;
  degreesRoomCloseCapacity: number = 0;
  mastersRoomCloseCapacity: number = 0;
  workRoomCloseCapacity: number = 0;
  afterWorkRoomCloseCapacity: number = 0;

  totalRandomOrder: number = 0;
  degreesRandomOrder: number = 0;
  mastersRandomOrder: number = 0;
  workRandomOrder: number = 0;
  afterWorkRandomOrder: number = 0;

  totalAllVariables: number = 0;
  degreesAllVariables: number = 0;
  mastersAllVariables: number = 0;
  workAllVariables: number = 0;
  afterWorkAllVariables: number = 0;

  qualitySchedule: QualitySchedule;

  scheduleTypesEnum = ScheduleType;
  scheduleTypes: string[];

  data: any;
  options: any;

  constructor(private sharedQualityScheduleService: SharedQualityScheduleService) { }

  ngOnInit(): void {
    this.scheduleTypes = Object.keys(this.scheduleTypesEnum);

    this.sharedQualityScheduleService.getGlobalQualitySchedule()?.forEach(qualitySchedule => {

      this.qualitySchedules.push(qualitySchedule);

      switch (qualitySchedule.scheduleType.toString()) {
        case '0':
          this.qualitySchedule = qualitySchedule;
          this.qualitySchedules.find(x => x.scheduleType.toString() === '0').scheduleTypeString = "Normal";
          this.totalNormal = qualitySchedule.totalRoomsWithoutSession;
          this.degreesNormal = qualitySchedule.totalRoomsWithoutSessionDegrees;
          this.mastersNormal = qualitySchedule.totalRoomsWithoutSessionMasters;
          this.workNormal = qualitySchedule.totalRoomsWithoutSessionWork;
          this.afterWorkNormal = qualitySchedule.totalRoomsWithoutSessionAfterWork;
          break;
        case '1':
          this.qualitySchedules.find(x => x.scheduleType.toString() === '1').scheduleTypeString = "Over Booking 25%";
          this.totalOverBooking25 = qualitySchedule.totalRoomsWithoutSession;
          this.degreesOverBooking25 = qualitySchedule.totalRoomsWithoutSessionDegrees;
          this.mastersOverBooking25 = qualitySchedule.totalRoomsWithoutSessionMasters;
          this.workOverBooking25 = qualitySchedule.totalRoomsWithoutSessionWork;
          this.afterWorkOverBooking25 = qualitySchedule.totalRoomsWithoutSessionAfterWork;
          break;
        case '2':
          this.qualitySchedules.find(x => x.scheduleType.toString() === '2').scheduleTypeString = "Capacidade Aproximada";
          this.totalRoomCloseCapacity = qualitySchedule.totalRoomsWithoutSession;
          this.degreesRoomCloseCapacity = qualitySchedule.totalRoomsWithoutSessionDegrees;
          this.mastersRoomCloseCapacity = qualitySchedule.totalRoomsWithoutSessionMasters;
          this.workRoomCloseCapacity = qualitySchedule.totalRoomsWithoutSessionWork;
          this.afterWorkRoomCloseCapacity = qualitySchedule.totalRoomsWithoutSessionAfterWork;
          break;
        case '3':
          this.qualitySchedules.find(x => x.scheduleType.toString() === '3').scheduleTypeString = "Ordem Aleatória";
          this.totalRandomOrder = qualitySchedule.totalRoomsWithoutSession;
          this.degreesRandomOrder = qualitySchedule.totalRoomsWithoutSessionDegrees;
          this.mastersRandomOrder = qualitySchedule.totalRoomsWithoutSessionMasters;
          this.workRandomOrder = qualitySchedule.totalRoomsWithoutSessionWork;
          this.afterWorkRandomOrder = qualitySchedule.totalRoomsWithoutSessionAfterWork;
          break;
        case '4':
          this.qualitySchedules.find(x => x.scheduleType.toString() === '4').scheduleTypeString = "Todas as Variáveis";
          this.totalAllVariables = qualitySchedule.totalRoomsWithoutSession;
          this.degreesAllVariables = qualitySchedule.totalRoomsWithoutSessionDegrees;
          this.mastersAllVariables = qualitySchedule.totalRoomsWithoutSessionMasters;
          this.workAllVariables = qualitySchedule.totalRoomsWithoutSessionWork;
          this.afterWorkAllVariables = qualitySchedule.totalRoomsWithoutSessionAfterWork;
          break;
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
          backgroundColor: '#1e90ff',
          data: [this.totalNormal, this.degreesNormal, this.mastersNormal, this.workNormal, this.afterWorkNormal]
        },
        {
          label: 'Over Booking 25%',
          backgroundColor: '#e3bc08',
          data: [this.totalOverBooking25, this.degreesOverBooking25, this.mastersOverBooking25, this.workOverBooking25, this.afterWorkOverBooking25]
        },
        {
          label: 'Capacidade Aproximada',
          backgroundColor: '#63DA63',
          data: [this.totalOverBooking25, this.degreesOverBooking25, this.mastersOverBooking25, this.workOverBooking25, this.afterWorkOverBooking25]
        },
        {
          label: 'Ordem Aleatória',
          backgroundColor: '#E373DF',
          data: [this.totalOverBooking25, this.degreesOverBooking25, this.mastersOverBooking25, this.workOverBooking25, this.afterWorkOverBooking25]
        },
        {
          label: 'Todas as Variáveis',
          backgroundColor: '#ad2121',
          data: [this.totalOverBooking25, this.degreesOverBooking25, this.mastersOverBooking25, this.workOverBooking25, this.afterWorkOverBooking25]
        }
      ]
    };
  }

  changeAlgorithm(event) {
    switch (event) {
      case "Normal":
        this.qualitySchedule = this.qualitySchedules.find(x => x.scheduleType.toString() === '0');
        break;
      case "OverBooking25":
        this.qualitySchedule = this.qualitySchedules.find(x => x.scheduleType.toString() === '1');
        break;
      case "RoomCloseCapacity":
        this.qualitySchedule = this.qualitySchedules.find(x => x.scheduleType.toString() === '2');
        break;
      case "RandomOrder":
        this.qualitySchedule = this.qualitySchedules.find(x => x.scheduleType.toString() === '3');
        break;
      case "AllVariables":
        this.qualitySchedule = this.qualitySchedules.find(x => x.scheduleType.toString() === '4');
        break;
    }
  }
}
