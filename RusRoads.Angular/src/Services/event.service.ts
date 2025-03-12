import { HttpClient, HttpParams } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../environments/environment.development';
import { Observable } from 'rxjs';
import { Event } from '../interfaces/event';
import { WorkingCalendar } from '../interfaces/workingCalendar';

@Injectable({
  providedIn: 'root'
})
export class EventService {
  http = inject(HttpClient)

  getEmpEvent (empId:number,is_old:boolean,is_current:boolean,is_futute:boolean)
  {
    var params = new HttpParams()
    .set("oldEvent",is_old)
    .set("currentEvent",is_current)
    .set("futureEvent",is_futute)
    return this.http.get<Event[]>(environment.url +'Event/'+ `${empId}`,{params})
  }
  createEvent(event: Event){
    return this.http.post<Event>(environment.url+"Event", event)
  }
  deleteEvent(eventId: number){
    return this.http.delete(environment.url+"Event/"+`${eventId}`)
  }
  getAllEvents():Observable<Event[]>{
    return this.http.get<Event[]>(environment.url+"Event")
  }
  getWorkingCal():Observable<WorkingCalendar[]>{
    return this.http.get<WorkingCalendar[]>(environment.url+"WorkingCalendar")
  }
}
