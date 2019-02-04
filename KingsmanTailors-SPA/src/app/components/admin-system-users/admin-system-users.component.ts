import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserService } from './../../services/user.service';
import { User } from 'src/app/models/user';
import { AlertifyService } from 'src/app/services/alertify.service';

@Component({
  selector: 'app-admin-system-users',
  templateUrl: './admin-system-users.component.html',
  styleUrls: ['./admin-system-users.component.css']
})
export class AdminSystemUsersComponent implements OnInit {
  users: User[];
  constructor(
    private _userService: UserService,
    private _alertify: AlertifyService,
    private _route: ActivatedRoute
  ) {}

  ngOnInit() {
    // this.loadUsers();
    this._route.data.subscribe(data => {
      this.users = data['users'];
    });
  }

  // loadUsers() {
  //   this._userService
  //     .getUsers()
  //     .pipe()
  //     .subscribe(
  //       data => {
  //         this.users = data;
  //         console.log(data);
  //       },
  //       err => {
  //         this._alertify.error(err);
  //       }
  //     );
  // }
}
