import { Component, OnInit } from '@angular/core';
import { NewTransaction, TransactionsClient, RecurringRule, RecurringRulesClient, User, UsersClient, Transaction, TransactionStatus, TransactionStatusClient, TransactionType, TransactionTypesClient, Currency, CurrencyClient, TransactionCategoryClient, TransactionCategory, AccountsClient, Account, UserLeaf } from '../../../../infrastructure/services-api/rlds-api';
import { LayoutService, MessageSeverity } from '../../../../infrastructure/services/layout/layout.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Helper } from '../../../../infrastructure/helpers/helper';
import { defaultRequestErrorHandler } from '../../../../infrastructure/interceptors/error-interceptor';

@Component({
  selector: 'app-edit-transaction',
  templateUrl: './edit-transaction.component.html',
  styleUrls: ['./edit-transaction.component.css']
})

export class EditTransactionComponent implements OnInit {

  transactionDate: Date;
  id: number;
  currencies: Array<Currency>;
  transactionData: Transaction;
  accounts: Array<Account>;
  categories: Array<TransactionCategory>;
  statuses: Array<TransactionStatus>;
  types: Array<TransactionType>;
  users: Array<User>;
  recuringTransactions: Array<RecurringRule>;

  constructor(private readonly route: ActivatedRoute,
    private readonly layoutService: LayoutService,
    private readonly currencyClient: CurrencyClient,
    private readonly transactionCategoryClient: TransactionCategoryClient,
    private readonly accountsClient: AccountsClient,
    private readonly transactionTypesClient: TransactionTypesClient,
    private readonly transactionStatusClient: TransactionStatusClient,
    private readonly usersClient: UsersClient,
    private readonly recuringTransactionClient: RecurringRulesClient,
    private readonly transactonsClient: TransactionsClient,
    private readonly router: Router) { }

  ngOnInit(): void {
    this.layoutService.setAppTitle("Add Transaction");

    this.route.paramMap.subscribe(paramMap => {
      this.id = +paramMap.get('id');
      this.getData();
    })
  }

  getData() {
    this.transactonsClient.getTransactionById(this.id, '1.0').subscribe(result => {
      this.transactionData = result;
      this.transactionDate = new Date(result.date);
    }, error => defaultRequestErrorHandler(this.layoutService, error))

    this.accountsClient.getAccount("1.0").subscribe(r => {
      this.accounts = r.items.filter(acc => acc.user.id != Helper.GetCurrentUser().id);
      this.accounts.forEach(acc => {
        acc.name = `${acc.user.firstname} ${acc.user.lastname} - ${acc.name}`
      })
    });
    this.currencyClient.getCurrencies("1.0").subscribe(result => {
      this.currencies = result.items;
    });

    this.transactionCategoryClient.getTransactionCategories("1.0").subscribe(r => {
      this.categories = r.items;
    });

    this.transactionTypesClient.getTransactionTypes("1.0").subscribe(r => {
      this.types = r.items;
    });

    this.transactionStatusClient.getTransactionStatus("1.0").subscribe(r => {
      this.statuses = r.items;
    });

    this.usersClient.getUsers("1.0").subscribe(r => {
      this.users = r.items;
    });
  }

  save() {
    this.transactionData.sender.links = [];
    this.transactionData.sender.user.links = [];
    this.transactionData.sender.currency.links = [];
    this.transactionData.receiver.links = [];
    this.transactionData.receiver.user.links = [];
    this.transactionData.receiver.currency.links = [];

    this.transactionData.date = this.transactionDate.toLocaleDateString();
    this.transactonsClient.updateTransaction(this.id, this.transactionData, '1.0').subscribe(result => {
      this.layoutService.showPopover(MessageSeverity.success, "Pomyślnie zapisano konto");
      this.router.navigate(['/rlds/accounts'])
    }, error => defaultRequestErrorHandler(this.layoutService, error))
  }

}
