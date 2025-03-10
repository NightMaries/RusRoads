import { AfterViewInit, ChangeDetectorRef, Component, inject, OnInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { DateAdapter } from '@angular/material/core';
import {MatCalendar, MatCalendarCellClassFunction, MatDatepickerModule} from "@angular/material/datepicker"
import { RssService } from '../../Services/rss.service';
import { map, tap } from 'rxjs';
import { WorkingCalendar } from '../../interfaces/workingcalendar';
import { Event } from '../../interfaces/event';
import { EventService } from '../../Services/event.service';
import { Employee } from '../../interfaces/employee';
import { EmpService } from '../../Services/emp.service';
import {MatTooltipModule} from '@angular/material/tooltip'
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-calendar',
  imports: [ MatTooltipModule, MatCalendar, CommonModule],
  templateUrl: './calendar.component.html',
  styleUrl: './calendar.component.css',
  encapsulation: ViewEncapsulation.None
})
export class CalendarComponent implements AfterViewInit {


  workingCalendar: WorkingCalendar[] = []
  events: Event [] = []
  employees: Employee []=[]

  cdr = inject(ChangeDetectorRef)
  empService = inject(EmpService)
  eventService= inject(EventService)
  rssService = inject(RssService)

  bornDates: Date[] = []
  

  isDataLoaded: boolean = false;
  @ViewChild(MatCalendar) calendar!:MatCalendar<Date>
 
  ngOnInit():void{
    this.rssService.getWorkingCalendar().pipe(tap(item => {
      // Выводим исходные данные для отладки
      console.log('Received data:', item);
    }),
    map(items => {
      // Преобразуем данные
      return items.map(e => ({
        ...e,
        ecxeption_date: new Date(e.ecxeption_date)
      }));
    })
  ).subscribe(
    transformedItems => {
      // Выводим уже преобразованные данные
      this.workingCalendar = transformedItems;
      console.log('Transformed data:', this.workingCalendar);
    },
    error => {
      console.error('Error loading data:', error);
    })

    this.empService.getAll().pipe(
      tap(r => console.log(r)),
      map((r) => this.employees = r.map( e => ({
        ...e, date_born:new Date(e.date_born)
      })))
    ).subscribe()
   
    if (this.calendar) {
      this.calendar.updateTodaysDate();
      this.cdr.detectChanges();
    }
    this.isDataLoaded = true; 
  }

  ngAfterViewInit(): void {
    
  }
  
  getBirthdaysTooltip(date: Date): string {
    const birthdayEmployees = this.employees
      .filter(e => e.date_born.toDateString() === date.toDateString())
      .map(e => e.fio);
      
    return birthdayEmployees.length ? birthdayEmployees.join(', ') : '';
  }

  dateClass1 = (date: Date) => {
    console.log(this.workingCalendar)
    return this.workingCalendar.some(d => d.ecxeption_date.toDateString() === date.toDateString()) ? 'highlight-day' : '';
  };
  dateClass = (date:Date): string => {
 
  const dateStr = date.toDateString(); // Преобразуем дату в строку для сравнения

  if (this.workingCalendar.some(wc => new Date(wc.ecxeption_date).toDateString() === dateStr && wc.is_working_day)) {
    console.log("hi1")
    return "highlight-day";
  }

  if (this.employees.some(e => new Date(e.date_born).toDateString() === dateStr)) {
    return "image-date"; // Используем "image-date" для отображения иконки 🎂
  }
  return ""
  }
  
  
}
