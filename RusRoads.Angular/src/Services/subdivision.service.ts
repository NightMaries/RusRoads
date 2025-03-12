import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { BehaviorSubject, Observable, ReplaySubject } from 'rxjs';
import { Subdivision } from '../interfaces/subdivision';
import { Employee } from '../interfaces/employee';

@Injectable({
  providedIn: 'root'
})
export class SubdivisionService {

  employeeAll$ = new BehaviorSubject<Employee[]>([])
  currentSubId$ = new ReplaySubject<number>(1)
  
  url = "http://localhost:5193/api/v1/"
  http = inject(HttpClient)

  GetSubdivisionAll()
  {
    return this.http.get<Subdivision[]>(this.url + "Subdivisions")
  }
  GetEmpBySub(subId:number)
  {
    return this.http.get<Employee[]>(`${this.url}${subId}/employee`)
  }
  GetEmpBySubAll(subId:number)
  {
    return this.http.get<Employee[]>(`${this.url}${subId}/employeeAll`)
  }
}
