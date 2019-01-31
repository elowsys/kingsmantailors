import { Injectable } from '@angular/core';
import { DataService } from './data.service';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthService extends DataService {
  jwtHelper = new JwtHelperService();
  decodedToken: any;

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
          this.decodedToken = this.jwtHelper.decodeToken(user.token);
          console.log(user.token, this.decodedToken);
        }
      })
    );
  }

  logout() {
    // remove from local storage
    localStorage.removeItem('token');
    // reset the decoded token too
    this.decodedToken = null;
  }

  // register
  register(model: any) {
    console.log(model);
    // return this.http.post(this.BaseUrl + '/register', model);
  }

  isLoggedIn() {
    const token = localStorage.getItem('token');
    return !this.jwtHelper.isTokenExpired(token);
  }

  isInRole(role: string[]): boolean {
    return false;
  }

  getLoggedInUser() {
    if (this.isLoggedIn()) {
      // decode the token to extract the name
      // console.log(this.decodedToken);
      return this.decodedToken.unique_name;
    }
    return 'User';
  }
}
