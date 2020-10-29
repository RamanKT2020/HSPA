
//Created boilerplate code using the "generate Service" and add "implements Resolver"
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot, Resolve, Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Property } from 'src/app/model/property';
import { HousingService } from 'src/app/services/housing.service';

@Injectable({
  providedIn: 'root'
})
export class PropertyDetailResolverService implements Resolve<Property> {

constructor(private router: Router, private housingService: HousingService) { }

resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot):
  Observable<Property>|Property {
    const propId  = route.params['id'];
    return this.housingService.getProperty(+propId).pipe(
      catchError(error => {
          this.router.navigate['/'];
          return of(null);
      })
    );
  }
}
