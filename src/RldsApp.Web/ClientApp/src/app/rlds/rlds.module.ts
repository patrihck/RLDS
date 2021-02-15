import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RldsRoutingModule } from './rlds-routing.module';
import { HomeComponent } from './home/home.component';
import { AccountComponent } from './account/account.component';
import { UsersComponent } from './users/users.component';


@NgModule({
  declarations: [HomeComponent, AccountComponent, UsersComponent],
  imports: [
    CommonModule,
    RldsRoutingModule
  ]
})
export class RldsModule { }
