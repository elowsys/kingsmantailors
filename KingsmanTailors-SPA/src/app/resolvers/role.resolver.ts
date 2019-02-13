import { Injectable } from '@angular/core';
import { User } from '../models/user';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { AlertifyService } from '../services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Role } from '../models/role';
import { RoleService } from '../services/role.service';

@Injectable()
export class RoleResolver implements Resolve<Role> {
  constructor(
    private _roleService: RoleService,
    private _router: Router,
    private _alertify: AlertifyService
  ) {}

  resolve(route: ActivatedRouteSnapshot): Observable<Role> {
    return this._roleService.getRoles().pipe(
      catchError(err => {
        this._alertify.error('Errors occurred retrieving role data');
        this._router.navigate(['/admin/system/users']);
        return of(null);
      })
    );
  }
}
