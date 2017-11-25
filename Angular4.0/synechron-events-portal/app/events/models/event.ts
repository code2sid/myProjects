import { IEvent } from './ievent';

export class Event implements IEvent {
        public eventId: number;
        public eventCode: string;
        public eventName: string;
        public desc: string;
        public strtDate: Date;
        public endDate: Date;
        public fees: number;
        public attendance: number;
        public logo: string;
}