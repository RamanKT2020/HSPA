import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-property-list',
  templateUrl: './property-list.component.html',
  styleUrls: ['./property-list.component.css']
})
export class PropertyListComponent implements OnInit {

  properties: Array<any> = [
    {
      "Id": 1,
      "Name": "Birla House1",
      "Type": "House",
      "Price": 1001
    },
    {
      "Id": 2,
      "Name": "My Condo",
      "Type": "Condo",
      "Price": 1002
    },
    {
      "Id": 3,
      "Name": "My Apt",
      "Type": "Apartment",
      "Price": 1003
    },
    {
      "Id": 4,
      "Name": "My Town Home",
      "Type": "TownHome",
      "Price": 1004
    }
]

  constructor() { }

  ngOnInit(): void {
  }

}
