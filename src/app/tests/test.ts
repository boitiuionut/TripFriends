import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from '../authentication.service';

@Component({
    selector: 'test-page',
    templateUrl: './test.html',
    styleUrls: ['../app.component.css']
})

export class TestComponent implements OnInit
{
    constructor (
        private router: Router,
        private authenticationService: AuthenticationService
    ) { }

    ngOnInit(){
        if(!this.authenticationService.token) {
            this.router.navigateByUrl("/");
            return;
        }
    }

    logout() {
        this.authenticationService._logout();
    }
}