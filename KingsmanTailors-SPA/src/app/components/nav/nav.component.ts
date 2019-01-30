import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  // store user details for authentication
  // model: any = {};

  constructor() {}

  ngOnInit() {}

  // login() {
  //   console.log(this.model);
  // }

  isLoggedIn() {
    const token = localStorage.getItem('token');
    // console.log(token);
    return !!token;
  }

  // Is in role
  isInRole() {
    return false;
  }

  logout() {
    localStorage.removeItem('token');
    console.log('Logged out');
  }
}
