import { HttpClient, HttpHeaders, HttpErrorResponse, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

@Injectable()
export class PaymentService {
  baseUrl = "https://localhost:44391/api/";

  constructor(private http: HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    })
  };

  GetUserDetails(): Observable<any> {
    let apiUrl = this.baseUrl + "payment/GetAllUsers";
    return this.http.get<any>(apiUrl, this.httpOptions);
  }
}
