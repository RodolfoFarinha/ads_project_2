import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from 'src/environments/environment';

import { Guid } from 'guid-typescript';
import { Course } from './../../models/Course';

@Injectable({
  providedIn: 'root'
})
export class CourseService {

  controller = `${environment.apiUrl}` + 'course';

  constructor(private http: HttpClient) { }

  getAll(): Observable<Course[]> {
    return this.http.get<Course[]>(this.controller);
  }

  getByKey(key): Observable<Course> {
    return this.http.get<Course>(`${this.controller}/${key}`);
  }

  post(Course: Course) {
    return this.http.post(this.controller, Course);
  }

  put(Course: Course) {
    return this.http.put(`${this.controller}/${Course.courseKey}`, Course);
  }

  delete(key: Guid) {
    return this.http.delete(`${this.controller}/${key}`);
  }
}
