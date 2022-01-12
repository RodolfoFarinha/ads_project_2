import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError, finalize } from 'rxjs/operators';

import { Loader } from './loader';

@Injectable()
export class LoadingInterceptor implements HttpInterceptor {

  requestCount = 0;

  constructor() { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    setTimeout(() => { this.show(); }, 0)

    return next.handle(req).pipe(
      finalize(() => {
        setTimeout(() => { this.hide(); }, 0)
      })
    );
  }

  show() {
    this.requestCount++;
    Loader.isLoading = true;
  }

  hide() {
    this.requestCount--;
    if (this.requestCount == 0) {
      Loader.isLoading = false;
    }
  }
}

