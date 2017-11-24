import { IEmployee } from './iemployee';
export class Employee implements IEmployee {
    employeeId: number;
    employeeName: string;
    address:string;
    city: string;
    contactNumber: string;
    email: string;
    photo:string;
}