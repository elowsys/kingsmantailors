import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { AlertifyService } from '../services/alertify.service';

@Injectable({
  providedIn: 'root'
})
export class AdminGuard implements CanActivate {
  constructor(
    private _router: Router,
    private _authService: AuthService,
    private _alertify: AlertifyService
  ) {}

  canActivate(): boolean {
    // Is the user logged in?
    if (this._authService.isLoggedIn()) {
      console.log(this._router);
      // // Is user in role: use role guid
      // if (this._authService.isInRole(['dd', 'ff'])) {
      return true;
      // }
    }
    this._alertify.error('You are not authorised to access this area.');
    this._router.navigate(['/home']);
  }
}
