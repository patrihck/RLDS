import { Component, OnInit } from '@angular/core';
import { Helper } from '../../../infrastructure/helpers/helper';
import { MainMenuItem } from '../../../infrastructure/models/layout/main-menu-item.model';
import { UsersClient } from '../../../infrastructure/services-api/rlds-api';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent {

  menuItems: Array<MainMenuItem>;

  constructor() {
    this.initMenu();
  }

  initMenu() {
    this.menuItems = new Array<MainMenuItem>();

    this.menuItems.push(new MainMenuItem(opts => {
      opts.name = 'Strona główna';
      opts.icon = 'fa fa-th-large';
      opts.url = 'rlds/home'
    }));

    this.menuItems.push(new MainMenuItem(opts => {
      opts.name = 'Profil';
      opts.icon = 'fa fa-th-large';
      opts.url = 'user/profil'
      opts.displayCondition = () => { return !Helper.IsNullOrEmpty(Helper.GetSessionValue('token')) }
    }));

    this.menuItems.push(new MainMenuItem(opts => {
      opts.name = 'Konta';
      opts.icon = 'fa fa-th-large';
      opts.url = 'rlds/accounts'
      opts.displayCondition = () => { return !Helper.IsNullOrEmpty(Helper.GetSessionValue('token')) }
    }));

    this.menuItems.push(new MainMenuItem(opts => {
      opts.name = 'Użytkownicy';
      opts.icon = 'fa fa-th-large';
      opts.url = 'rlds/users'
      opts.displayCondition = () => { return !Helper.IsNullOrEmpty(Helper.GetSessionValue('token')) }
    }));



    this.menuItems.push(new MainMenuItem(opts => {
      opts.name = 'Logowanie';
      opts.icon = 'fa fa-th-large';
      opts.url = 'user/login'
      opts.displayCondition = () => { return Helper.IsNullOrEmpty(Helper.GetSessionValue('token')) }
    }));

    this.menuItems.push(new MainMenuItem(opts => {
      opts.name = 'Wyloguj';
      opts.icon = 'fa fa-th-large';
      opts.onClick = () => {
        Helper.RemoveUserData();
      }
      opts.displayCondition = () => { return !Helper.IsNullOrEmpty(Helper.GetSessionValue('token')) }
    }));

  }

  get getMenuItems() {
    return this.menuItems.filter(item => {
      return !item.displayCondition || item.displayCondition()
    })
  }

}
