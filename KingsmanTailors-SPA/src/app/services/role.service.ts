import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DataService } from './data.service';
import { HttpClient } from '@angular/common/http';
import { Role } from '../models/role';

@Injectable({
  providedIn: 'root'
})
export class RoleService extends DataService {
  constructor(http: HttpClient) {
    super(http, 'roles');
  }

  getRoles(): Observable<Role[]> {
    return this.getAll<Role[]>();
  }

  getRole(id: any) {
    return this.getSpecial<Role>('/' + id);
  }
}
