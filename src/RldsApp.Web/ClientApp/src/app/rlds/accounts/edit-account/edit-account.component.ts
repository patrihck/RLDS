import { Component, OnInit } from '@angular/core';
import { defaultRequestErrorHandler } from '../../../../infrastructure/interceptors/error-interceptor';
import { AccountsClient, Currency, CurrencyClient, NewAccount } from '../../../../infrastructure/services-api/rlds-api';
import { LayoutService } from '../../../../infrastructure/services/layout/layout.service';

@Component({
  selector: 'app-edit-account',
  templateUrl: './edit-account.component.html',
  styleUrls: ['./edit-account.component.css']
})
export class EditAccountComponent implements OnInit { 

  constructor( ) { }

  ngOnInit(): void { 
  } 
}
