import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { RequestsService } from '../requests.service';
import { AuthenticationService } from '../authentication.service';
import { NotifierService } from 'angular-notifier';

@Component({
    selector: 'main-page',
    templateUrl: './mainpage.component.html',
    styleUrls: ['../app.component.css']
})

export class MainPageComponent
{
    registerModel = { 
      nume: "",
      prenume:"",
      telefon:"",
      email:"",
      username:"",
      password:"",
      confirmPassword:""
    };

    loginData = {
        username: "",
        password: ""
      };

    constructor (
        private router: Router,
        private requests: RequestsService,
        private authenticationService: AuthenticationService,
        private notifier: NotifierService
    ) { }

    flag: boolean = true;

    goToRoute(route: string) {
        this.router.navigateByUrl('/' + route);
    }

    switchFlag(){
        this.flag = !this.flag;
    }

    clearRegister() {
      this.registerModel = { 
        nume: "",
        prenume:"",
        telefon:"",
        email:"",
        username:"",
        password:"",
        confirmPassword:""
      };
    }
    
    clearLogin() {
      this.loginData = {
        username: "",
        password: ""
      };
    }
    //metoda folosita pentru inregistrare. Se face post in baza de date pentru a salva informatiile utilizatorului.
    //Username-ul si parola sunt stocate in alta baza de date, pentru siguranta. La momentul logarii, acea baza se verifica daca are informatiile utilizatorului salvate.
    register() {
      if (this.registerModel.nume == "" || this.registerModel.prenume == "" || this.registerModel.telefon == "" || this.registerModel.email == ""
          || this.registerModel.username == "" || this.registerModel.password == "" || this.registerModel.confirmPassword == "") {
            this.notifier.notify("warning", "The present fields are mandatory!");
            return;
      }

      if (this.registerModel.password.length < 6) {
        this.notifier.notify("warning", "The password must contain 6 characters minimum!");
        return;
      }
      
      if (this.registerModel.password != this.registerModel.confirmPassword) {
        this.notifier.notify("error", "The password and password confirmation don't match!");
        return;
      }

        this.authenticationService._register(this.registerModel).subscribe(data => {
            this.clearRegister();
            this.flag = true;
            this.notifier.notify("success","Your registration succeeded!");
          }, error => {
            this.notifier.notify("error", "Your registration didn't succeed! Please, try once again!");
          }, () => {
          });
      }

    login() {
        //If no credentials are entered show alert
        if (this.loginData.username === '' || this.loginData.password === '') {
          this.notifier.notify("warning", "Fill the username and the password!");
        } else {
            //If authentication is successful then login
            this.authenticationService._login(this.loginData).subscribe(res => {
              this.authenticationService.token = res.token_type + ' ' + res.access_token;
              this.authenticationService.username = this.loginData.username;
              this.router.navigateByUrl('/userhome-page');
            }, err => {
              this.notifier.notify("error", "Inexistent user or incorrect password!");
              this.clearLogin();
            }, () => {
            });
        }
      }
}