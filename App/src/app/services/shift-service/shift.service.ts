import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from 'src/environments/environment';

import { Guid } from 'guid-typescript';
import { Shift } from './../../models/Shift';

@Injectable({
  providedIn: 'root'
})
export class ShiftService {

  controller = `${environment.apiUrl}` + 'shift';

  constructor(private http: HttpClient) { }

  getAll(): Observable<Shift[]> {
    return this.http.get<Shift[]>(this.controller);
  }

  getByKey(key): Observable<Shift> {
    return this.http.get<Shift>(`${this.controller}/${key}`);
  }

  post(Shift: Shift) {
    return this.http.post(this.controller, Shift);
  }

  put(Shift: Shift) {
    return this.http.put(`${this.controller}/${Shift.shiftKey}`, Shift);
  }

  delete(key: Guid) {
    return this.http.delete(`${this.controller}/${key}`);
  }
}
