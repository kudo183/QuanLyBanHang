import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthService } from '../auth.service';

@Component({
  selector: 'login',
  templateUrl: 'login.component.html',
  styleUrls: ['login.component.css']
})

export class LoginComponent implements OnInit {
  user: string;
  pass: string;
  confirmPass: string;
  loading = false;
  resetPassToken;
  returnUrl: string;
  message: string;
  ModeEnum = ModeEnum;
  mode = ModeEnum.LOGIN;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private authService: AuthService) {
  }

  ngOnInit() {
    // get return url from route parameters or default to '/'
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';

    if (this.authService.isLoggedIn() === true) {
      this.router.navigate([this.returnUrl]);
    }

    this.resetPassToken = this.route.snapshot.queryParams['reset'];
    if (this.resetPassToken !== undefined) {
      this.mode = ModeEnum.RESET_PASSWORD;
      this.user = this.route.snapshot.queryParams['user'];
    }
  }

  loginOK() {
    this.loading = true;
    this.message = '';
    this.authService.login(this.user, this.pass)
      .subscribe(
      data => {
        this.router.navigate([this.returnUrl]);
      },
      error => {
        this.loading = false;
        switch (error.status) {
          case 400:
            this.message = 'bad request';
            break;
          case 401:
            this.message = 'wrong pass';
            break;
          case 404:
            this.message = 'user not exist';
            break;
        }
      }
      );
  }

  registerOK() {
    this.loading = true;
    this.message = '';
    this.authService.register(this.user)
      .subscribe(
      data => {
        this.loading = false;
        this.message = 'Please check your email to get the access link.';
      },
      error => {
        this.loading = false;
        switch (error.status) {
          case 400:
            this.message = 'bad request';
            break;
          case 401:
            this.message = 'Unauthorized';
            break;
          case 404:
            this.message = 'user not exist';
            break;
        }
      }
      );
  }

  requestOK() {
    this.loading = true;
    this.message = '';
    this.authService.requestPassword(this.user)
      .subscribe(
      data => {
        this.loading = false;
        this.message = 'check your email for reset password link.';
      },
      error => {
        this.loading = false;
        switch (error.status) {
          case 400:
            this.message = 'bad request';
            break;
          case 401:
            this.message = 'Unauthorized';
            break;
          case 404:
            this.message = 'user not exist';
            break;
        }
      }
      );
  }

  resetOK() {
    if (this.pass !== this.confirmPass) {
      this.message = 'Password does not match the confirm password.';
      return;
    }

    this.message = '';
    this.loading = true;
    this.authService.resetPassword(this.resetPassToken, this.pass)
      .subscribe(
      data => {
        this.loading = false;
        // this.switchMode(this.ModeEnum.LOGIN);
        this.loginOK();
      },
      error => {
        this.loading = false;
        switch (error.status) {
          case 400:
            this.message = 'bad request';
            break;
          case 401:
            this.message = 'Unauthorized';
            break;
          case 404:
            this.message = 'user not exist';
            break;
        }
      }
      );
  }

  switchMode(mode, event?) {
    this.mode = mode;
    if (event !== undefined) {
      event.preventDefault();
    }
  }
}

export enum ModeEnum {
  LOGIN,
  REGISTER,
  REQUEST_PASSWORD,
  RESET_PASSWORD,
}
