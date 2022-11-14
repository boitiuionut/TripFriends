import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';


@Component({
    selector: 'info-page',
    templateUrl: './about.component.html',
    styleUrls: ['../app.component.css']
})

export class InfoPageComponent implements OnInit
{
    constructor (
        private router: Router
    ) { }

    ngOnInit(){
    }
}