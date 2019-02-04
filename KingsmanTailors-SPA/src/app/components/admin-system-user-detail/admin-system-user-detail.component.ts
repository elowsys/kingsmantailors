import { Component, OnInit } from '@angular/core';
import { UserService } from './../../services/user.service';
import { AlertifyService } from 'src/app/services/alertify.service';
import { ActivatedRoute } from '@angular/router';
import { User } from 'src/app/models/user';
import {
  NgxGalleryOptions,
  NgxGalleryImage,
  NgxGalleryAnimation
} from 'ngx-gallery';

@Component({
  selector: 'app-admin-system-user-detail',
  templateUrl: './admin-system-user-detail.component.html',
  styleUrls: ['./admin-system-user-detail.component.css']
})
export class AdminSystemUserDetailComponent implements OnInit {
  user: User;
  // galleryOptions: NgxGalleryOptions[];
  // galleryImages: NgxGalleryImage[];

  constructor(
    private _userService: UserService,
    private _alertify: AlertifyService,
    private _route: ActivatedRoute
  ) {}

  ngOnInit() {
    // this.loadUser();
    this._route.data.subscribe(data => {
      this.user = data['user'];
    });

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
