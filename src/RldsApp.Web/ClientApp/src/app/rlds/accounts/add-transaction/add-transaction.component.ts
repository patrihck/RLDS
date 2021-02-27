import { Component, OnInit } from '@angular/core';
import { NewTransaction, TransactionsClient, RecurringTransaction, RecurringTransactionsClient, User, UsersClient, Transaction, TransactionStatus, TransactionStatusClient, TransactionType, TransactionTypesClient, Currency, CurrencyClient, TransactionCategoryClient, TransactionCategory, AccountsClient, Account, UserLeaf } from '../../../../infrastructure/services-api/rlds-api';
import { LayoutService, MessageSeverity } from '../../../../infrastructure/services/layout/layout.service';
import { Router } from '@angular/router';
import { Helper } from '../../../../infrastructure/helpers/helper';
import { defaultRequestErrorHandler } from '../../../../infrastructure/interceptors/error-interceptor';

@Component({
  selector: 'app-add-transaction',
  templateUrl: './add-transaction.component.html',
  styleUrls: ['./add-transaction.component.css']
})

export class AddTransactionComponent implements OnInit {
  currencies: Array<Currency>;
  transactionData: NewTransaction;
  accounts: Array<Account>;
  categories: Array<TransactionCategory>;
  statuses : Array<TransactionStatus>;
  types : Array<TransactionType>;
  users: Array<User>;
  recuringTransactions: Array<RecurringTransaction>;

  constructor(private readonly layoutService: LayoutService,
    private readonly currencyClient: CurrencyClient,
    private readonly transactionCategoryClient: TransactionCategoryClient,
    private readonly accountsClient: AccountsClient,
    private readonly transactionTypesClient: TransactionTypesClient,
    private readonly transactionStatusClient: TransactionStatusClient,
    private readonly usersClient: UsersClient,
    private readonly recuringTransactionClient: RecurringTransactionsClient,
    private readonly transactonsClient: TransactionsClient,
    private readonly router: Router) { }

  ngOnInit(): void {
    this.transactionData = new NewTransaction();
    this.transactionData.receiver = new Account();
    //this.transactionData.recurringTransaction = new RecurringTransaction();
    this.transactionData.sender = new Account();
    this.transactionData.sender.id = Helper.GetCurrentUser().id;
    this.transactionData.user = new UserLeaf();
    this.transactionData.user.id = Helper.GetCurrentUser().id;
    this.transactionData.type = new TransactionType();
    this.transactionData.status = new TransactionStatus();
    this.transactionData.currency = new Currency();
    this.transactionData.category = new TransactionCategory();
    this.transactionData.category.name = "PLACEHOLDER";

    this.getData();
    this.layoutService.setAppTitle("Add Transaction");
  }

  getData() {
    this.accountsClient.getAccount("1.0").subscribe(r => {
      this.accounts = r.items;
    });
    this.currencyClient.getCurrencies("1.0").subscribe(result => {
      this.currencies = result.items;
    });

    this.transactionCategoryClient.getTransactionCategories( "1.0").subscribe(r => {
      this.categories = r.items;
    });

    this.transactionTypesClient.getTransactionTypes( "1.0").subscribe(r => {
      this.types = r.items;
    });

    this.transactionStatusClient.getTransactionStatus( "1.0").subscribe(r => {
      this.statuses = r.items;
    });

    this.usersClient.getUsers( "1.0").subscribe(r => {
      this.users = r.items;
    });
  }

  save() {
    this.layoutService.showPopover(MessageSeverity.success, "Dodawanie");

    this.transactonsClient.addTransaction(this.transactionData, '1.0').subscribe(result => {
      this.layoutService.showPopover(MessageSeverity.success, "Pomyślnie dodano konto");
      this.router.navigate(['/rlds/accounts'])
    }, error => defaultRequestErrorHandler(this.layoutService, error))
  }

}
