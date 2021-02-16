import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MainMenuItem } from '../../../../infrastructure/models/layout/main-menu-item.model';

@Component({
  selector: 'app-menu-item',
  templateUrl: './menu-item.component.html',
  styleUrls: ['./menu-item.component.scss']
})
export class MenuItemComponent implements OnInit {

  @Input() item: MainMenuItem;

  constructor(private readonly router: Router) { }

  ngOnInit(): void {
  }

  onClick() {
    if (this.item.onClick)
      this.item.onClick();
    else
    this.router.navigate([this.item.url])
  }

}
