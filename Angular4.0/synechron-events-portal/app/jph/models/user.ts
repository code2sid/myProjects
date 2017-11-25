import { address } from './address';
import { company } from './company';

export class User {
    name: string;
    emailId: string;
    phone: string;
    address: address;
    company: company;
    website: string;
}