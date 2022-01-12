import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from 'src/environments/environment';

import { Guid } from 'guid-typescript';
import { Unit } from './../../models/entities/Unit';

@Injectable({
  providedIn: 'root'
})
export class UnitService {

  controller = `${environment.apiUrl}` + 'unit';

  constructor(private http: HttpClient) { }

  getAll(): Observable<Unit[]> {
    return this.http.get<Unit[]>(this.controller);
  }

  getByKey(key: any): Observable<Unit> {
    return this.http.get<Unit>(`${this.controller}/${key}`);
  }

  post(Unit: Unit) {
    return this.http.post(this.controller, Unit);
  }

  put(Unit: Unit) {
    return this.http.put(`${this.controller}/${Unit.unitKey}`, Unit);
  }

  delete(key: Guid) {
    return this.http.delete(`${this.controller}/${key}`);
  }
}
