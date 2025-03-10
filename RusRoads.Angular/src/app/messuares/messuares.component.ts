import { Component, Input } from '@angular/core';
import { Messuare } from '../../interfaces/messuare';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-messuares',
  imports: [MatIconModule],
  templateUrl: './messuares.component.html',
  styleUrl: './messuares.component.css'
})
export class MessuaresComponent {

  @Input()
  messuare!: Messuare
}
