import { AfterViewInit, ChangeDetectorRef, Component, inject, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { DateAdapter } from '@angular/material/core';
import {MatCalendar, MatCalendarCellClassFunction, MatDatepickerModule} from "@angular/material/datepicker"
import { RssService } from '../../Services/rss.service';
import { BehaviorSubject, map, tap } from 'rxjs';
import { Event } from '../../interfaces/event';
import { EventService } from '../../Services/event.service';
import { Employee } from '../../interfaces/employee';
import { EmpService } from '../../Services/emp.service';
import {MatTooltipModule} from '@angular/material/tooltip'
import { CommonModule } from '@angular/common';
import { WorkingCalendar } from '../../interfaces/workingCalendar';
import { AppService } from '../../../app.service';

@Component({
  selector: 'app-calendar',
  imports: [ MatTooltipModule, MatCalendar, CommonModule],
  templateUrl: './calendar.component.html',
  styleUrl: './calendar.component.css',
  encapsulation: ViewEncapsulation.None
})
export class CalendarComponent implements AfterViewInit {


  events: Event [] = []
  employees: Employee []=[]

  workingCal: WorkingCalendar[] = []
  empService = inject(EmpService)
  eventService= inject(EventService)
  rssService = inject(RssService)
  eventLoaded:boolean = false
  
  ngAfterViewInit(): void {
    
    this.empService.getAll().subscribe(r =>{ console.log(r), this.employees = r.map(e => ({
      ...e,
      date_born: new Date(e.date_born)
      })
    )
  })
  this.eventService.getWorkingCal().subscribe(r =>{
    this.workingCal = r.map(w => ({
      ...w,
      exception_date: new Date(w.exception_date)
    }))
  },e => console.log(e))

  
    this.eventService.getAllEvents().subscribe(
      (r) => {
        this.events = r.map(e => ({...e, date_start: new Date(e.date_start)}) )
        this.eventLoaded = true
    })

  }
  
  dateClass= (date :Date):string =>
  {
    let hasBirthday = false;
    let counterEvents = 0
    let highlightDay = false

    this.workingCal.forEach( w => {
      console.log(w.exception_date)
      if(w.exception_date.getDate() == date.getDate() &&
         w.exception_date.getMonth() == date.getMonth() &&
         w.exception_date.getFullYear () == date.getFullYear())
          highlightDay = true 
    })
    this.employees.forEach(e => 
      {
        if(e.date_born.getDate() === date.getDate()&&
          e.date_born.getMonth() === date.getMonth()&&
          e.date_born.getFullYear() === date.getFullYear())
            {
              hasBirthday = true
            }
    })
    if(date.getDay() == 0 ||date.getDay() == 6 )
      highlightDay = true
    
    this.events.forEach(e =>{
    if(e.date_start.getDate() === date.getDate()&&
       e.date_start.getMonth() === date.getMonth()&&
       e.date_start.getFullYear() === date.getFullYear())
       {counterEvents ++
        console.log('counter: '+counterEvents)
      }})


      if (counterEvents >= 5) return 'redClass';  
      if (counterEvents < 2 && counterEvents != 0) return 'greenClass'; 
      if (counterEvents >= 2 && counterEvents <= 4) return 'yellowClass'; 
 
      return hasBirthday ? 'image-date' : highlightDay ? 'highlight-day' : '';
      
  }
}

  

