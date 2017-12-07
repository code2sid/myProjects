import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';


// services
import { EmployeesService } from './employees/services/employees.service';
import { EventService } from './events/services/events.service';
import { JphPostService } from './jph/services/jph-posts.service';
import { JphUserService } from './jph/services/jhp-user.service';
//components
import { AppComponent } from './app.component';
import { EmployeeListComponent } from './employees/components/employee-list.component';
import { EmployeeDetailsComponent } from './employees/components/employee-details.component';
import { EventListComponent } from './events/components/event-list.component';
import { EventDetailsComponent } from './events/components/event-details.component';
import { JphpostListComponent } from './jph/components/jph-posts-list.components';
import { JphuserListComponent } from './jph/components/jph-users-list.component';
import { MenubarComponent } from './navigation/components/menu-bar.component';
import { FooterComponent } from './navigation/components/footer.component';
import { HomeComponent } from './home/components/home.component';

//pipes
import { FirstLetterCapitalPipe } from './events/pipes/first-letter-capital.pipes';
import { EventsFiterPipe } from './events/pipes/events-filter.pipe'

@NgModule({
    imports: [BrowserModule, FormsModule, HttpModule],//Built-in or Custom Modules list
    declarations: [AppComponent, EmployeeListComponent, EmployeeDetailsComponent, EventListComponent,
        EventDetailsComponent, FirstLetterCapitalPipe, EventsFiterPipe, JphpostListComponent,
        JphuserListComponent, MenubarComponent, FooterComponent, HomeComponent],
    exports: [],
    providers: [EmployeesService, EventService, JphPostService, JphUserService],
    bootstrap: [AppComponent]
})
export class AppModule {

}