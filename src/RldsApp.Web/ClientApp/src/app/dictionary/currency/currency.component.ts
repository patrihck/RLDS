import { Component, OnInit } from '@angular/core';
import { defaultRequestErrorHandler } from '../../../infrastructure/interceptors/error-interceptor';
import { PrimengTableColumn } from '../../../infrastructure/models/layout/primeng-table.model';
import { Currency, CurrencyClient, PagedDataInquiryResponseOfCurrency } from '../../../infrastructure/services-api/rlds-api';
import { LayoutService, MessageSeverity } from '../../../infrastructure/services/layout/layout.service';

@Component({
  selector: 'app-currency',
  templateUrl: './currency.component.html',
  styleUrls: ['./currency.component.css']
})
export class CurrencyComponent implements OnInit {
  currencies: PagedDataInquiryResponseOfCurrency;
  columns: Array<PrimengTableColumn>;

  constructor(private readonly currencyClient: CurrencyClient, private readonly layoutService: LayoutService) { }

  ngOnInit(): void {
    this.layoutService.setAppTitle("Konta");
    this.createTable();
    this.getData();
  }

  getData() {
    this.currencyClient.getCurrencies("1.0").subscribe(r => {
      this.currencies = r;
    }, err => defaultRequestErrorHandler(this.layoutService, err))
  }
  createTable() {
    this.columns = new Array<PrimengTableColumn>();

    this.columns.push(new PrimengTableColumn(o => {
      o.field = 'id';
      o.header = 'Id';
    }));
    this.columns.push(new PrimengTableColumn(o => {
      o.field = 'name';
      o.header = 'Nazwa';
    }));
    this.columns.push(new PrimengTableColumn(o => {
      o.field = 'acronym';
      o.header = 'Akromin';
    }));
    this.columns.push(new PrimengTableColumn(o => {
      o.field = 'symbol';
      o.header = 'Symbol';
    }));
    this.columns.push(new PrimengTableColumn(o => {
      o.header = '';
      o.field = 'options';
    }));
  }

  remove(id: number) {
    this.currencyClient.deleteCurrency(id, '1.0').subscribe(r => {
      this.layoutService.showPopover(MessageSeverity.success, 'Usunięto walutę');
    }, err => defaultRequestErrorHandler(this.layoutService, err));
  }
}
