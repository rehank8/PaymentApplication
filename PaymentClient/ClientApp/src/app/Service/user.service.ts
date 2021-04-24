import { HttpClient, HttpHeaders, HttpErrorResponse, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { UserDetail } from '../Models/UserDetail';
import { environment } from '../../environments/environment';

@Injectable()
export class UserService {
  //baseUrl = "https://localhost:44391/api/";
  baseUrl = environment.APIUrl+"/api/";

  constructor(private http: HttpClient) { }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    })
  };

  CustomLogin(user): Observable<any> {
    let apiUrl = this.baseUrl + "AuthAPI/Login";
    return this.http.post<any>(apiUrl, user, this.httpOptions);
  }

  addUser(fileToUpload: File, userdata: UserDetail): Observable<any> {
    var token = localStorage.getItem("jwt");

    var options = {
      headers: new HttpHeaders({
        "Authorization": "Bearer " + token,
        "Content-Disposition": "multipart/form-data"
      })
    };
    const formData = new FormData();
    if (fileToUpload) {
      formData.append('file', fileToUpload, fileToUpload.name);
    }
    formData.append('userData', JSON.stringify(userdata));
    let apiUrl = this.baseUrl + "UserProfile/AddUser";
    return this.http.post<any>(apiUrl, formData, options);

  }

  editUser(fileToUpload: File, userdata: UserDetail): Observable<any> {
    var token = localStorage.getItem("jwt");

    var options = {
      headers: new HttpHeaders({
        "Authorization": "Bearer " + token,
        "Content-Disposition": "multipart/form-data"
      })
    };
    const formData = new FormData();
    if (fileToUpload) {
      formData.append('file', fileToUpload, fileToUpload.name);
    }
    formData.append('userData', JSON.stringify(userdata));
    let apiUrl = this.baseUrl + "UserProfile/EditUser";
    return this.http.post<any>(apiUrl, formData, options);

  }

  getRoles(): Observable<any> {
    let apiUrl = this.baseUrl + "Role/GetAllRoles";
    return this.http.post<any>(apiUrl, this.httpOptions);
  }

  getUserById(userId: string): Observable<any> {
    let apiUrl = this.baseUrl + "UserProfile/GetUserById?userId=" + userId;
    return this.http.get<any>(apiUrl, this.httpOptions);
  }

  deleteUserById(userId: string): Observable<any> {
    let apiUrl = this.baseUrl + "UserProfile/DeleteUserById?userId=" + userId;
    return this.http.post<any>(apiUrl, this.httpOptions);
  }
}
