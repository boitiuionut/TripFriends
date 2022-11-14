import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/authentication.service';
import { RequestsService } from 'src/app/requests.service';
import { NotifierService } from 'angular-notifier';

@Component({
  selector: 'userfeedback-page',
  templateUrl: './userfeedback.component.html',
  styleUrls: ['./userfeedback.component.css']
})

export class UserfeedbackComponent implements OnInit {

  p: number = 1;
  feedbackInfoModel = {
    username:"",
    description: "",
    rating: 0
  };
  userdataInfoModel : any = [];

  constructor(
    private router: Router,
    private authenticationService: AuthenticationService,
    private requests: RequestsService,
    private notifier: NotifierService
  ) { }
  

  ngOnInit() {
    if(!this.authenticationService.token) {
      this.router.navigateByUrl("/");
      return;
    }
    this.getUserFeedback();
  }

  goToRoute(routeTo: string)
    {
        this.router.navigateByUrl("/" + routeTo);
    }

    logout() {
        this.authenticationService._logout();
    }

    clearFeedbackModel()
    {
      this.feedbackInfoModel = {
        username:"",
        description: "",
        rating: 0
      };
    }

    //post in baza de date a feedback-ului salvat in obiectul feedbackInfoModel
    postFeedback(){
      var route = "user/post-tripfeedback";
      if (this.feedbackInfoModel.username === '' ||  this.feedbackInfoModel.rating == 0 || this.feedbackInfoModel.description === '') {
        this.notifier.notify("warning", "The fields for posting a feedback are mandatory!");
        return;
      }

      if(this.feedbackInfoModel.username == this.authenticationService.username)
      {
        this.notifier.notify("error", "You can't post feedback about yourself!");
        return;
      }

      this.requests.post(route, this.feedbackInfoModel).subscribe(data => {
          this.clearFeedbackModel();
          if(data == false)
          {
            this.notifier.notify("warning", "The username you wrote doesn't exist!");
          }
        }, error => {
          console.log(error);
        }, () => {
        })
    }

    //ia din baza de date feedback-ul pt utilizatorul logat
    getUserFeedback()
    {
      var route = "user/get-userfeedback/" + this.authenticationService.username;
      this.requests.get(route).subscribe(data => {
        this.userdataInfoModel = data;
      }, error => {
        console.log(error);
      }, () => {

      })
    }

}
