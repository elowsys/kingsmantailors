import { Injectable } from '@angular/core';
import { User } from '../models/user';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { UserService } from '../services/user.service';
import { AlertifyService } from '../services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Role } from '../models/role';

@Injectable()
export class UserRoleResolver implements Resolve<Role> {
  constructor(
    private _userService: UserService,
    private _router: Router,
    private _alertify: AlertifyService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<Role> {
    return this._userService.getUserRole(route.params['userId']).pipe(
      catchError(err => {
        this._alertify.error('Errors occurred retrieving user role data');
        this._router.navigate(['/admin/system/users']);
        return of(null);
      })
    );
  }
}
