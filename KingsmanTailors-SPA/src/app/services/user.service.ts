import { Injectable } from '@angular/core';
import { DataService } from './data.service';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService extends DataService {
  constructor(http: HttpClient) {
    super(http, 'users');
  }

  getUsers(): Observable<User[]> {
    // return this.http.get<User[]>(this.BaseUrl);
    return this.getAll<User[]>();
  }

  getUser(id: string): Observable<User> {
    // return this.http.get<User>(this.BaseUrl + '/uid/' + id);
    return this.getSpecial<User>('/uid/' + id);
  }
}
