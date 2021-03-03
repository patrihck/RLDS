import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { defaultRequestErrorHandler } from '../../../../infrastructure/interceptors/error-interceptor';
import { CurrencyClient, NewCurrency } from '../../../../infrastructure/services-api/rlds-api';
import { LayoutService } from '../../../../infrastructure/services/layout/layout.service';

@Component({
  selector: 'app-add-currency',
  templateUrl: './add-currency.component.html',
  styleUrls: ['./add-currency.component.css']
})
export class AddCurrencyComponent implements OnInit {

  currency: NewCurrency;

  constructor(private readonly currencyClient: CurrencyClient,
    private readonly router: Router,
    private readonly layoutService: LayoutService) { }

  ngOnInit(): void {
    this.currency = new NewCurrency();
  }

  save() {
    this.currencyClient.addCurrency(this.currency, "1.0").subscribe(r => {
      this.router.navigate(['/dictionary/currencies']);
    }, err => defaultRequestErrorHandler(this.layoutService, err));
  }
}
