import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from 'src/environments/environment';

import { Guid } from 'guid-typescript';
import { QualitySchedule } from './../../models/QualitySchedule';

@Injectable({
  providedIn: 'root'
})
export class QualityScheduleService {

  controller = `${environment.apiUrl}` + 'qualityschedule';

  constructor(private http: HttpClient) { }

  getAll(): Observable<QualitySchedule[]> {
    return this.http.get<QualitySchedule[]>(this.controller);
  }

  getByKey(key): Observable<QualitySchedule> {
    return this.http.get<QualitySchedule>(`${this.controller}/${key}`);
  }

  post(QualitySchedule: QualitySchedule) {
    return this.http.post(this.controller, QualitySchedule);
  }

  put(QualitySchedule: QualitySchedule) {
    return this.http.put(`${this.controller}/${QualitySchedule.scheduleKey}`, QualitySchedule);
  }

  delete(key: Guid) {
    return this.http.delete(`${this.controller}/${key}`);
  }
}
