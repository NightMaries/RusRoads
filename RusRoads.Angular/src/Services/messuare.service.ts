import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../environments/environment.development';
import { Messuare } from '../interfaces/messuare';

@Injectable({
  providedIn: 'root'
})
export class MessuareService {

  http = inject(HttpClient)
  
  getMessuares(){
    return this.http.get<Messuare[]>(environment.url + "messuare")
  }

}
