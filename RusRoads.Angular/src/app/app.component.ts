import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { SubdivisionsComponent } from "./subdivisions/subdivisions.component";
import { EmployeeComponent } from './employee/employee.component';
import { EmployeesComponent } from './employees/employees.component';
import { HeaderComponent } from "./header/header.component";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, SubdivisionsComponent, EmployeesComponent, EmployeeComponent, HeaderComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'RusRoads.Angular';
}
