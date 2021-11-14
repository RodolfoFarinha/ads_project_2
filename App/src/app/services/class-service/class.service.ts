import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from 'src/environments/environment';

import { Guid } from 'guid-typescript';
import { Class } from './../../models/Class';

@Injectable({
  providedIn: 'root'
})
export class ClassService {

  controller = `${environment.apiUrl}` + 'class';

  constructor(private http: HttpClient) { }

  getAll(): Observable<Class[]> {
    return this.http.get<Class[]>(this.controller);
  }

  getByKey(key): Observable<Class> {
    return this.http.get<Class>(`${this.controller}/${key}`);
  }

  post(Class: Class) {
    return this.http.post(this.controller, Class);
  }

  put(Class: Class) {
    return this.http.put(`${this.controller}/${Class.classKey}`, Class);
  }

  delete(key: Guid) {
    return this.http.delete(`${this.controller}/${key}`);
  }
}
