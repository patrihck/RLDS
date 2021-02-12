import { Component, Input, OnInit } from '@angular/core';
import { MainMenuItem } from '../../../../infrastructure/models/layout/main-menu-item.model';

@Component({
  selector: 'app-menu-item',
  templateUrl: './menu-item.component.html',
  styleUrls: ['./menu-item.component.scss']
})
export class MenuItemComponent implements OnInit {

  @Input() item: MainMenuItem;

  constructor() { }

  ngOnInit(): void {
  }

}
