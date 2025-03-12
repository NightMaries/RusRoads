import { Component, Input, OnInit } from '@angular/core';
import { Messuare } from '../../interfaces/messuare';
import { MatIconModule } from '@angular/material/icon';
import { QRCodeComponent } from 'angularx-qrcode';

@Component({
  selector: 'app-messuares',
  imports: [MatIconModule,QRCodeComponent],
  templateUrl: './messuares.component.html',
  styleUrl: './messuares.component.css'
})
export class MessuaresComponent {
  
  ics=''
  @Input()
  messuare!: Messuare

  donwloadICS() {
    const ics = ` BEGIN:VCALENDAR
                  VERSION:2.0
                  BEGIN:VEVENT
                  SUMMARY:${this.messuare.name} 
                  DTSTART:${this.messuare.date_start}
                  DTEND:${this.messuare.date_end}
                  DTSTAMP:${this.messuare.date_created}
                  UID:${this.messuare.id}
                  DESCRIPTION:${this.messuare.description}
                  LOCATION:${this.messuare.region}
                  ORGANIZER:${this.messuare.responsible_person}
                  STATUS:CONFIRMED
                  PRIORITY:0  
                  END:VEVENT
                  END:VCALENDAR
    ` 
    const blob = new Blob([ics],{type:'text/calendar;charset=utf-8'})
    const url = window.URL.createObjectURL(blob)

    const link = document.createElement('a')
    link.href = url
    link.download = `${this.messuare.name}.ics`
    link.click()
    window.URL.revokeObjectURL(url)

   }
}
