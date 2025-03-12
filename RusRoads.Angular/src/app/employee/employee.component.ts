import { Component, EventEmitter, input, Input, Output, output } from '@angular/core';
import { Employee } from '../../interfaces/employee';
import { CommonModule } from '@angular/common';
import { MatIcon } from '@angular/material/icon';
import {QRCodeComponent} from 'angularx-qrcode'

@Component({
  selector: 'app-employee',
  imports: [CommonModule, MatIcon, QRCodeComponent],
  templateUrl: './employee.component.html',
  styleUrl: './employee.component.css'
})
export class EmployeeComponent {
showQRCode() {
throw new Error('Method not implemented.');
}

  @Output()
  selectEmployee: EventEmitter<Employee> = new  EventEmitter<Employee>()
  
  @Output()
  dismissEmployee: EventEmitter<Employee> = new EventEmitter<Employee>()

  @Input()
  employee!: Employee

  @Input()
  graphMode: boolean = true
  isQRCodeShow:boolean = false
  qrData:string =""
  classMode:string = "emp"
  lastName:string=""
  firstName:string = ""
  

  checkDismissDateEmp(emp: Employee): boolean{
    if(this.graphMode)
      this.classMode = "emp"
    else
     this.classMode = "empHome"

    if(emp == null || emp.dismiss_date == null)
      return true
    const dismissDate = new Date(emp.dismiss_date)

    dismissDate.setDate(dismissDate.getDate() + 30)
    
    return dismissDate < new Date() ? false:true
  }

  
  getVCardQr(emp:Employee):string{
    this.splitFIO(emp.fio)
    return `BEGIN:VCARD
VERSION:3.0
N:${this.firstName}
FN:${this.lastName}
ORG:\t${emp.subdivision?.name}
TITLE:${emp.position}
TEL;WORK;VOICE:${emp.job_number}
TEL;CELL:${emp.personal_phone}
EMAIL;WORK;INTERNET:${emp.email}
END:VCARD`  
  }

  splitFIO(FIO:string){
    const parts = FIO.trim().split(/\s+/);
    this.firstName = parts[0] || ''
    this.lastName = parts[1] || ''
  }

  getEmp(employee:Employee)
  {
    this.selectEmployee.emit(employee)
  }
  dismissEmp(employee: Employee) {
    this.employee.subdivision = null
    this.dismissEmployee.emit(employee)
  }
  toogleCode(){
    this.isQRCodeShow = !this.isQRCodeShow
    return this.isQRCodeShow ? true :false
  }
}
