import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PrimengTableColumn } from '../../../../infrastructure/models/layout/primeng-table.model';
import { Account, AccountsClient, Currency, CurrencyClient, RecurringTransaction, Transaction, TransactionsClient } from '../../../../infrastructure/services-api/rlds-api';
import { LayoutService } from '../../../../infrastructure/services/layout/layout.service';

@Component({
  selector: 'app-account-view',
  templateUrl: './account-view.component.html',
  styleUrls: ['./account-view.component.css']
})
export class AccountViewComponent implements OnInit {

  id: number;
  account: Account;
  currencies: Array<Currency>;
  transactions: Array<Transaction>;

  recurringTransaction?: RecurringTransaction | undefined;

  cols: Array<PrimengTableColumn>;

  constructor(private readonly route: ActivatedRoute,
    private readonly accountsClient: AccountsClient,
    private readonly transactionClient: TransactionsClient,
    private readonly currencyClient: CurrencyClient,
    private readonly layoutService: LayoutService) {
    this.layoutService.setAppTitle("Szczegóły konta");

  }

  ngOnInit(): void {
    this.createTable();

    this.route.paramMap.subscribe(paramMap => {
      this.id = +paramMap.get('id');
      this.getData();
    })
  }

  createTable() {
    this.cols = new Array<PrimengTableColumn>();
    this.cols.push(new PrimengTableColumn(o => {
      o.header = 'id';
      o.field = 'id';
    }));
    this.cols.push(new PrimengTableColumn(o => {
      o.header = 'date';
      o.field = 'date';
    }));
    this.cols.push(new PrimengTableColumn(o => {
      o.header = 'user';
      o.field = 'user';
    }));
    this.cols.push(new PrimengTableColumn(o => {
      o.header = 'sender';
      o.field = 'sender';
    }));
    this.cols.push(new PrimengTableColumn(o => {
      o.header = 'receiver';
      o.field = 'receiver';
    }));
    this.cols.push(new PrimengTableColumn(o => {
      o.header = 'type';
      o.field = 'type';
    }));
    this.cols.push(new PrimengTableColumn(o => {
      o.header = 'category';
      o.field = 'category';
    }));
    this.cols.push(new PrimengTableColumn(o => {
      o.header = 'status';
      o.field = 'status';
    }));
    this.cols.push(new PrimengTableColumn(o => {
      o.header = 'currency';
      o.field = 'currency';
    }));
    this.cols.push(new PrimengTableColumn(o => {
      o.header = 'description';
      o.field = 'description';
    }));
    this.cols.push(new PrimengTableColumn(o => {
      o.header = 'amount';
      o.field = 'amount';
    }));
    this.cols.push(new PrimengTableColumn(o => {
      o.header = 'recurringTransaction';
      o.field = 'recurringTransaction';
    }));
  }

  getData() {
    this.accountsClient.getAccountById(this.id, "1.0").subscribe(r => {
      this.account = r;
    });
    this.currencyClient.getCurrencies("1.0").subscribe(result => {
      this.currencies = result.items;
    });

    this.transactionClient.getTransactionsByAccountId(this.id, "1.0").subscribe(r => {
      this.transactions = r.items;
    })
  }

} 
