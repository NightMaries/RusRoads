import { Component, inject } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AppService } from '../../../app.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-header',
  imports: [RouterModule, CommonModule, FormsModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {

  appService = inject(AppService)
  searchString = ""

  searchComplex() {
    this.appService.searchString$.next(this.searchString)
  }
search() {
  this.searchString = ''
  this.searchComplex()  
}

}
