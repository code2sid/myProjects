import { Injectable } from '@angular/core'
import { Http } from '@angular/http'
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';

import { Post } from '../models/post'

@Injectable()
export class JphPostService {
    constructor(private _http: Http) {

    }

    getAllPosts():Observable<Post[]> {
       return  this._http.get("https://jsonplaceholder.typicode.com/posts").map
        (res=>res.json());
    }
}