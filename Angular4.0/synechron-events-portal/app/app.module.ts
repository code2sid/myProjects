import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import {EmployeeListComponent} from './employees/components/employee-list.component';
import {EmployeeDetailsComponent} from './employees/components/employee-details.component';
import {EventListComponent} from './events/components/event-list.component';
import {EventDetailsComponent} from './events/components/event-details.component';

@NgModule({
    imports: [BrowserModule],//Built-in or Custom Modules list
    declarations: [AppComponent,EmployeeListComponent,EmployeeDetailsComponent,EventListComponent,EventDetailsComponent],
    exports: [],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule {

}