import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from 'src/environments/environment';

import { Guid } from 'guid-typescript';
import { Slot } from './../../models/Slot';

@Injectable({
  providedIn: 'root'
})
export class SlotService {

  controller = `${environment.apiUrl}` + 'slot';

  constructor(private http: HttpClient) { }

  getAll(): Observable<Slot[]> {
    return this.http.get<Slot[]>(this.controller);
  }

  getByKey(key): Observable<Slot> {
    return this.http.get<Slot>(`${this.controller}/${key}`);
  }

  post(Slot: Slot) {
    return this.http.post(this.controller, Slot);
  }

  put(Slot: Slot) {
    return this.http.put(`${this.controller}/${Slot.slotKey}`, Slot);
  }

  delete(key: Guid) {
    return this.http.delete(`${this.controller}/${key}`);
  }
}
