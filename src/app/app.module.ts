import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule  } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { RouterModule } from '@angular/router'
import { MainPageComponent } from './mainpage/mainpage.component';
import { RequestsService } from './requests.service';
import { AuthenticationService } from './authentication.service';
import { HttpModule } from '@angular/http';
import { TestComponent } from './tests/test';
import { InfoPageComponent } from './infopage/about.component';
import { ContactPageComponent } from './contactpage';
import { HomeAccountComponent } from './userprofile/useraccount';
import { NotifierModule } from "angular-notifier";
import { UseractivityComponent } from './userprofile/useractivity/useractivity.component';
import { UserfeedbackComponent } from './userprofile/userfeedback/userfeedback.component';
import { UserinfoComponent } from './userprofile/userinfo/userinfo.component';
import {NgxPaginationModule} from 'ngx-pagination'; 
import { ModalComponent } from './modal.component';


@NgModule({
  declarations: [
    AppComponent,
    ModalComponent,
    MainPageComponent,
    InfoPageComponent,
    ContactPageComponent,
    HomeAccountComponent,
    TestComponent,
    UseractivityComponent,
    UserfeedbackComponent,
    UserinfoComponent,
  ],
  imports: [
    NgxPaginationModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    HttpModule,
    FormsModule,
    RouterModule.forRoot([
      {
        path : 'test-page',
        component : TestComponent
      },
      {
        path: 'info-page',
        component : InfoPageComponent
      },
      {
        path : 'contact-page',
        component : ContactPageComponent
      },
      {
        path : 'userhome-page',
        component : HomeAccountComponent
      },
      {
        path : 'useractivity-page',
        component : UseractivityComponent
      },
      {
        path : 'userfeedback-page',
        component : UserfeedbackComponent
      },
      {
        path : 'userinfo-page',
        component : UserinfoComponent
      },
      {
        path : '',
        component : MainPageComponent
      }
    ]),
    NotifierModule.withConfig({
      // Custom options in here
      position: {
        horizontal: {
          /**
           * Defines the horizontal position on the screen
           * @type {'left' | 'middle' | 'right'}
           */
          position: 'right',
          /**
           * Defines the horizontal distance to the screen edge (in px)
           * @type {number} 
           */
          distance: 12
        },
        vertical: {
          /**
           * Defines the vertical position on the screen
           * @type {'top' | 'bottom'}
           */
          position: 'top',
          /**
           * Defines the vertical distance to the screen edge (in px)
           * @type {number} 
           */
          distance: 20,
          /**
           * Defines the vertical gap, existing between multiple notifications (in px)
           * @type {number} 
           */
          gap: 10
        }
      },
      behaviour: {
        /**
         * Defines whether each notification will hide itself automatically after a timeout passes
         * @type {number | false}
         */
        autoHide: 3000,
        /**
         * Defines what happens when someone clicks on a notification
         * @type {'hide' | false}
         */
        onClick: false,
        /**
         * Defines what happens when someone hovers over a notification
         * @type {'pauseAutoHide' | 'resetAutoHide' | false}
         */
        onMouseover: 'pauseAutoHide',
        /**
         * Defines whether the dismiss button is visible or not
         * @type {boolean} 
         */
        showDismissButton: true,
        /**
         * Defines whether multiple notification will be stacked, and how high the stack limit is
         * @type {number | false}
         */
        stacking: 2
      }
    })
  ],
  providers: [RequestsService, AuthenticationService],
  bootstrap: [AppComponent]
})
export class AppModule { }
