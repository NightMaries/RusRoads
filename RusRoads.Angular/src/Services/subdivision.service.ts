import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { BehaviorSubject, Observable, ReplaySubject } from 'rxjs';
import { Subdivision } from '../interfaces/subdivision';
import { Employee } from '../interfaces/employee';

@Injectable({
  providedIn: 'root'
})
export class SubdivisionService {

  employeeAll : Employee[] = []
  employeeAll$ = new BehaviorSubject<Employee[]>(this.employeeAll)
  currentSubId$ = new ReplaySubject<number>(1)
  
  url = "http://localhost:5193/api/v1/"
  http = inject(HttpClient)

  GetSubdivisionAll(): Observable<Subdivision[]>
  {
    return this.http.get<Subdivision[]>(this.url + "Subdivisions")
  }
  GetEmpBySub(subId:number):Observable<Employee[]>
  {
    return this.http.get<Employee[]>(`${this.url}${subId}/employee`)
  }
  GetEmpBySubAll(subId:number):Observable<Employee[]>
  {
    return this.http.get<Employee[]>(`${this.url}${subId}/employeeAll`)
  }
}
