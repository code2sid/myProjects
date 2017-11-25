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
    events: Event[];

    getSelectedEvent(eventId: number): void {
        this._eventsService.getSingleEvent(eventId).subscribe(
            data => this.selectedEvent = data,
            err => console.log(err),
            () => console.log("Event Service call completed !!")

        );
    }

    constructor(private _eventsService: EventService) {


    }
    ngOnInit(): void {

        this._eventsService.getAllEvents().subscribe(
            data => this.events = data,
            err => console.log(err),
            () => console.log("Event Service call completed !! ")
        );
    }

}