import { DialogModule } from '@angular/cdk/dialog';
import { CommonModule } from '@angular/common';
import { AfterViewInit, Component, inject, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, NgForm } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialog, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { SubdivisionService } from '../../Services/subdivision.service';
import { EmpService } from '../../Services/emp.service';
import { Employee } from '../../interfaces/employee';
import { Subdivision } from '../../interfaces/subdivision';
import { MatIcon } from '@angular/material/icon';
import {MatCheckboxModule} from '@angular/material/checkbox'
import { Event } from '../../interfaces/event';
import { EventService } from '../../Services/event.service';
import { map, tap } from 'rxjs';

@Component({
  selector: 'app-edit-employee-dialog',
  imports: [MatDialogModule,FormsModule, CommonModule, MatIcon, MatCheckboxModule],
  templateUrl: './edit-employee-dialog.component.html',
  styleUrl: './edit-employee-dialog.component.css'
})
export class EditEmployeeDialogComponent implements AfterViewInit{

  
  
  is_old: boolean = false;
  is_current: boolean = true;
  is_future: boolean = true;

  subService = inject(SubdivisionService)
  empservice = inject(EmpService)
  dialogRef = inject(MatDialogRef<EditEmployeeDialogComponent>)
  eventService = inject(EventService)
  data = inject<any[]>(MAT_DIALOG_DATA)
  @ViewChild('empForm') empForm!: NgForm;
  
  
  
  subdivisions:Subdivision[] = []
  
  editMode:boolean = false
  events: Event[] = []
  isVisibleAddEvent:boolean = false
 
  
  currentEmp:Employee= this.data[1]
  currentEvent:Event = {
    id:0,
    date_start: new Date(),
    date_end: new Date(),
    event_type_id: null,
    description: '',
    employee_id: this.currentEmp.id
  }
  
  ngAfterViewInit(): void {
    setTimeout(() => {
      if (this.empForm) {
        this.empForm.form.disable();
      }})

    this.empForm.form.disable()
    this.subService.GetSubdivisionAll().subscribe( r => 
      this.subdivisions = r
    )
    
    this.eventService.getEmpEvent(this.currentEmp.id,this.is_old,this.is_current,this.is_future).pipe(
      tap((r) => console.log(r)),
      map((r) => this.events = r),
    ).subscribe()

  }
  EditModeToogle()
  {
    this.editMode = !this.editMode
    if(this.editMode)
      this.empForm.form.enable()
    else  
      this.empForm.form.disable()
  }
  ok(){
    if(this.empForm.valid){
      this.currentEmp  = {...this.currentEmp, ...this.empForm.value}
      console.log("Передан сотруник ",this.data)
      this.dialogRef.close(this.currentEmp)}
    else
      this.dialogRef.close()
  }
  cancel()
  {
    this.dialogRef.close()
  }
  visibleAddEventToogle()
  {
    this.isVisibleAddEvent = !this.isVisibleAddEvent
  }
  filterEvents() {
    console.log(this.is_old,this.is_current, this.is_future)
    this.eventService.getEmpEvent(this.currentEmp.id,this.is_old, this.is_current, this.is_future).pipe(
      tap((r) => console.log(r)),
      map((r) => this.events = r)
    ).subscribe() 
    console.log(this.events)
  }
  
  createEvent() {
    console.log(this.currentEvent)
    this.eventService.createEvent(this.currentEvent).subscribe(
      r => console.log(r),
      e => console.log(e)
    )
  }
  deleteEvent($event: Event) {
    this.eventService.deleteEvent($event.id).subscribe(
      r => console.log(r),
      e => console.log(e)
    )
    
  }
}
