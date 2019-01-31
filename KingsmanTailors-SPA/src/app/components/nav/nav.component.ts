import { Component, OnInit } from '@angular/core';
import { AlertifyService } from 'src/app/services/alertify.service';
import { AuthService } from './../../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  // store user details for authentication
  // model: any = {};

  constructor(
    private alertify: AlertifyService,
    private _auth: AuthService,
    private _route: Router
  ) {}

  ngOnInit() {}

  isLoggedIn() {
    return this._auth.isLoggedIn();
  }

  // Is in role
  isInRole() {
    return false;
  }

  getLoggedInUser() {
    return this._auth.getLoggedInUser();
  }

  logout() {
    if (this._auth.isLoggedIn()) {
      this._auth.logout();
      this.alertify.message('Logged out');
      this._route.navigate(['/home']);
    }
  }
}
