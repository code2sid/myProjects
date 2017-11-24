import { Component } from '@angular/core';

@Component({
    selector: 'my-app',
    // template:`<h1>Welcome To Webpack Example!</h1>
    //             <hr>
    //             <h5>Core Development Center</h5>`
    templateUrl: 'app.component.html'
})
export class AppComponent {
    pageTitle: string = "Welcome Synechron Events Portal";
    subTitle: string = "Maintained and Published by Hr Team!";
}