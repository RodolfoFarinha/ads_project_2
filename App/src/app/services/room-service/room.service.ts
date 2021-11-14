import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from 'src/environments/environment';

import { Guid } from 'guid-typescript';
import { Room } from './../../models/Room';

@Injectable({
  providedIn: 'root'
})
export class RoomService {

  controller = `${environment.apiUrl}` + 'room';

  constructor(private http: HttpClient) { }

  getAll(): Observable<Room[]> {
    return this.http.get<Room[]>(this.controller);
  }

  getByKey(key): Observable<Room> {
    return this.http.get<Room>(`${this.controller}/${key}`);
  }

  post(Room: Room) {
    return this.http.post(this.controller, Room);
  }

  put(Room: Room) {
    return this.http.put(`${this.controller}/${Room.roomKey}`, Room);
  }

  delete(key: Guid) {
    return this.http.delete(`${this.controller}/${key}`);
  }
}
