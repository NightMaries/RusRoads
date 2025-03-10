import { Component, inject } from '@angular/core';
import { SubdivisionsComponent } from "../subdivisions/subdivisions.component";
import { EmployeesComponent } from "../employees/employees.component";
import { Employee } from '../../interfaces/employee';
import { EmpService } from '../../Services/emp.service';
import { Subdivision } from '../../interfaces/subdivision';
import { SubdivisionService } from '../../Services/subdivision.service';
import { EventService } from '../../Services/event.service';

@Component({
  selector: 'app-structur-org',
  imports: [SubdivisionsComponent, EmployeesComponent],
  templateUrl: './structur-org.component.html',
  styleUrl: './structur-org.component.css'
})
export class StructurOrgComponent {
  


}
