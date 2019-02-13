import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
// import {
//   NgxGalleryOptions,
//   NgxGalleryImage,
//   NgxGalleryAnimation
// } from 'ngx-gallery';

import { AuthService } from 'src/app/services/auth.service';

import { Role } from 'src/app/models/role';
import { User } from 'src/app/models/user';
import { RoleService } from 'src/app/services/role.service';
import { UserService } from 'src/app/services/user.service';
import { HeaderService } from 'src/app/services/header.service';

@Component({
  selector: 'app-admin-system-user-detail',
  templateUrl: './admin-system-user-detail.component.html',
  styleUrls: ['./admin-system-user-detail.component.css']
})
export class AdminSystemUserDetailComponent implements OnInit {
  user: User;
  role: Role;
  // galleryOptions: NgxGalleryOptions[];
  // galleryImages: NgxGalleryImage[];

  constructor(
    // private _alertify: AlertifyService,
    // private _authService: AuthService,
    // private _roleService: RoleService,
    private _userService: UserService,
    private _headerService: HeaderService,
    private _route: ActivatedRoute
  ) {}

  ngOnInit() {
    this._route.data.subscribe(data => {
      this.user = data['user'];
      this.role = data['role'];
      // console.log(this.user, this.role);
    });

    this._headerService.initialize(
      'System Users - Viewing ' + this.user.displayName,
      'admin-banner text-center',
      'fa fa-user'
    );

    // this.galleryOptions = [
    //   {
    //     width: '500px',
    //     height: '500px',
    //     imagePercent: 100,
    //     thumbnailsColumns: 4,
    //     imageAnimation: NgxGalleryAnimation.Slide,
    //     preview: false
    //   }
    // ];

    // this.galleryImages = this.getImages();
  }

  // getImages() {
  //   const imageUrls = [];
  //   for (let i = 0; i < this.user.email.length; i++) {
  //     const element = this.user.email[i];
  //     imageUrls.push({
  //       small: 'path-to-image',
  //       medium: 'path-to-image',
  //       large: 'path-to-image',
  //       description: 'Some-text-to-describe-this-photo'
  //     });
  //   }

  //   return imageUrls;
  // }

  // loadUser() {
  //   this._userService.getUser(this._route.snapshot.params['userId']).subscribe(
  //     (usr: User) => {
  //       this.user = usr;
  //     },
  //     err => {
  //       this._alertify.error(err);
  //     }
  //   );
  // }
}
