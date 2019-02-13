import { Component, OnInit, ViewChild, HostListener } from '@angular/core';
import { User } from 'src/app/models/user';
import { Role } from 'src/app/models/role';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { FileUploader } from 'ng2-file-upload';

import { HeaderService } from 'src/app/services/header.service';
import { environment } from 'src/environments/environment';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {
  @ViewChild('editProfile') editProfile: NgForm;
  role: Role;
  user: User;
  uploader: FileUploader;
  hasBaseDropZoneOver = false;
  hasAnotherDropZoneOver = false;
  baseUrl = environment.apiUrl;

  @HostListener('window:beforeunload', ['$event'])
  unloadNotification($event: any) {
    if (this.editProfile.dirty) {
      return ($event.returnValue = true);
    }
  }

  constructor(
    private _headerService: HeaderService,
    private _authService: AuthService,
    private _route: ActivatedRoute,
    private _router: Router
  ) {}

  ngOnInit() {
    this._route.data.subscribe(data => {
      this.user = data['user'];
      this.role = data['role'];
      console.log('user', this.user);
      console.log('role', this.role);
    });

    this._headerService.initialize(
      'Profile',
      'page-banner text-center',
      'fa fa-user'
    );

    this.initializeUploader();
  }

  initializeUploader() {
    this.uploader = new FileUploader({
      url:
        this.baseUrl + 'photos/user/' + this._authService.getLoggedInUserId(),
      authToken: 'Bearer ' + localStorage.getItem('token'),
      isHTML5: true,
      allowedFileType: ['image'],
      removeAfterUpload: true,
      autoUpload: false,
      maxFileSize: 5 * 1024 * 1024
    });

    // remove error on upload
    this.uploader.onAfterAddingFile = file => {
      file.withCredentials = false;
    };

    this.uploader.onSuccessItem = (item, response, status, headers) => {
      // console.log(item, response, status, headers);
      if (response) {
        // reset the user's publicId and url in token
        this._authService.resetLoginToken().subscribe(() => {
          // console.log('res: ', this._authService.getLoggedInPhotoUrl());
          this.user.url = this._authService.getLoggedInPhotoUrl();
        });
      }
    };
  }

  fileOverBase(e: any): void {
    this.hasBaseDropZoneOver = e;
  }

  updateProfile() {
    console.log(this.user);
  }
}
