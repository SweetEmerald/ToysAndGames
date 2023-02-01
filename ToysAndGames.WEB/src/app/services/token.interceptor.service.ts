import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TokenInterceptorService implements HttpInterceptor{

  constructor() { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    let token = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6InVub3NxdWFyZUBleGFtcGxlLmNvbSIsImV4cCI6MTY5NzcyNzc1Mn0.Te5j59tRnuXgsmQgwdvZOHM7_fKS0D_VBDfsHLqK67c';

    let jwttoken = req.clone({
      setHeaders:{
        Authorization: 'Bearer ' + token
      }
    })
    return next.handle(jwttoken);
  }
}
