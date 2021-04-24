import { Component, OnInit } from '@angular/core';
import { UserService } from '../Service/user.service';
import jwt_decode from 'jwt-decode';
import { LoginService } from '../Service/login.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private userService: UserService, private loginService: LoginService, private router: Router) { }

  ngOnInit() {
  }
  CustomLogin(data) {
    this.userService.CustomLogin(data).subscribe((res) => {
      debugger;
      let token = (<any>res).Token;
      let decodedToken = jwt_decode(token);
      let username = decodedToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'];
      let email = decodedToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress'];
      let role = decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
      let uid = decodedToken['UId'];
      let registeredDate = decodedToken['RegisteredDate'];
      this.loginService.login(token, username, email, role, uid);
      if (role == "User") {
        this.router.navigate(['/payment']);
      }
      else if (role == "Admin") {
        this.router.navigate(['/user-detail']);
      }
    }, (error) => {
      alert("Incorrect Email id or Password, Please retry!");
    });
  }
}
