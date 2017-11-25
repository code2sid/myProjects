import { Injectable } from '@angular/core'
import { Http } from '@angular/http'
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';

import { User } from '../models/user'

@Injectable()
export class JphUserService {
    constructor(private _http: Http) {

    }

    getAllUsers(): Observable<User[]> {
        return this._http.get("https://jsonplaceholder.typicode.com/users").map
            (res => res.json());
    }
}