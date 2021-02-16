import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SharedModule } from '../shared/shared.module';
import { AccountComponent } from './account/account.component';
import { HomeComponent } from './home/home.component';
import { UsersComponent } from './users/users.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'home', component: HomeComponent, pathMatch: 'full' },
  { path: 'account', component: AccountComponent, pathMatch: 'full' },
  { path: 'users', component: UsersComponent, pathMatch: 'full' },
];

@NgModule({
  declarations: [HomeComponent, AccountComponent, UsersComponent],
  imports: [SharedModule, RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RldsRoutingModule { }
