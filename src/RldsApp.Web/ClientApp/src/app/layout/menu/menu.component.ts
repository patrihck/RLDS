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
      opts.url = '/veolia/dashboard'
    }));

    this.menuItems.push(new MainMenuItem(opts => {
      opts.name = 'Planowanie';
      opts.icon = 'fa fa-code-branch';
      opts.url = '/veolia/planning'
    }));

    this.menuItems.push(new MainMenuItem(opts => {
      opts.name = 'Awizacje';
      opts.icon = 'fa fa-check-circle';
      opts.url = '/veolia/monitory-note'
    }));

    this.menuItems.push(new MainMenuItem(opts => {
      opts.name = 'Kierowcy';
      opts.icon = 'fa fa-id-card';
      opts.url = '/veolia/drivers'
    }));

    this.menuItems.push(new MainMenuItem(opts => {
      opts.name = 'Pojazdy';
      opts.icon = 'fa fa-truck';
      opts.url = '/veolia/vehicles'
    }));

    this.menuItems.push(new MainMenuItem(opts => {
      opts.name = 'Kontrahenci';
      opts.icon = 'fa fa-users';
      opts.url = '/veolia/contractors'
    }));

    this.menuItems.push(new MainMenuItem(opts => {
      opts.name = 'Asortyment';
      opts.icon = 'fa fa-archive';
      opts.url = '/veolia/asortment'
    }));

    this.menuItems.push(new MainMenuItem(opts => {
      opts.name = 'Raporty';
      opts.icon = 'fa fa-chart-bar';
      opts.url = '/veolia/raports'
    }));

    this.menuItems.push(new MainMenuItem(opts => {
      opts.name = 'Panel administracyjny';
      opts.icon = 'fa fa-sliders';
      opts.url = '/administration'
    }));
  }

  ngOnInit(): void {
  }

}
