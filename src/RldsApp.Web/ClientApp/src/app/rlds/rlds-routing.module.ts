import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SharedModule } from '../shared/shared.module'; 
import { AccountsComponent } from './accounts/accounts.component';
import { AddAccountComponent } from './accounts/add-account/add-account.component';
import { EditAccountComponent } from './accounts/edit-account/edit-account.component';
import { HomeComponent } from './home/home.component';
import { UsersComponent } from './users/users.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'home', component: HomeComponent, pathMatch: 'full' },

  { path: 'accounts', component: AccountsComponent, pathMatch: 'full' },
  { path: 'accounts/add', component: AddAccountComponent, pathMatch: 'full' },
  { path: 'accounts/edit/:id', component: EditAccountComponent, pathMatch: 'full' },

  { path: 'users', component: UsersComponent, pathMatch: 'full' },
];

@NgModule({
  declarations: [HomeComponent, AccountsComponent, UsersComponent, AddAccountComponent, EditAccountComponent],
  imports: [SharedModule, RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RldsRoutingModule { }
