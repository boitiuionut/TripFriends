import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RequestsService } from 'src/app/requests.service';
import { AuthenticationService } from 'src/app/authentication.service';

@Component({
  selector: 'userinfo-page',
  templateUrl: './userinfo.component.html',
  styleUrls: ['./userinfo.component.css']
})
export class UserinfoComponent implements OnInit {

  editable : boolean = false;
  userInfoModel = { 

  };

  constructor(
    private router: Router,
        private authenticationService: AuthenticationService,
        private requests: RequestsService) { }

  ngOnInit() {
    if(!this.authenticationService.token) {
      this.router.navigateByUrl("/");
      return;
    }
    this.getUserInformation() 
  }

//face get pe baza de date, pt a lu informatiile utilizatorului logat
  getUserInformation() {
    var route = "users/get/information/username/" + this.authenticationService.username;
    this.requests.get(route).subscribe(data => {
      this.userInfoModel = data;
    }, error => {
      console.log(error);
    }, () => {

    })
  }

  //editeaza datele utilizatorului logat.
  editUserInformation() {
    var route = "users/edit/information/username"
    this.requests.put(route, this.userInfoModel).subscribe(data => {
      if (data == true) {
        console.log("Success")
      } else {
        console.log("Failure")
      }
    }, error => {
      console.log(error);
    }, () => {
      this.getUserInformation();
      this.editable = false;
    })
  }

  goToRoute(routeTo: string)
    {
        this.router.navigateByUrl("/" + routeTo);
    }

  enableUserDataToBeModified()
  {
    this.editable = true;
    return this.editable;
  }

  disableUserDataToBeModified()
  {
    this.editable = false;
    return this.editable;
  }

  logout() {
    this.authenticationService._logout();
}
 
}
