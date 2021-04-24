import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { UserDetailComponent } from './user-detail/user-detail.component';
import { PaymentService} from '../app/payment.service';
import { UserService } from './Service/user.service';
import { LoginService } from './Service/login.service';
import { LoginComponent } from './login/login.component';
import { PaymentComponent } from './payment/payment.component';
import { AddUserComponent } from './Admin/add-user/add-user.component';
import { EditUserComponent } from './Admin/edit-user/edit-user.component';
import { SafePipe } from './pipes/safe-url.pipe';

@NgModule({
  declarations: [
    SafePipe,
    AppComponent,
    NavMenuComponent,
    LoginComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    UserDetailComponent,
    PaymentComponent,
    AddUserComponent, EditUserComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: LoginComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'user-detail', component: UserDetailComponent },
      { path: 'payment', component: PaymentComponent },
      { path: 'adduser', component: AddUserComponent },
      { path: 'edituser/:PKUserId', component: EditUserComponent }

    ])
  ],
  providers: [PaymentService, UserService, LoginService],
  bootstrap: [AppComponent]
})
export class AppModule { }
