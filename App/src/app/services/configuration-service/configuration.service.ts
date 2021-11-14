import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from 'src/environments/environment';

import { Guid } from 'guid-typescript';
import { Configuration } from './../../models/Configuration';

@Injectable({
  providedIn: 'root'
})
export class ConfigurationService {

  controller = `${environment.apiUrl}` + 'configuration';

  constructor(private http: HttpClient) { }

  getAll(): Observable<Configuration[]> {
    return this.http.get<Configuration[]>(this.controller);
  }

  getByKey(key): Observable<Configuration> {
    return this.http.get<Configuration>(`${this.controller}/${key}`);
  }

  post(Configuration: Configuration) {
    return this.http.post(this.controller, Configuration);
  }

  put(Configuration: Configuration) {
    return this.http.put(`${this.controller}/${Configuration.configurationKey}`, Configuration);
  }

  delete(key: Guid) {
    return this.http.delete(`${this.controller}/${key}`);
  }
}
