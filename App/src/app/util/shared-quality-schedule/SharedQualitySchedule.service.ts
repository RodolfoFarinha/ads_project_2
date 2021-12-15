import { Injectable } from '@angular/core';
import { QualitySchedule } from 'src/app/models/entities/QualitySchedule';

@Injectable({
  providedIn: 'root'
})
export class SharedQualityScheduleService {

  globalQualitySchedule: QualitySchedule;

  constructor() { }

  setGlobalQualitySchedule(newQualitySchedule: QualitySchedule) {
    this.globalQualitySchedule = newQualitySchedule;
  }

  getGlobalQualitySchedule(): QualitySchedule {
    return this.globalQualitySchedule;
  }
}
