import { Component } from '@angular/core';
import { Employee } from '../models/employee';

@Component({
    selector: 'employees-list',
    templateUrl: '../Views/employees-list.component.html'

})
export class EmployeeListComponent {
    pageTitle: string = "Syn's Employee List";
    subTitle: string = "have fun.. hello world is old.. say wassap world";
    imgWidth: string = "75px";
    imgHeight: string = "50px";
    //  employee: Employee;
    selectedEmployee: Employee;

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
    childMsg: string = "";
    recievedNotification(msg: string): void {
        this.childMsg = msg;

    }
    getSelectedEmployee(employee: Employee): void {
        this.selectedEmployee = employee;
    }

    employees: Employee[] = [
        {
            employeeId: 12940,
            employeeName: "Siddharth Gupta",
            address: "Aundh",
            city: "Pune",
            contactNumber: "+91 9911911680",
            email: "sid@syn.com",
            photo: "images/photo1.png"
        },
        {
            employeeId: 12456,
            employeeName: "Sridhar",
            address: "Pune",
            city: "Pune-city",
            contactNumber: "+91 9823323336",
            email: "Sridhar@syn.com",
            photo: "images/photo1.png"
        },
        {
            employeeId: 12789,
            employeeName: "Amit",
            address: "Pune",
            city: "Pune-city",
            contactNumber: "+91 7757008884",
            email: "amit@syn.com",
            photo: "images/photo1.png"
        },
        {
            employeeId: 12789,
            employeeName: "Amit",
            address: "Pune",
            city: "Pune-city",
            contactNumber: "+91 123456789",
            email: "amit@syn.com",
            photo: "images/photo1.png"
        },
        {
            employeeId: 12456,
            employeeName: "Sridhar",
            address: "Pune",
            city: "Pune-city",
            contactNumber: "+91 9999628708",
            email: "Sridhar@syn.com",
            photo: "images/photo1.png"
        }

    ];
}