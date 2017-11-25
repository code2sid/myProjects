import { Component, OnInit } from '@angular/core'
import { Post } from '../models/post'
import { JphPostService } from '../services/jph-posts.service'

@Component({
    selector: 'jph-post-list',
    templateUrl: '../views/jph-posts-list.components.html'

})

export class JphpostListComponent implements OnInit {
    pageTitle: string = "json Place Holder API data !!!";
    posts: Post[]=[];
    constructor(private _postService: JphPostService) {

    }
    ngOnInit(): void {
        this._postService.getAllPosts().subscribe(
            data => this.posts = data,
            error => console.log(error), //logger service
            () => console.log("Service call complete !!")

        );

    }

}