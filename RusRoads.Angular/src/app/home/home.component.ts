import { Component, inject, OnInit } from '@angular/core';
import { SubdivisionsComponent } from '../subdivisions/subdivisions.component';
import { EmployeesComponent } from '../employees/employees.component';
import { RouterModule } from '@angular/router';
import { SubdivisionService } from '../../Services/subdivision.service';
import { Subdivision } from '../../interfaces/subdivision';
import { Employee } from '../../interfaces/employee';
import { EmpService } from '../../Services/emp.service';
import { EventService } from '../../Services/event.service';
import { MessuareService } from '../../Services/messuare.service';
import { interval, map, switchMap, tap } from 'rxjs';
import { EmployeeComponent } from "../employee/employee.component";
import { CommonModule } from '@angular/common';
import { MessuaresComponent } from "../messuares/messuares.component";
import { NewsComponent } from '../news/news.component';
import { CalendarComponent } from "../calendar/calendar.component";
import { RssService } from '../../Services/rss.service';
import { AppService } from '../../../app.service';

@Component({
  selector: 'app-home',
  imports: [SubdivisionsComponent, EmployeesComponent,
    RouterModule, EmployeeComponent, CommonModule, MessuaresComponent, NewsComponent, CalendarComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {
  
  employees!: Employee[] 
  messuares!: any []
  news: any[] = []


  empService = inject(EmpService)
  mesSerivce = inject(MessuareService)
  rssService = inject(RssService)
  appService = inject(AppService)

  ngOnInit(): void {
    this.appService.searchString$.subscribe(r => this.loadData(r))
    
    interval(15000).pipe(
      switchMap(() => this.rssService.getRssFeed()))
      .subscribe(r => this.news = r.filter(item => item.title.toLowerCase()
      .includes(this.appService.searchString$.getValue().toLowerCase())))

  }
  loadData(searchString:string){
        
    this.mesSerivce.getMessuares().pipe(
      map((r) => this.messuares = r)
    ).subscribe(r => this.messuares = r.filter(item => 
          item.description.toLowerCase().includes(searchString.toLowerCase())||
          item.name.toLowerCase().includes(searchString.toLowerCase())||
          item.responsible_person.toLowerCase().includes(searchString.toLowerCase())))
    
    this.empService.getAll().pipe(
      map ((r) => this.employees = r) 
    ).subscribe( r => this.employees = r.filter(item => item.fio.toLowerCase().includes(searchString.toLowerCase()) ||
          item.subdivision?.name.toLowerCase().includes(searchString.toLowerCase())||
          item.cabinet.toLowerCase().includes(searchString.toLowerCase())||
          item.email.toLowerCase().includes(searchString.toLowerCase())||
          item.position.toLowerCase().includes(searchString.toLowerCase())));

    this.rssService.getRssFeed()
      .subscribe(r => this.news = r.filter(item => item.title.toLowerCase()
      .includes(this.appService.searchString$.getValue().toLowerCase())))

  }


}
