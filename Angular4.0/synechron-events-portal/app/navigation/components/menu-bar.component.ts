import { Component } from '@angular/core';

@Component({
    selector: 'menu-bar',
    templateUrl: '../views/menu-bar.component.html'
})

export class MenubarComponent {
    constructor(){


    }
    brand: string = "../images/logo.png";
    menus: string[] = [
        "HOME", "EVENTS", "JPH POSTS", "JPH USERS", "EMPLOYEES", "LOGIN", "REGISTER"
    ];

}