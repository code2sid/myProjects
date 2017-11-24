import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

//components
import { AppComponent } from './app.component';
import { EmployeeListComponent } from './employees/components/employee-list.component';
import { EmployeeDetailsComponent } from './employees/components/employee-details.component';
import { EventListComponent } from './events/components/event-list.component';
import { EventDetailsComponent } from './events/components/event-details.component';

//pipes
import { FirstLetterCapitalPipe } from './events/pipes/first-letter-capital.pipes';
import { EventsFiterPipe } from './events/pipes/events-filter.pipe'

@NgModule({
    imports: [BrowserModule, FormsModule],//Built-in or Custom Modules list
    declarations: [AppComponent, EmployeeListComponent, EmployeeDetailsComponent, EventListComponent,
        EventDetailsComponent, FirstLetterCapitalPipe, EventsFiterPipe],
    exports: [],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule {

}