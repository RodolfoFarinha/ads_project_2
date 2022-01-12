import { Injectable } from '@angular/core';
import { QualitySchedule } from 'src/app/models/entities/QualitySchedule';

@Injectable({
  providedIn: 'root'
})
export class SharedQualityScheduleService {

  globalQualitySchedule: QualitySchedule[] | undefined;

  constructor() { }

  setGlobalQualitySchedule(newQualitySchedule: QualitySchedule[]) {
    this.globalQualitySchedule = newQualitySchedule;
  }

  getGlobalQualitySchedule(): QualitySchedule[] | undefined {
    return this.globalQualitySchedule;
  }
}
