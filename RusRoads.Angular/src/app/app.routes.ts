import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AppComponent } from './app.component';
import { StructurOrgComponent } from './structur-org/structur-org.component';

export const routes: Routes = [
    {path:"home", component: HomeComponent},
    {path: "", component: StructurOrgComponent}
];
