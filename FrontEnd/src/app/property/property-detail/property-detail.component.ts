import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Property } from 'src/app/model/property';
import { HousingService } from 'src/app/services/housing.service';

@Component({
  selector: 'app-property-detail',
  templateUrl: './property-detail.component.html',
  styleUrls: ['./property-detail.component.scss']
})
export class PropertyDetailComponent implements OnInit {

  public propertyId: number;
  property = new Property();


  constructor(private route : ActivatedRoute,
              private router: Router,
              private housingService: HousingService) { }

  ngOnInit() {
    this.propertyId = Number(this.route.snapshot.params['id']);

    this.route.data.subscribe(
      (data: Property) => {
        this.property = data['prp'];
      }
    )

    //  code below not needed because we are using the resolver prp

    //to react to a change in parameters, but no change to the component being used
    // this.route.params.subscribe(
    //     (params) => {
    //       this.propertyId = Number(params['id']);
    //       this.housingService.getProperty(this.propertyId).subscribe(
    //         (data: Property) => {
    //           this.property = data;
    //           // this.property.Name = data.Name; //to illustrate passing value to just one item
    //         }, error => this.router.navigate(['/'])
    //       );
    //    }
    //)
  }

  //onSelecNext() {
    //this.propertyId  += 1;

    // the navigate method works as an absolute path even without the leading / before property-detail
    //this.router.navigate(['property-detail', this.propertyId])

    //if you want a relative route, use this syntax. this.route should be replaced with whatever route you want to base off of
    //  this.route was used to demonstrate the feature
    //this.router.navigate(['property-detail', this.propertyId], { relativeTo: this.route })
  //}
}
