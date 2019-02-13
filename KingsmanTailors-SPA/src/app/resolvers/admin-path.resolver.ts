import { Injectable } from '@angular/core';
import { User } from '../models/user';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { UserService } from '../services/user.service';
import { AlertifyService } from '../services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AdminPath } from './../models/admin-path';

@Injectable()
export class AdminPathResolver implements Resolve<string[]> {
  constructor(private _router: Router, private _alertify: AlertifyService) {}

  resolve(route: ActivatedRouteSnapshot): Observable<string[]> {
    const adminLinks: string[] = [];
    this._router.config.forEach(parent => {
      // only ones with children
      if (parent.children) {
        // all children that do not have /:id
        parent.children.forEach(child => {
          if (child.path.indexOf(':') <= 0) {
            adminLinks.push(child.path);
            console.log(child);
          }
        });
        return adminLinks;
      }
      // console.log('Links', this.adminLinks);
    });

    // return this._userService.getUsers().pipe(
    //   catchError(err => {
    //     this._alertify.error('Errors occurred retrieving users');
    //     this._router.navigate(['/admin/home']);
    //     return of(null);
    //   })
    // );
    return adminLinks;
  }
}
