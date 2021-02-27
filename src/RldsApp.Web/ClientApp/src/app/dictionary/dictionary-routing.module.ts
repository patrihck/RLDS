import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddCurrencyComponent } from './currency/add-currency/add-currency.component';
import { CurrencyComponent } from './currency/currency.component';
import { EditCurrencyComponent } from './currency/edit-currency/edit-currency.component';
import { AddTransactionCategoryComponent } from './transaction-category/add-transaction-category/add-transaction-category.component';
import { EditTransactionCategoryComponent } from './transaction-category/edit-transaction-category/edit-transaction-category.component';
import { TransactionCategoryComponent } from './transaction-category/transaction-category.component';

const routes: Routes = [
  { path: 'currencies', component: CurrencyComponent, pathMatch: 'full' },
  { path: 'currency/add', component: AddCurrencyComponent, pathMatch: 'full' },
  { path: 'currency/edit/:id', component: EditCurrencyComponent, pathMatch: 'full' },


  { path: 'transaction-categories', component: TransactionCategoryComponent, pathMatch: 'full' },
  { path: 'transaction-category/add', component: AddTransactionCategoryComponent, pathMatch: 'full' },
  { path: 'transaction-category/edit/:id', component: EditTransactionCategoryComponent, pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DictionaryRoutingModule { }
