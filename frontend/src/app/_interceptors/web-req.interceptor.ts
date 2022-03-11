import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { catchError, empty, Observable, throwError } from 'rxjs';
import { AuthService } from '../services/auth.service';

@Injectable()
export class WebReqInterceptor implements HttpInterceptor {
  refreshingAccessToken: boolean = false;

  constructor(private authService: AuthService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    // return next.handle(request);
    request = this.addAuthHeader(request);
    return next.handle(request).pipe(
      catchError((error: HttpErrorResponse) => {
        console.log(error);

        if (error.status === 401 && !this.refreshAccessToken) {
          
          this.refreshAccessToken()
            // .pipe(
            //   switchMap(() => {
            //     request = this.addAuthHeader(request);
            //     return next.handle(request);
            //   }),
            //   catchError((err: any) => {
            //     console.log(err);
            //     this.authService.logout();
            //     return empty();
            //   })
            // );
        }
        return throwError(error);
      })
    )
  }

  refreshAccessToken() {
    this.refreshingAccessToken = true;
    return this.authService.getNewAccessToken()
      // .pipe(
      //   tap(() => {
      //     console.log("Access Token Refreshed!");
      //     this.refreshingAccessToken = false;
      //   })
      // );
  }

  addAuthHeader(request: HttpRequest<any>) {
    const token = this.authService.getAccessToken();

    if (token) {
      return request.clone({
        setHeaders: {
          'x-access-token': token
        }
      })
    }

    return request;
  }
}
