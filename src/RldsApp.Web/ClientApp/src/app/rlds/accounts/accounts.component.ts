import { Component, OnInit } from '@angular/core';
import { Helper } from '../../../infrastructure/helpers/helper';
import { defaultRequestErrorHandler } from '../../../infrastructure/interceptors/error-interceptor';
import { PrimengTableColumn } from '../../../infrastructure/models/layout/primeng-table.model';
import { AccountsClient, PagedDataInquiryResponseOfAccount } from '../../../infrastructure/services-api/rlds-api';
import { LayoutService, MessageSeverity } from '../../../infrastructure/services/layout/layout.service';
import { LayoutModule } from '../../layout/layout.module';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountsComponent implements OnInit {

  accounts: PagedDataInquiryResponseOfAccount;
  cols: Array<PrimengTableColumn>;
  constructor(private readonly accountsClient: AccountsClient, private readonly layoutService: LayoutService) { }

  ngOnInit(): void {
    this.layoutService.setAppTitle("Konta");
    this.createTable();
    this.getData();
  }

  getData() {
    this.accountsClient.getAccountsByUserId(Helper.GetSessionValueOfType<number>('userId'), '1.0').subscribe(result => {
      this.accounts = result;
    }, error => defaultRequestErrorHandler(this.layoutService, error))
  }

  removeAccount(id) {
    this.accountsClient.deleteAccount(id, "1.0").subscribe(a => {
      this.layoutService.showPopover(MessageSeverity.success, "Usunięto konto");
      this.getData();
    });
  }

  createTable() {
    this.cols = new Array<PrimengTableColumn>();
    this.cols.push(new PrimengTableColumn(o => {
      o.header = 'id';
      o.field = 'id';
    }));
    this.cols.push(new PrimengTableColumn(o => {
      o.header = 'name';
      o.field = 'name';
    }));
    this.cols.push(new PrimengTableColumn(o => {
      o.header = 'user';
      o.field = 'user';
    }));
    this.cols.push(new PrimengTableColumn(o => {
      o.header = 'currency';
      o.field = 'currency';
    }));
    this.cols.push(new PrimengTableColumn(o => {
      o.header = 'group';
      o.field = 'group';
    }));
    this.cols.push(new PrimengTableColumn(o => {
      o.header = 'startAmount';
      o.field = 'startAmount';
    }));
    this.cols.push(new PrimengTableColumn(o => {
      o.header = '';
      o.field = 'options';
    }));
  }
}
