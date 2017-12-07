import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'home',
    templateUrl: '../views/home.component.html'
})

export class HomeComponent implements OnInit {
    constructor() { }
    pageTitle: string = "Synechron Home Page";
    ngOnInit() { }
}