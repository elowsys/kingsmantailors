import { Component, OnInit } from '@angular/core';
import { AuthService } from './../../services/auth.service';
import { AlertifyService } from './../../services/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  model: any = {};

  constructor(
    private authService: AuthService,
    private alertify: AlertifyService,
    private _router: Router
  ) {}

  ngOnInit() {}

  login() {
    this.authService.login(this.model).subscribe(
      next => {
        // this.alertify.success('Logged in!!!');
        this._router.navigate(['/home']);
      },
      err => {
        console.log(err);
        this.alertify.error(err);
      }
    );
  }
}
