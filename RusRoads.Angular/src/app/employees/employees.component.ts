import { Component, inject, OnInit } from '@angular/core';
import { Employee } from '../../interfaces/employee';
import { Observable, switchMap, tap } from 'rxjs';
import { SubdivisionService } from '../../Services/subdivision.service';
import { EmployeeComponent } from "../employee/employee.component";
import {MatIconModule} from '@angular/material/icon'
import { CommonModule } from '@angular/common';
import { MatDialog, MatDialogModule} from '@angular/material/dialog'
import { AddEmployeeDialogComponent } from '../add-employee-dialog/add-employee-dialog.component';
import { EmpService } from '../../Services/emp.service';
import { EditEmployeeDialogComponent } from '../edit-employee-dialog/edit-employee-dialog.component';


@Component({
  selector: 'app-employees',
  imports: [EmployeeComponent, CommonModule, MatIconModule, MatDialogModule],
  templateUrl: './employees.component.html',
  styleUrl: './employees.component.css'
})
export class EmployeesComponent implements OnInit {
  
  
  subService = inject(SubdivisionService)
  empService = inject(EmpService)

  employees: Employee[] = []
  currentEmployees: Employee[] = []
  currentSubId!: number

  dialog = inject(MatDialog)

  ngOnInit(): void {
    this.subService.currentSubId$.subscribe(r =>{ 
    this.currentSubId = r
    this.subService.GetEmpBySubAll(r).subscribe( e => {
      this.currentEmployees = e;
      console.log(e)})
    this.subService.employeeAll$.subscribe( r => this.employees = r)
    })
  }

  addEmployee()
  {
    const dialogRef = this.dialog.open(
      AddEmployeeDialogComponent,
      {data:[this.currentEmployees,this.currentSubId], autoFocus:true, height:'auto', width:"50%", maxHeight:'100vw'}
    );

    dialogRef.afterClosed().subscribe(result => {
      if(result && result as Employee){
        result.subdivision = null
        this.empService.create(result).subscribe(next => {
          console.log("создание сотрудника : "+ result)},
          error => {console.log(error.message)}

      )}
      this.subService.currentSubId$.next(result.subdivision_id)
      this.subService.GetEmpBySubAll(result.subdivision_id).subscribe(r => {this.employees = r;
        console.log(this.employees)
        this.subService.employeeAll$.next(this.employees)
      })
  })
  }

  dismissEmployee($event: any)
  {
    $event.subdivision = null
     this.empService.dismiss($event).pipe(
      tap((r) => console.log("Сотрудник уволен: ", $event.fio)),
      switchMap(() => this.subService.GetEmpBySubAll(this.currentSubId))
     )
     .subscribe( e => this.subService.employeeAll$.next(this.employees)) 
      this.subService.currentSubId$.next($event.subdivision_id)
      this.subService.GetEmpBySubAll($event.subdivision_id).subscribe(r => {this.employees = r;
        console.log(this.employees)
        this.subService.employeeAll$.next(this.employees)
      })
  }

  editEmployee($event: any)
  {

    $event.date_born = $event.date_born.toString().split('T')[0]
    const dialogRef = this.dialog.open(
        EditEmployeeDialogComponent,
        {data:[this.currentEmployees,$event,false], autoFocus:true, width:"100%", maxWidth: "98%", height:"auto" })

      dialogRef.afterClosed().subscribe( r => {
      if(r && r as Employee)
      {  
        r.subdivision = null
        this.empService.update(r).subscribe(next => {
          console.log(r)},
          error => console.log(error.message) )
      }
      }
    )
  }

}

