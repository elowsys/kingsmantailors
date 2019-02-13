import { Component, OnInit, ViewChild, HostListener } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm } from '@angular/forms';

import { UserService } from './../../services/user.service';
import { AlertifyService } from './../../services/alertify.service';
import { AuthService } from './../../services/auth.service';
import { HeaderService } from 'src/app/services/header.service';

import { Role } from 'src/app/models/role';
import { User } from 'src/app/models/user';

@Component({
  selector: 'app-admin-system-user-edit',
  templateUrl: './admin-system-user-edit.component.html',
  styleUrls: ['./admin-system-user-edit.component.css']
})
export class AdminSystemUserEditComponent implements OnInit {
  @ViewChild('editUser') editForm: NgForm;
  roles: Role[];
  user: User;
  @HostListener('window:beforeunload', ['$event'])
  unloadNotification($event: any) {
    if (this.editForm.dirty) {
      return ($event.returnValue = true);
    }
  }

  constructor(
    private _authService: AuthService,
    private _userService: UserService,
    private _headerService: HeaderService,
    private _route: ActivatedRoute,
    private _router: Router,
    private _alertify: AlertifyService
  ) {}

  ngOnInit() {
    this._route.data.subscribe(data => {
      this.roles = [];
      this.user = data['user'];
      // only show roles at your level and below
      const restrictedRoles: Role[] = data['roles'];
      if (restrictedRoles) {
        restrictedRoles.forEach(role => {
          if (role.roleId === this._authService.getLoggedInRoleCode()) {
            this.roles.push(role);
          } else {
            // add if array is now initialized
            if (this.roles.length > 0) {
              this.roles.push(role);
            }
          }
        });
      }
      // console.log(this.roles, this.user, restrictedRoles);
    });

    this._headerService.initialize(
      'System Users - Edit ' + this.user.username,
      'admin-banner text-center',
      'fa fa-user-circle-o'
    );
  }

  lockUser() {
    const toggled = !this.user.lockedOutEnabled;
    if (toggled) {
      // if the locked out end is not null or 1900 then reset it
      this.user.lockedOutEnd = new Date(
        new Date().getFullYear() + 100,
        new Date().getMonth(),
        new Date().getDay()
      );
    } else {
      this.user.lockedOutEnd = new Date('1900-01-01T00:00:00Z');
    }
    console.log(toggled, this.user.lockedOutEnd);
  }

  updateUser() {
    console.log('Edit user', this.user);
    // now do commit to the database
    // const toggled = this.user.lockedOutEnabled;
    // if (this.user.lockedOutEnabled) {
    //   // if the locked out end is not null or 1900 then reset it
    //   // const dt = new Date();
    //   // const yr = new Date().getFullYear() + 100;
    //   // const dt = new Date(
    //   //   new Date().getFullYear() + 100,
    //   //   new Date().getMonth(),
    //   //   new Date().getDay()
    //   // );
    //   this.user.lockedOutEnd = new Date(
    //     new Date().getFullYear() + 100,
    //     new Date().getMonth(),
    //     new Date().getDay()
    //   );
    // }
    this._userService.updateSpecial(this.user.userId, this.user).subscribe(
      resp => {
        console.log('resp', resp);
        if (!resp) {
          // this._alertify.success(
          //   'Successfully updated details for ' + this.user.displayName
          // );
          this._router.navigate(['/admin/system/users/' + this.user.userId]);
        }
      },
      err => {
        this._alertify.error('Failed to update user - ' + err);
        console.log('err', err);
      }
    );

    this.editForm.reset(this.user);
  }
}
