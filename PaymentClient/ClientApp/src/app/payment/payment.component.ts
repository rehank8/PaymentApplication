import { Component, OnInit } from '@angular/core';
import { LoginService } from '../Service/login.service';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent implements OnInit {

  constructor(private loginService: LoginService) { }

  isAuthenticated = false;
  userName = "";
  emailId = "";
  role = "";
  currentUserId: string;

  ngOnInit() {
    this.getLoginDetails();
  }

  getLoginDetails() {
    this.isAuthenticated = this.loginService.isAuthenticated();
    this.userName = this.loginService.getUserName();
    this.currentUserId = this.loginService.getCurrentUserId();
    this.emailId = this.loginService.getEmail();
    this.role = this.loginService.getRole();
  }

  SubmitPayment(data) {
    console.log(data);
  }

}
