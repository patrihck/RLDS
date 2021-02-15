import { Component, OnInit } from '@angular/core';
import { MainMenuItem } from '../../../infrastructure/models/layout/main-menu-item.model';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {

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
      opts.name = 'Logowanie';
      opts.icon = 'fa fa-th-large';
      opts.url = 'user/login'
    }));

    this.menuItems.push(new MainMenuItem(opts => {
      opts.name = 'Profil';
      opts.icon = 'fa fa-th-large';
      opts.url = 'user/profil'
    }));

    this.menuItems.push(new MainMenuItem(opts => {
      opts.name = 'Konta';
      opts.icon = 'fa fa-th-large';
      opts.url = 'rlds/account'
    }));

    this.menuItems.push(new MainMenuItem(opts => {
      opts.name = 'Użytkownicy';
      opts.icon = 'fa fa-th-large';
      opts.url = 'rlds/users'
    }));

  }

  ngOnInit(): void {
  }

}
