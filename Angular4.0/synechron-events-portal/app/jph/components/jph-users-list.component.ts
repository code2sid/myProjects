import { Component, OnInit } from '@angular/core'
import { User } from '../models/user'
import { JphUserService } from '../services/jhp-user.service'

@Component({
    selector: 'jph-user-list',
    templateUrl: '../views/jhp-users-list.component.html'

})

export class JphuserListComponent implements OnInit {
    pageTitle: string = "json Place Holder API data !!!";
    users: User[]=[];
    constructor(private _userService: JphUserService) {

    }
    ngOnInit(): void {
        this._userService.getAllUsers().subscribe(
            data => this.users = data,
            error => console.log(error), //logger service
            () => console.log("Service call complete !!")

        );

    }

}