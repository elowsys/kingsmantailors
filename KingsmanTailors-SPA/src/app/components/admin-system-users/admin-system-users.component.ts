import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserService } from './../../services/user.service';
import { AlertifyService } from 'src/app/services/alertify.service';
import { AuthService } from './../../services/auth.service';
import { HeaderService } from 'src/app/services/header.service';

import { User } from 'src/app/models/user';

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
    private _headerService: HeaderService,
    private _authService: AuthService,
    private _route: ActivatedRoute
  ) {}

  ngOnInit() {
    // this.loadUsers();
    this._route.data.subscribe(data => {
      // this.users = data['users'];
      // only show users your role surpasses
      this.users = [];
      const restrictedUsers = data['users'];
      if (restrictedUsers) {
        // only show users below your role
        restrictedUsers.forEach(role => {
          if (
            role.roleCode.split('|')[0] ===
            this._authService.getLoggedInRoleCode()
          ) {
            this.users.push(role);
          } else {
            // add if array is now initialized
            if (this.users.length > 0) {
              this.users.push(role);
            }
          }
        });
      }
    });

    this._headerService.initialize(
      'System Users',
      'admin-banner text-center',
      'fa fa-users'
    );
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
