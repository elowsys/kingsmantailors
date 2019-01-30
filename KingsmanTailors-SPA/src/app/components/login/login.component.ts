import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthService } from './../../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  model: any = {};
  constructor(private auth: AuthService, http: HttpClient) {}

  ngOnInit() {}

  login() {
    this.auth.login(this.model).subscribe(
      next => {
        console.log('Logged in!!!');
      },
      err => {
        console.log(err);
      }
    );
  }
}
