import { Injectable } from '@angular/core';
import { DataService } from './data.service';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService extends DataService {
  constructor(http: HttpClient) {
    super(http, '/auth');
  }

  // login
  login(model: any) {
    return this.http.post(this.BaseUrl + '/login', model).pipe(
      map((response: any) => {
        const user = response;
        if (user) {
          localStorage.setItem('token', user.token);
          console.log(user);
        }
      })
    );
  }

  // register
  register(model: any) {
    console.log(model);
    // return this.http.post(this.BaseUrl + '/register', model);
  }
}
