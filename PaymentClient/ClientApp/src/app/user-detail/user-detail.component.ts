import { Component, OnInit } from '@angular/core';
import { UserDetail } from '../Models/UserDetail';
import { PaymentService } from '../payment.service';
import { UserService } from '../Service/user.service';

@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-detail.component.css']
})
export class UserDetailComponent implements OnInit {

  constructor(private paymentService: PaymentService, private userService: UserService) { }

  users: UserDetail;

  ngOnInit() {
    this.getAllUserDetail();
  }

  getAllUserDetail() {
    this.paymentService.GetUserDetails().subscribe((res) => {
      debugger;
      console.log(res);
      this.users = res;
    })
  }

  DeleteUser(id) {
    debugger;
    this.userService.deleteUserById(id).subscribe(res => {
      this.getAllUserDetail();
    })
  }

}
