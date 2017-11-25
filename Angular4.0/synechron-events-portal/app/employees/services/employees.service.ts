import { Injectable } from '@angular/core';
import { Employee } from '../models/employee';

@Injectable()

export class EmployeesService {
    getAllEmployees(): Employee[] {
        return this.employeesData;
    }

    getSingleEmployee(id: number): Employee {
        let employee:Employee=new Employee();
        for (let emp of this.employeesData) {
            if (emp.employeeId == id)
            employee = emp;
        }
                return employee;

    }
    private employeesData: Employee[] = [
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
    ]
}