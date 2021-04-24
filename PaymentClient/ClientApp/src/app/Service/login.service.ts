import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private loginStatus: BehaviorSubject<boolean>;
  constructor() {
    this.loginStatus = new BehaviorSubject(this.isAuthenticated());
  }


  login(token: string, username: string, email: string, role: string, currentUserId: string) {
    localStorage.setItem("jwt", token);
    localStorage.setItem("username", username);
    localStorage.setItem("email", email);
    localStorage.setItem("role", role);
    localStorage.setItem("currentUserId", currentUserId);
    this.loginStatus.next(true);
  }

  isAuthenticated(): boolean {
    if (localStorage["jwt"]) {
      return true;
    }
    return false;
  }

  getUserName(): string {
    return localStorage.getItem("username");
  }

  getEmail(): string {
    return localStorage.getItem("email");
  }

  getRole(): string {
    return localStorage.getItem("role");
  }

  getCurrentUserId(): string {
    return localStorage.getItem("currentUserId");
  }

  logout() {
    localStorage.clear();
    this.loginStatus.next(false);
  }

  getLoginStatus(): Observable<boolean> {
    return this.loginStatus.asObservable();
  }
}
