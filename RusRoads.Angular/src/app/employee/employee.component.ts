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
  classMode:string = "empGraph"

  checkDismissDateEmp(emp: Employee): boolean{
    if(this.graphMode)
      this.classMode = "empGraph"
    else
     this.classMode = "empHome"

    if(emp == null || emp.dismiss_date == null)
      return true
    const dismissDate = new Date(emp.dismiss_date)

    dismissDate.setDate(dismissDate.getDate() + 30)
    
    return dismissDate < new Date() ? false:true
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
    if(this.isQRCodeShow)
      return true
    else
      return false
  }
}
