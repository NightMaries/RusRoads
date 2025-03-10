import { CommonModule } from '@angular/common';
import { Component, inject, Input, input, OnInit } from '@angular/core';
import { FormsModule, NgForm, NgModel } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialog, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { SubdivisionService } from '../../Services/subdivision.service';
import { Subdivision } from '../../interfaces/subdivision';
import { Employee } from '../../interfaces/employee';
import { MatIconModule } from '@angular/material/icon';
import { Event } from '../../interfaces/event';
import { EventService } from '../../Services/event.service';
import { map, tap } from 'rxjs';

@Component({
  selector: 'app-add-employee-dialog',
  imports: [FormsModule, MatDialogModule, CommonModule, MatIconModule],
  templateUrl: './add-employee-dialog.component.html',
  styleUrl: './add-employee-dialog.component.css'
})
export class AddEmployeeDialogComponent implements OnInit {
  

  subService = inject(SubdivisionService)
  eventService = inject(EventService)
  
  dialogRef = inject(MatDialogRef<AddEmployeeDialogComponent>)
  data = inject<any[]>(MAT_DIALOG_DATA)
  
  addMode:boolean = true


  is_old: boolean = false;
  is_current: boolean = true;
  is_future: boolean = true;


  currentEmp : Employee = {
    id: 0,
    fio: '',
    date_born: new Date('2020-11-01'),
    cabinet:'',
    job_number:'',
    email: '',
    position: '',
    subdivision_id: this.data[1],
    subdivision:
      {
        id: 0,
        name: '',
        leader_subdivision_id: 0 
      },
    leader_id: null,
    helper_id: null,
    personal_phone:'',
    dismiss_date: null
  }


  editMode:boolean = false
  events: Event[] = []
  isVisibleAddEvent:boolean = false
  currentEvent:Event = {
    id:0,
    date_start: new Date(),
    date_end: new Date(),
    event_type_id: null,
    description: '',
    employee_id: this.currentEmp.id
  }

  subdivisions:Subdivision[] = []
  
  ngOnInit(): void {
    
    this.subService.GetSubdivisionAll().subscribe(r => this.subdivisions = r)
    this.addMode = this.data[2]
    
  if(this.data[1] !== null)
    this.currentEmp == this.data[1]
  }
  ok(){
    console.log("Передан сотруник ",this.currentEmp)
    
    this.dialogRef.close(this.currentEmp)
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

