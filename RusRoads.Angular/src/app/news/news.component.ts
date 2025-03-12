import { Component, inject, OnInit } from '@angular/core';
import { News } from '../../interfaces/news';
import { RssService } from '../../Services/rss.service';
import { map, tap } from 'rxjs';

@Component({
  selector: 'app-news',
  imports: [],
  templateUrl: './news.component.html',
  styleUrl: './news.component.css'
})
export class NewsComponent implements OnInit {

  news: News[] = []
  rssService = inject(RssService)

  ngOnInit(): void {
    this.rssService.getRssFeed().pipe(
      tap((p) => console.log(p)),
      map((p) => this.news = p)
    ).subscribe()
    
  }


}
