import { Component } from '@angular/core';
import { LoginService } from '../Service/login.service';
import { UserService } from '../Service/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {

  constructor(private loginservice: LoginService, private userService: UserService, private router: Router, ) {
    this.getLoginDetails();
  }

  ngOnInit() {
    this.getLoginDetails();
    this.loginservice.getLoginStatus().subscribe(x => {
      this.getLoginDetails();
    });
  }

  isAuthenticated = false;
  userName = "";
  role = "";

  getLoginDetails() {
    debugger;
    this.isAuthenticated = this.loginservice.isAuthenticated();
    this.userName = this.loginservice.getUserName();
    this.role = this.loginservice.getRole();
    if (this.role == "User") {
      this.router.navigate(['/payment']);
    }
    else if (this.role == "Admin") {
      this.router.navigate(['/user-detail']);
    }
  }

  logout() {
    this.loginservice.logout();
    this.router.navigate(['/']);
  }

  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
