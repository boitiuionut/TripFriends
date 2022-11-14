import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/authentication.service';
import { Router } from '@angular/router';
import { RequestsService } from 'src/app/requests.service';


@Component({
  selector: 'useractivity-page',
  templateUrl: './useractivity.component.html',
  styleUrls: ['./useractivity.component.css']
})
export class UseractivityComponent implements OnInit {
  /*variabile pentru gestiunea informatiilor.
  trips primeste toate calatoriile utilizatorului logat si apoi calatoriile sunt impartite in futureTrips si pastTrips, 
  dupa campul isFutureTrip*/
  trips : any = [{
    country: "",
    town : "",
    address: "",
    date: "",
    duration: "",
    description: "",
    isFutureTrip: false
  }]
  pastTrips: any = [];
  futureTrips: any = [];

  constructor(
    private router: Router,
    private authenticationService: AuthenticationService,
    private requests: RequestsService) 
    { }

  ngOnInit() {
    if(!this.authenticationService.token) {
      this.router.navigateByUrl("/");
      return;
    }
    this.getTrips();
  }

  goToRoute(routeTo: string)
    {
        this.router.navigateByUrl("/" + routeTo);
    }
    //metoda pentru a imparti vectorul de calatorii in viitoare si trecute
    getTrips()
    {
      var route = "user/get-trips/" + this.authenticationService.username;
      this.requests.get(route).subscribe(data => {
        if(data !=null)
        {
        console.log(data)
        this.trips = data;
        this.splitTrips();
        }
      }, error => {
        console.log(error);
      }, () => {
      })
    }

    splitTrips()
    {
      for(var i=0; i<this.trips.length; i++)
      {
        if(this.trips[i].isFutureTrip == true)
        {
          this.futureTrips.push(this.trips[i]);
        }
        else
        {
          this.pastTrips.push(this.trips[i]);
        }
      }
    }

    sortPastTripsByCountry()
    {
      function compare(a, b) {
        // Use toUpperCase() to ignore character casing
        const countryA = a.country.toUpperCase();
        const countryB = b.country.toUpperCase();
      
        let comparison = 0;
        if (countryA > countryB) {
          comparison = 1;
        } else if (countryA < countryB) {
          comparison = -1;
        }
        console.log(comparison)
        return comparison;
      }

      this.pastTrips.sort(compare)
    }

    sortPastTripsByTown()
    {
      function compare(a, b) {
        // Use toUpperCase() to ignore character casing
        const townA = a.town.toUpperCase();
        const townB = b.town.toUpperCase();
      
        let comparison = 0;
        if (townA > townB) {
          comparison = 1;
        } else if (townA < townB) {
          comparison = -1;
        }
        console.log(comparison)
        return comparison;
      }

      this.pastTrips.sort(compare)
    }

    sortPastTripsByDate()
    {
      function compare(a, b) {
        // Use toUpperCase() to ignore character casing
        const dateA = a.date.toUpperCase();
        const dateB = b.date.toUpperCase();
      
        let comparison = 0;
        if (dateA > dateB) {
          comparison = 1;
        } else if (dateA < dateB) {
          comparison = -1;
        }
        console.log(comparison)
        return comparison;
      }

      this.pastTrips.sort(compare)
    }

    logout() {
        this.authenticationService._logout();
    }

}
