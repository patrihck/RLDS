import { Component, OnInit } from '@angular/core';
import { defaultRequestErrorHandler } from '../../../infrastructure/interceptors/error-interceptor';
import { PrimengTableColumn } from '../../../infrastructure/models/layout/primeng-table.model';
import { PagedDataInquiryResponseOfTransactionCategory, TransactionCategory, TransactionCategoryClient } from '../../../infrastructure/services-api/rlds-api';
import { LayoutService, MessageSeverity } from '../../../infrastructure/services/layout/layout.service';

@Component({
  selector: 'app-transaction-category',
  templateUrl: './transaction-category.component.html',
  styleUrls: ['./transaction-category.component.css']
})
export class TransactionCategoryComponent implements OnInit {

  transactionCategories: PagedDataInquiryResponseOfTransactionCategory;
  columns: Array<PrimengTableColumn>;

  constructor(private readonly transactionCategoryClient: TransactionCategoryClient, private readonly layoutService: LayoutService) { }

  ngOnInit(): void {
    this.layoutService.setAppTitle("Konta");
    this.createTable();
    this.getData();
  }

  getData() {
    this.transactionCategoryClient.getTransactionCategories("1.0").subscribe(r => {
      this.transactionCategories = r;
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
      o.header = '';
      o.field = 'options';
    }));
  }

  remove(id: number) {
    this.transactionCategoryClient.deleteTransactionCategory(id, '1.0').subscribe(r => {
      this.layoutService.showPopover(MessageSeverity.success, 'Usunięto kategorię transakcji');
      this.getData();
    }, err => defaultRequestErrorHandler(this.layoutService, err));
  }
}
