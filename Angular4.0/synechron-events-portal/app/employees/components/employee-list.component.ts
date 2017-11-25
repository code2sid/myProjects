import { Component, OnInit } from '@angular/core';
import { Employee } from '../models/employee';
import { EmployeesService } from '../services/employees.service'

@Component({
    selector: 'employees-list',
    templateUrl: '../Views/employees-list.component.html'

})
export class EmployeeListComponent implements OnInit {
    pageTitle: string = "Syn's Employee List";
    subTitle: string = "have fun.. hello world is old.. say wassap world";
    imgWidth: string = "75px";
    imgHeight: string = "50px";
    //  employee: Employee;
    selectedEmployee: Employee;
    constructor(private _employeeService: EmployeesService) {
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
    getSelectedEmployee(employeeId: number): void {
        this.selectedEmployee = this._employeeService.getSingleEmployee(employeeId);
    }

    ngOnInit(): void {
        this.employees = this._employeeService.getAllEmployees();
    }

    employees: Employee[] = [
        // 

    ];
}