import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthService } from './../../services/auth.service';
import { AlertifyService } from './../../services/alertify.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  model: any = {};
  constructor(private auth: AuthService, private alertify: AlertifyService) {}

  ngOnInit() {}

  login() {
    this.auth.login(this.model).subscribe(
      next => {
        console.log('Logged in!!!');
        this.alertify.success('Logged in!!!');
      },
      err => {
        console.log(err);
        this.alertify.error(err);
      }
    );
  }
}
