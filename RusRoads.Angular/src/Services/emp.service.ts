import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Employee } from '../interfaces/employee';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class EmpService {
  
  http = inject(HttpClient)

  create(emp: Employee){
    return this.http.post(environment.url + "Employee",emp)
  }
  update(emp: Employee){
    return this.http.put(environment.url+'Employee/update',emp)
  }
  getAll()
  {
    return this.http.get<Employee[]>(environment.url+"Employee")
  }
  
  
  dismiss(emp: Employee)
  {
    return this.http.put<Employee>(environment.url+"Employee/dismiss", emp)
  }
}
