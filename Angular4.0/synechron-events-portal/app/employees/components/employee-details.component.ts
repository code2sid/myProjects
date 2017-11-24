import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Employee } from '../models/employee';

@Component({
    selector: 'employee-details',
    templateUrl: '../views/employee-details.component.html'

})




export class EmployeeDetailsComponent {
    pageTitle: string = "Details of - ";
    @Output() confirmationMsg: EventEmitter<string> = new EventEmitter<string>();
    @Input("currentEmployee") employee: Employee;
    
    raiseCustomConfirmation(): void {

        this.confirmationMsg.emit("Recieved data successfully !!!");
    }
    constructor() {
        // this.employee = new Employee();
        // this.employee.employeeId = 12940;
        // this.employee.employeeName = "Siddharth Gupta";
        // this.employee.address = "Aundh";
        // this.employee.city = "Pune";
        // this.employee.contactNumber = "+91 9911911680";
        // this.employee.email = "sid@syn.com";
        // this.employee.photo = "images/photo1.png";

    }
}