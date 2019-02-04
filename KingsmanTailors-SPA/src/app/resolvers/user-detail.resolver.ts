import { Injectable } from '@angular/core';
import { User } from '../models/user';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { UserService } from './../services/user.service';
import { AlertifyService } from './../services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class UserDetailResolver implements Resolve<User> {
  constructor(
    private _userService: UserService,
    private _router: Router,
    private _alertify: AlertifyService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<User> {
    return this._userService.getUser(route.params['userId']).pipe(
      catchError(err => {
        this._alertify.error('Errors occurred retrieving user data');
        this._router.navigate(['/admin/system/users']);
        return of(null);
      })
    );
  }
}
