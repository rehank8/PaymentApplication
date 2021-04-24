import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserDetail } from '../../Models/UserDetail';
import { isNullOrUndefined } from 'util';
import { UserService } from '../../Service/user.service';
import { UserRole } from '../../Models/UserRole';
import { environment } from '../../../environments/environment';


@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.css']
})
export class EditUserComponent implements OnInit {

  constructor(private route: ActivatedRoute, private userService: UserService, private router: Router) { }
  

  PKUserId: string;
  roles: UserRole;
  userImage: File;
  userProfile: UserDetail[] = [];
  url: string = environment.APIUrl;

  ngOnInit() {
    this.userService.getRoles().subscribe(res => {
      this.roles = res;
    })
    debugger;
    this.PKUserId = this.route.snapshot.paramMap.get("PKUserId");
    if (!isNullOrUndefined(this.PKUserId)) {
      this.userService.getUserById(this.PKUserId).subscribe(result => {
        debugger;
        this.userProfile = result;
      })
    }
  }

  SubmitBasicForm(data) {
    debugger;
    this.userService.editUser(this.userImage, data).subscribe(result => {
      this.router.navigate(['/user-detail']);
    })
  }
  onChangeFileInput(fileInput: any) {
    if (!isNullOrUndefined(fileInput)) {
      this.userImage = fileInput.target.files[0];
    }
  }
}
