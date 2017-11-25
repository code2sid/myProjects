import { IEvent } from './ievent';

export class Event implements IEvent {
        public eventId: number;
        public eventCode: string;
        public eventName: string;
        public description: string;
        public startDate: Date;
        public endDate: Date;
        public fees: number;
        public attendace: number;
        public logi: string;
}