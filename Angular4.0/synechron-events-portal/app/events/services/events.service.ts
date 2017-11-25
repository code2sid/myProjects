import { Injectable } from '@angular/core';
import { Http } from '@angular/http'
import { Observable } from 'rxjs'
import 'rxjs/add/operator/map';

import { Event } from '../models/event';

@Injectable()

export class EventService {
    constructor(private _http: Http) {

    }

    getAllEvents(): Observable<Event[]> {
        return this._http.get("http://localhost:9090/api/events").map(res => res.json());
    }

    getSingleEvent(id: number): Observable<Event> {
        return this._http.get("http://localhost:9090/api/events/" + id).map(res => res.json());

    }

    eventsData: Event[] = [
        {
            eventId: 101,
            eventCode: 'JQ3SEM',
            eventName: 'jQuery 3.x Seminar',
            description: 'Discussion abt new features in jQuery 3.x',
            startDate: new Date('12/12/2017'),
            endDate: new Date('12/12/2017'),
            fees: 100,
            attendace: 89,
            logi: 'images/jq3.png'
        },
        {
            eventId: 102,
            eventCode: 'ng4.0SEM',
            eventName: 'Angular 4.0 Seminar',
            description: 'Discussion abt new features in Angular 4.0',
            startDate: new Date('12/12/2017'),
            endDate: new Date('12/12/2017'),
            fees: 20,
            attendace: 30,
            logi: 'images/ng4.png'
        },
        {
            eventId: 103,
            eventCode: 'bootstrapSEM',
            eventName: 'BootStrap  Seminar',
            description: 'Discussion abt BootStrap',
            startDate: new Date('12/12/2017'),
            endDate: new Date('12/12/2017'),
            fees: 50,
            attendace: 50,
            logi: 'images/bs.png'
        },
        {
            eventId: 104,
            eventCode: 'C#Sem',
            eventName: 'C#  Seminar',
            description: 'Discussion abt C# and its new features',
            startDate: new Date('12/12/2017'),
            endDate: new Date('12/12/2017'),
            fees: 500,
            attendace: 20,
            logi: 'images/cs.png'
        }
    ];

}