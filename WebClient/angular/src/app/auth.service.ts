import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { catchError, map, tap } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class AuthService {

  private TOKEN_KEY = 'token';

  RootUri = 'https://gaucon.net/';

  SmtUri = this.RootUri + 'smt/';

  constructor(private http: HttpClient) { }

  login(user: string, pass: string): Observable<any> {
    const body = new URLSearchParams();
    body.set('user', user);
    body.set('pass', pass);
    const options = {
      headers: new HttpHeaders().set('Content-Type', 'application/x-www-form-urlencoded')
    };
    return this.http.post<string>(this.getFullUri('tenantlogin'), body.toString(), options).pipe(
      tap(result => localStorage.setItem(this.TOKEN_KEY, result)));
  }

  register(user: string): Observable<any> {
    const body = new URLSearchParams();
    body.set('user', user);
    body.set('tenantname', user);
    const options = {
      headers: new HttpHeaders().set('Content-Type', 'application/x-www-form-urlencoded')
    };
    return this.http.post<string>(this.getFullUri('register'), body.toString(), options);
  }

  requestPassword(email: string): Observable<any> {
    const body = new URLSearchParams();
    body.set('email', email);
    body.set('purpose', 'resetpassword');
    const options = {
      headers: new HttpHeaders().set('Content-Type', 'application/x-www-form-urlencoded')
    };
    return this.http.post<string>(this.getFullUri('tenantrequesttoken'), body.toString(), options);
  }

  resetPassword(token: string, pass: string): Observable<any> {
    const body = new URLSearchParams();
    body.set('token', token);
    body.set('pass', pass);
    const options = {
      headers: new HttpHeaders().set('Content-Type', 'application/x-www-form-urlencoded')
    };
    return this.http.post<string>(this.getFullUri('resetpassword'), body.toString(), options);
  }

  getFullUri(action: string): string {
    return this.SmtUri + action;
  }

  logout() {
    localStorage.removeItem(this.TOKEN_KEY);
  }

  isLoggedIn() {
    if (this.getToken() !== null) {
      return true;
    }
    return false;
  }

  getToken() {
    return localStorage.getItem(this.TOKEN_KEY);
  }
}
