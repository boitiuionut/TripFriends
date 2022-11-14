import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';


@Component({
    selector: 'contact-page',
    templateUrl: './contactpage.component.html',
    styleUrls: ['../app.component.css']
})

export class ContactPageComponent implements OnInit
{
    constructor (
        private router: Router
    ) { }

    ngOnInit(){
    }
}