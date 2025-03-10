import { Component, inject, OnInit } from '@angular/core';
import { SubdivisionService } from '../../Services/subdivision.service';
import {DagreLayout, NgxGraphModule, Orientation, Node} from '@swimlane/ngx-graph'
import { CommonModule } from '@angular/common';
import { catchError, of, tap } from 'rxjs';


@Component({
  selector: 'app-subdivisions',
  imports: [CommonModule, NgxGraphModule],
  templateUrl: './subdivisions.component.html',
  styleUrl: './subdivisions.component.css'
})
export class SubdivisionsComponent implements OnInit {

  
  links:any[] =[]
  nodes:Node[] =[]
  layout = new DagreLayout()

  subService = inject(SubdivisionService)


  ngOnInit(): void {
    this.subService.GetSubdivisionAll().subscribe(o => 
    {
      this.prepareDate(o)
    })
    this.layout.settings.orientation = Orientation.TOP_TO_BOTTOM
  }

  prepareDate(data: any[])
  {
    console.log(data)
    this.nodes = data.map((item) => 
      ({
        id: item.id.toString(),
        label: item.name.toString()
      }))

    this.links = data
      .filter((item) => item.leader_subdivision_id !== 0)
      .map((item) => ({
        source: item.leader_subdivision_id.toString(),
        target: item.id.toString()
      }))
  }

  GetEmployeeAllBySub(data:any){
    this.subService.currentSubId$.next(data.id);

    this.subService.GetEmpBySubAll(data.id).pipe(
      tap(r => {console.log(r)}),
      tap(r => this.subService.employeeAll$.next(r)),
      catchError(error =>
      {
        console.error('Error fetching employees',error);
        return of([])
      })).subscribe()
  }
  
  shortTitle(title:string)
  {
    var splitArr = title.trim().split(" ")
    var resultArr: string[] = []
    splitArr.forEach(e => {
      resultArr.push(e.slice(0,3))
    });
    return resultArr.join(".").toUpperCase().slice(0,7)
  }
  GetNodeWidth(node:Node):number {
    return (node.label!.length)*11
  }
}
