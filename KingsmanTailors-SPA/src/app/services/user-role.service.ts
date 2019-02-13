import { Injectable } from '@angular/core';
import { DataService } from './data.service';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Role } from '../models/role';

@Injectable({
  providedIn: 'root'
})
export class UserRoleService extends DataService {
  constructor(http: HttpClient) {
    super(http, 'userrole');
  }

  getRoleByUserId(id: string): Observable<Role> {
    return this.getSpecial<Role>('/uid/' + id);
  }

  getRoleByRoleId(id: string): Observable<Role> {
    return this.getSpecial<Role>('/rid/' + id);
  }
}
