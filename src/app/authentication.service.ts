import { Injectable } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { map } from 'rxjs/operators';
import { Router } from '@angular/router';
import { HttpHeaders, HttpClient } from '@angular/common/http';

@Injectable()
export class AuthenticationService {
    public token: string;
    public serviceBase: string;
    public username: string;
    public userId: number;

    constructor(
        private http: Http,
        private router: Router,
        private httpClient: HttpClient
    ) {
        this.serviceBase = "http://localhost:58588/";
    }

    _login(loginData: any) {
        var data = "grant_type=password&username=" + loginData.username + "&password=" + loginData.password;
        var headers = new Headers();
        headers.append('Content-type', 'application/x-www-form-urlencoded');

        return this.http.post(this.serviceBase + 'token', data, { headers: headers })
            .pipe(map(res => res.json()));
    }

    _logout(): void {
        // clear token to log user out
        this.token = null;
        this.username = null;
        this.router.navigateByUrl('/');
        console.log("Successfully logged out.");
    }

    _register(registerModel: any) {
        var route = "api/Account/Register";
        var headers = { headers: new HttpHeaders() };
        headers.headers.append('Access-Control-Allow-Origin', '*');
        headers.headers.append('Content-Type', 'application/json');
        return this.httpClient.post(this.serviceBase + route, registerModel, headers);
    }
}