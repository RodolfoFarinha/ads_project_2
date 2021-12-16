import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from 'src/environments/environment';

import { QualitySchedule } from '../../models/entities/QualitySchedule';

@Injectable({
  providedIn: 'root'
})
export class ScheduleCalculatorService {

  controller = `${environment.apiUrl}` + 'schedulecalculator';

  constructor(private http: HttpClient) { }

  ScheduleCalculator(propertiesCsv: File | undefined, roomsCsv: File | undefined, sessionsCsv: File | undefined): Observable<QualitySchedule> {
    const propertiesCsvToPost = propertiesCsv as File;
    const roomsCsvToPost = roomsCsv as File;
    const sessionsCsvToPost = sessionsCsv as File;

    const formData = new FormData();

    if (propertiesCsvToPost !== undefined) {
      formData.append('file', propertiesCsvToPost, "properties.csv");
    }

    if (roomsCsvToPost !== undefined) {
      formData.append('file', roomsCsvToPost, "rooms.csv");
    }

    if (sessionsCsvToPost !== undefined) {
      formData.append('file', sessionsCsvToPost, "sessions.csv");
    }

    return this.http.post<QualitySchedule>(`${this.controller}`, formData);
  }
}
