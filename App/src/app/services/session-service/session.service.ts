import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from 'src/environments/environment';

import { Guid } from 'guid-typescript';
import { Session } from './../../models/entities/Session';

@Injectable({
  providedIn: 'root'
})
export class SessionService {

  controller = `${environment.apiUrl}` + 'session';

  constructor(private http: HttpClient) { }

  getAll(): Observable<Session[]> {
    return this.http.get<Session[]>(this.controller);
  }

  getByKey(key: any): Observable<Session> {
    return this.http.get<Session>(`${this.controller}/${key}`);
  }

  post(Session: Session) {
    return this.http.post(this.controller, Session);
  }

  put(Session: Session) {
    return this.http.put(`${this.controller}/${Session.sessionKey}`, Session);
  }

  delete(key: Guid) {
    return this.http.delete(`${this.controller}/${key}`);
  }
}
