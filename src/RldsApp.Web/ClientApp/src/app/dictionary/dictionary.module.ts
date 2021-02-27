import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DictionaryRoutingModule } from './dictionary-routing.module';
import { CurrencyComponent } from './currency/currency.component';
import { TransactionCategoryComponent } from './transaction-category/transaction-category.component';
import { AddCurrencyComponent } from './currency/add-currency/add-currency.component';
import { EditCurrencyComponent } from './currency/edit-currency/edit-currency.component';
import { AddTransactionCategoryComponent } from './transaction-category/add-transaction-category/add-transaction-category.component';
import { EditTransactionCategoryComponent } from './transaction-category/edit-transaction-category/edit-transaction-category.component';


@NgModule({
  declarations: [CurrencyComponent, TransactionCategoryComponent, AddCurrencyComponent, EditCurrencyComponent, AddTransactionCategoryComponent, EditTransactionCategoryComponent],
  imports: [
    CommonModule,
    DictionaryRoutingModule
  ]
})
export class DictionaryModule { }
