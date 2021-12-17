import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from 'src/environments/environment';

import { Guid } from 'guid-typescript';
import { Property } from './../../models/entities/Property';

@Injectable({
  providedIn: 'root'
})
export class PropertyService {

  controller = `${environment.apiUrl}` + 'property';

  constructor(private http: HttpClient) { }

  getAll(): Observable<Property[]> {
    return this.http.get<Property[]>(this.controller);
  }

  getByKey(key: any): Observable<Property> {
    return this.http.get<Property>(`${this.controller}/${key}`);
  }

  post(Property: Property) {
    return this.http.post(this.controller, Property);
  }

  put(Property: Property) {
    return this.http.put(`${this.controller}/${Property.propertyKey}`, Property);
  }

  delete(key: Guid) {
    return this.http.delete(`${this.controller}/${key}`);
  }
}
