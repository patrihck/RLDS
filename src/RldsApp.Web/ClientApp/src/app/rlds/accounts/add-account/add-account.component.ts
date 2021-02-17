import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Helper } from '../../../../infrastructure/helpers/helper';
import { defaultRequestErrorHandler } from '../../../../infrastructure/interceptors/error-interceptor';
import { AccountsClient, Currency, CurrencyClient, NewAccount, UserLeaf } from '../../../../infrastructure/services-api/rlds-api';
import { LayoutService, MessageSeverity } from '../../../../infrastructure/services/layout/layout.service';

@Component({
  selector: 'app-add-account',
  templateUrl: './add-account.component.html',
  styleUrls: ['./add-account.component.css']
})
export class AddAccountComponent implements OnInit {
  newAccount: NewAccount;
  currencies: Array<Currency>;

  currencyId: any;

  constructor(private readonly accountsClient: AccountsClient,
    private readonly router: Router,
    private readonly currencyClient: CurrencyClient,
    private readonly layoutService: LayoutService) { }

  ngOnInit(): void {
    this.newAccount = new NewAccount();
    this.newAccount.user = new UserLeaf();
    this.newAccount.currency = new Currency();
    this.newAccount.currency.id = null;

    this.newAccount.user.id = Helper.GetCurrentUser().id;
    this.getData();

    this.layoutService.setAppTitle("Dodawanie konta");
  }

  getData() {
    this.currencyClient.getCurrencies("1.0").subscribe(result => {
      this.currencies = result.items;
    });
  }

  save() {
    this.layoutService.showPopover(MessageSeverity.success, "Dodawanie");

    this.accountsClient.addAccount(this.newAccount, '1.0').subscribe(result => {
      this.layoutService.showPopover(MessageSeverity.success, "Pomyślnie dodano konto");
      this.router.navigate(['/rlds/accounts'])
    }, error => defaultRequestErrorHandler(this.layoutService, error))
  }
}
