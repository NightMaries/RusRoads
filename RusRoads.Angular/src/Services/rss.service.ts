import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { News } from '../interfaces/news';
import { map, Observable, tap } from 'rxjs';
import { environment } from '../environments/environment.development';
import { WorkingCalendar } from '../interfaces/workingcalendar';

@Injectable({
  providedIn: 'root'
})
export class RssService {
  http = inject(HttpClient)

  private url = "https://rss.nytimes.com/services/xml/rss/nyt/World.xml"

  news: News [] = []

  getRssFeed(): Observable<News[]>
  { 
    return this.http.get(this.url,{responseType:"text"}).pipe(
      map((xmlString) => this.parseXml(xmlString))
    );
  }
  private parseXml(xmlString:string):any{
    const parser = new DOMParser();
    const xml = parser.parseFromString(xmlString, "text/xml")

    const items = Array.from(xml.querySelectorAll('item'))
    
    return items.map((item) => {
      const mediaContent = item.getElementsByTagName("media:content")[0];
      const mediaUrl = mediaContent ? mediaContent.getAttribute('url') : ''
      return {
        title: item.querySelector('title')?.textContent || '',
        link: item.querySelector('link')?.textContent || '',
        url: mediaUrl
      }
    })
  }

  getWorkingCalendar(){
    return this.http.get<WorkingCalendar[]>(environment.url+"workingCalendar")
  }
}
