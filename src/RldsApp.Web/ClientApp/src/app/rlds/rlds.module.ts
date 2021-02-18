import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RldsRoutingModule } from './rlds-routing.module';
import { AccountViewComponent } from './accounts/account-view/account-view.component'; 


@NgModule({
  imports: [
    CommonModule,
    RldsRoutingModule
  ],
  declarations: []
})
export class RldsModule { }
