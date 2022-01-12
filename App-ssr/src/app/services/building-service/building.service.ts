import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from 'src/environments/environment';

import { Guid } from 'guid-typescript';
import { Building } from '../../models/entities/Building';

@Injectable({
  providedIn: 'root'
})
export class BuildingService {

  controller = `${environment.apiUrl}` + 'building';

  constructor(private http: HttpClient) { }

  getAll(): Observable<Building[]> {
    return this.http.get<Building[]>(this.controller);
  }

  getByKey(key: any): Observable<Building> {
    return this.http.get<Building>(`${this.controller}/${key}`);
  }

  post(Building: Building) {
    return this.http.post(this.controller, Building);
  }

  put(Building: Building) {
    return this.http.put(`${this.controller}/${Building.buildingKey}`, Building);
  }

  delete(key: Guid) {
    return this.http.delete(`${this.controller}/${key}`);
  }
}
