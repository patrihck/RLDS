import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SharedModule } from '../shared/shared.module';
import { AccountViewComponent } from './accounts/account-view/account-view.component';
import { AccountsComponent } from './accounts/accounts.component';
import { AddAccountComponent } from './accounts/add-account/add-account.component';
import { EditAccountComponent } from './accounts/edit-account/edit-account.component';
import { HomeComponent } from './home/home.component';
import { UsersComponent } from './users/users.component';
import { AddTransactionComponent } from './accounts/add-transaction/add-transaction.component';
import { AddUserComponent } from './users/add-user/add-user.component';
import { EditTransactionComponent } from './accounts/edit-transaction/edit-transaction.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'home', component: HomeComponent, pathMatch: 'full' },

  { path: 'accounts', component: AccountsComponent, pathMatch: 'full' },
  { path: 'accounts/add', component: AddAccountComponent, pathMatch: 'full' },
  { path: 'accounts/edit/:id', component: EditAccountComponent, pathMatch: 'full' },
  { path: 'account/view/:id', component: AccountViewComponent, pathMatch: 'full' },
  { path: 'users/add', component: AddUserComponent, pathMatch: 'full' },
  { path: 'users', component: UsersComponent, pathMatch: 'full' },
  { path: 'transactions/add', component: AddTransactionComponent, pathMatch: 'full' },
  { path: 'transactions/edit/:id', component: EditTransactionComponent, pathMatch: 'full' },

];

@NgModule({
  declarations: [HomeComponent, EditTransactionComponent, AccountsComponent,
    UsersComponent, AddAccountComponent, EditAccountComponent, AccountViewComponent, AddTransactionComponent, AddUserComponent],
  imports: [SharedModule, RouterModule.forChild(routes)],

  exports: [RouterModule]
})
export class RldsRoutingModule { }
