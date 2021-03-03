import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ActivatedRouteSnapshot, Router } from '@angular/router';
import { defaultRequestErrorHandler } from '../../../../infrastructure/interceptors/error-interceptor';
import { Currency, CurrencyClient, NewCurrency } from '../../../../infrastructure/services-api/rlds-api';
import { LayoutService } from '../../../../infrastructure/services/layout/layout.service';

@Component({
  selector: 'app-edit-currency',
  templateUrl: './edit-currency.component.html',
  styleUrls: ['./edit-currency.component.css']
})
export class EditCurrencyComponent implements OnInit {
  id;
  currency: Currency;

  constructor(private readonly currencyClient: CurrencyClient,
    private readonly route: ActivatedRoute,
    private readonly router: Router,
    private readonly layoutService: LayoutService) { }

  ngOnInit(): void {

    this.route.paramMap.subscribe(paramMap => {
      this.id = +paramMap.get('id');
      this.getData();
    })
  }

  getData() {
    this.currencyClient.getCurrencyById(this.id, "1.0").subscribe(r => {
      this.currency = r
    }, err => defaultRequestErrorHandler(this.layoutService, err));
  }

  save() {
    this.currencyClient.updateCurrency(this.id, this.currency, "1.0").subscribe(r => {
      this.router.navigate(['/dictionary/currencies']);
    }, err => defaultRequestErrorHandler(this.layoutService, err));
  }

}
