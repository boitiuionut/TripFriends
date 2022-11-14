import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AuthenticationService } from './authentication.service';

@Injectable()
export class RequestsService {

  constructor(
    public http: HttpClient,
    private auth: AuthenticationService
    ) {
  }
//portul de dupa localhost e cel pe care ruleaza aplicatia de c#
  serviceBase = "http://localhost:58588/"

  get(route: string) {
    var headers = { headers: new HttpHeaders() };
    headers.headers.append('Accept', 'application/json');
    headers.headers.append('Content-Type', 'application/json');
    headers.headers.append('Access-Control-Allow-Origin', '*');
    headers.headers.append('Authorization', this.auth.token);
    return this.http.get(this.serviceBase + route,headers);
  }

  post(route: string, model: any) {
    var headers = { headers: new HttpHeaders() };
    headers.headers.append('Access-Control-Allow-Origin', '*');
    headers.headers.append('Content-Type', 'application/json');
    headers.headers.append('Authorization', this.auth.token);
    return this.http.post(this.serviceBase + route, model, headers);
  }

  put(route: string, model: any) {
    var headers = { headers: new HttpHeaders() };
    headers.headers.append('Content-Type', 'application/json');
    headers.headers.append('Access-Control-Allow-Origin', '*');
    headers.headers.append('Authorization', this.auth.token);
    return this.http.put(this.serviceBase + route, model, headers);
  }

  delete(route: string) {
    var headers = { headers: new HttpHeaders() };
    headers.headers.append('Accept', 'application/json');
    headers.headers.append('Content-type', 'application/json');
    headers.headers.append('Access-Control-Allow-Origin', '*');
    headers.headers.append('Authorization', this.auth.token);
    return this.http.delete(this.serviceBase + route, headers);
  }
}