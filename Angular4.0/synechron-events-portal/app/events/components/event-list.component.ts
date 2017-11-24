import { Component } from '@angular/core';
import { Event } from '../models/event';

@Component({
    selector: 'events-list',
    templateUrl: '../views/event-list.component.html'

})

export class EventListComponent {
    pageTitle: string = "Events List";
    subTitle: string = "Published by Sid";
    imgWidth: string = "75px";
    imgHeight: string = "50px";
    selectedEvent: Event;
     getSelectedEvent(event: Event): void {
        this.selectedEvent = event;
    }
    events: Event[] = [
        {
            eventId: 101,
            eventCode: 'JQ3SEM',
            eventName: 'jQuery 3.x Seminar',
            desc: 'Discussion abt new features in jQuery 3.x',
            strtDate: new Date('12/12/2017'),
            endDate: new Date('12/12/2017'),
            fees: 100,
            attendance: 89,
            logo: 'images/jq3.png'
        },
        {
            eventId: 102,
            eventCode: 'ng4.0SEM',
            eventName: 'Angular 4.0 Seminar',
            desc: 'Discussion abt new features in Angular 4.0',
            strtDate: new Date('12/12/2017'),
            endDate: new Date('12/12/2017'),
            fees: 20,
            attendance: 30,
            logo: 'images/ng4.png'
        },
        {
            eventId: 103,
            eventCode: 'bootstrapSEM',
            eventName: 'BootStrap  Seminar',
            desc: 'Discussion abt BootStrap',
            strtDate: new Date('12/12/2017'),
            endDate: new Date('12/12/2017'),
            fees: 50,
            attendance: 50,
            logo: 'images/bs.png'
        },
        {
            eventId: 104,
            eventCode: 'C#Sem',
            eventName: 'C#  Seminar',
            desc: 'Discussion abt C# and its new features',
            strtDate: new Date('12/12/2017'),
            endDate: new Date('12/12/2017'),
            fees: 500,
            attendance: 20,
            logo: 'images/cs.png'
        }
    ];


}