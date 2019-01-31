import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from './../services/auth.service';
import { AlertifyService } from 'src/app/services/alertify.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  /**
   *
   */
  constructor(
    private _router: Router,
    private _authService: AuthService,
    private _alertify: AlertifyService
  ) {}
  canActivate(): boolean {
    // Is the user logged in?
    if (this._authService.isLoggedIn()) {
      return true;
    }
    this._alertify.error('You are not authorised to access this area.');
    this._router.navigate(['/home']);
  }
}
