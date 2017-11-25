import { Component, OnInit } from '@angular/core';
import { Event } from '../models/event';
import { EventService } from '../services/events.service';

@Component({
    selector: 'events-list',
    templateUrl: '../views/event-list.component.html'

})

export class EventListComponent implements OnInit {
    pageTitle: string = "Events List";
    subTitle: string = "Published by Sid";
    imgWidth: string = "75px";
    imgHeight: string = "50px";
    selectedEvent: Event;
    events:Event[];

    getSelectedEvent(eventId: number): void {
        this.selectedEvent = this._eventsService.getSingleEvent(eventId);
    }

    constructor (private _eventsService:EventService){


    }
 ngOnInit(): void{

     this.events = this._eventsService.getAllEvents();
 }

}