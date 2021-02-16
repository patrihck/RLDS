import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor, HttpResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { LayoutService, MessageSeverity } from '../services/layout/layout.service';

@Injectable({
  providedIn: 'root'
})
export class ErrorInterceptor implements HttpInterceptor {
  maxResponseSizeMb = 20;

  constructor(
    private readonly router: Router,
    private readonly messageService: MessageService,
  ) {}

  // https://medium.com/angular-in-depth/top-10-ways-to-use-interceptors-in-angular-db450f8a62d6
  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    return next.handle(request).pipe(
      map((event: HttpEvent<any>) => {
        if (event instanceof HttpResponse && event != null) {
          let contentLength = parseInt(event.headers.get("content-length")); // BYTES
          let contentLengthMb = contentLength / 1000000; // MegaBytes
          if (contentLengthMb > this.maxResponseSizeMb) {
            this.showCodeError(`Odpowiedź serwera przekracza ${this.maxResponseSizeMb}MB`);
          }
        }

        //this.inactiveAlertService.setup();

        return event;
      },
        catchError(err => {

          this.showCodeError(`Błąd ${err.status} ${err.error.message}`);

          this.router.navigateByUrl('/');

          let error = (err != null && err.error != null) ? err.error.message : err.statusText;

          return throwError(error);
        })
      )
    )
  }

  showCodeError(error: string) {
    this.messageService.add({ severity: 'Error', summary: 'Błąd API', detail: error });
  }

}

export function defaultRequestErrorHandler(layoutService: LayoutService, error: any) {
  console.error("Request error: ", error);
  if (!error)
    return;

  if (error.title)
    layoutService.showPopover(MessageSeverity.error, error.title);

  const errors = error.errors;

  if (errors)
    for (const property in errors) {
      if (errors.hasOwnProperty(property) && Array.isArray(errors[property])) {
        errors[property].forEach(err => {
          if (err)
            layoutService.showPopover(MessageSeverity.error, err);
        });
      }
    }
}
