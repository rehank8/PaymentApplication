import { Component, OnInit } from '@angular/core';
//import { TagInputModule } from 'ngx-chips';
import { UserDetail } from '../../Models/UserDetail';
import { UserService } from '../../Service/user.service';
import { isNullOrUndefined } from 'util';
import { UserRole } from '../../Models/UserRole';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class AddUserComponent implements OnInit {

  userProfile: UserDetail[] = [];
  roles: UserRole;
  mobnumPattern = "^((\\+91-?)|0)?[0-9]{10}$";
  userImage: File;
  constructor(private userService: UserService, private router: Router) { }

  ngOnInit() {
    this.userService.getRoles().subscribe(res => {
      this.roles = res;
    })
  }

  SubmitBasicForm(data) {
    debugger;
    this.userService.addUser(this.userImage, data).subscribe(result => {
      this.router.navigate(['/user-detail']);
    })


  }
  onChangeFileInput(fileInput: any) {
    if (!isNullOrUndefined(fileInput)) {
      this.userImage = fileInput.target.files[0];
    }
  }

}
