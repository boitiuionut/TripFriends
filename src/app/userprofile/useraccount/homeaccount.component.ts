import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/authentication.service';
import { RequestsService } from 'src/app/requests.service';
import { ModalService } from 'src/app/modal.service';
import { NotifierService } from 'angular-notifier';


@Component({
    selector: 'userhome-page',
    templateUrl: './homeaccount.component.html',
    styleUrls: ['./homeaccount.css']
})

export class HomeAccountComponent implements OnInit {
    constructor(
        private router: Router,
        private authenticationService: AuthenticationService,
        private requests: RequestsService,
        private modalService: ModalService,
        private notifier: NotifierService) { }

    seachBox: string = ""
    searchBoxText: string = "Where to?"
    postTripModel = {
        country: "",
        town: "",
        address: "",
        duration: "",
        date: "",
        description: ""
    }
    userTripsInfo: any = []
    a: any = {
        country: "",
        town: "",
        address: "",
        duration: "",
        date: "",
        description: ""
    }
    userFeedbackInfo: any = [{

    }]
    allData: any = [{
        userId: "",
        firstName: "",
        lastName: "",
        phone: "",
        email: "",
        username: "",
        description: "",
        profilepicture: "",
        country: "",
        town: "",
        address: "",
        date: "",
        duration: "",
        descriptionTrip: "",
        isFutureTrip: "",
        avgRating: 0,
        userFeedbackInfo: []
    }];
    temp: any = [{
        userId: "",
        firstName: "",
        lastName: "",
        phone: "",
        email: "",
        username: "",
        description: "",
        profilepicture: "",
        country: "",
        town: "",
        address: "",
        date: "",
        duration: "",
        descriptionTrip: "",
        isFutureTrip: "",
        avgRating: 0,
        userFeedbackInfo: []
    }];
    allDataBackup: any = [{
        userId: "",
        firstName: "",
        lastName: "",
        phone: "",
        email: "",
        username: "",
        description: "",
        profilepicture: "",
        country: "",
        town: "",
        address: "",
        date: "",
        duration: "",
        descriptionTrip: "",
        isFutureTrip: "",
        avgRating: 0,
        userFeedbackInfo: []
    }];

    tripInfoAllData: any = {
        firstName: "",
        lastName: "",
        phone: "",
        email: "",
        username: "",
        description: "",
        profilepicture: "",
        country: "",
        town: "",
        address: "",
        date: "",
        duration: "",
        descriptionTrip: "",
        isFutureTrip: "",
        avgRating: 0,
        userFeedbackInfo: []
    }

    ngOnInit() {
        if (!this.authenticationService.token) {
            this.router.navigateByUrl("/");
            return;
        }
        this.getTrips();
        setTimeout(() => {
            this.closeModal('custom-modal-1');
        }, 10)
    }

    clearTripModel() {
        this.postTripModel = {
            country: "",
            town: "",
            address: "",
            duration: "",
            date: "",
            description: ""
        };
    }

    postTrip() {
        var route = "user/post-tripinfo/" + this.authenticationService.username;

        if(this.postTripModel.country == "" || this.postTripModel.town == "" || this.postTripModel.address == "" ||
            this.postTripModel.duration == "" || this.postTripModel.date == "" || this.postTripModel.description == "")
            {
                this.notifier.notify("warning", "All fields from 'Post a trip' are mandatory!");
                return;
            }
        this.requests.post(route, this.postTripModel).subscribe(data => {
            this.clearTripModel();
        }, error => {
            console.log(error);
        }, () => {

        })
    }

    getTrips() {
        var route = "user/get-trips";
        this.requests.get(route).subscribe(data => {
            this.allData = data;
            this.allDataBackup = data;
            console.log(data)
        }, error => {
            console.log(error);
        }, () => {

        })
    }

    goToRoute(routeTo: string) {
        this.router.navigateByUrl("/" + routeTo);
    }
    //deschiderea modalului si popularea datelor din el pe baza informatiilor din "trip", trimis metodei din html, in urma selectarii unui user.
    sendTripInfo(trip: any) {
        this.tripInfoAllData = trip;
        this.openModal('custom-modal-1');
    }

    openModal(id: string) {
        this.modalService.open(id);
    }

    closeModal(id: string) {
        this.modalService.close(id);
    }

    //aici se face cautarea in tabel si se populeaza tabelul in functie de datele gasite. Cautarea se face pe baza tarii si orasului. 
    searchInTable(searchString: string) {
        this.temp = [];
        this.allData = this.allDataBackup;
        if (searchString == "") {
            return;
        }
        else {
            for (var i = 0; i < this.allData.length; i++) {
                if (this.allData[i].country.toLowerCase().includes(searchString.toLowerCase()) || 
                    this.allData[i].town.toLowerCase().includes(searchString.toLowerCase())) 
                {
                    this.temp.push(this.allData[i]);
                }
            }
            this.allData = this.temp;
        }
    }

    logout() {
        this.authenticationService._logout();
    }

}