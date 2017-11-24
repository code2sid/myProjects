import { Component, Input } from '@angular/core';
import { Event } from '../models/event';

@Component({
    selector: 'event-details',
    templateUrl: '../views/event-details.component.html'
})



export class EventDetailsComponent {
    pageTitle: string = "Details of Event - ";
    @Input("currentEvent") event: Event;


}