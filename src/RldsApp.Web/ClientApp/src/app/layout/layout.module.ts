import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MenuComponent } from './menu/menu.component';
import { MenuItemComponent } from './menu/menu-item/menu-item.component';
import { SharedModule } from '../shared/shared.module';
import { HeaderComponent } from './header/header.component';



@NgModule({
  declarations: [
    HeaderComponent,
    MenuComponent,
    MenuItemComponent,
  ],
  imports: [
    CommonModule,
    SharedModule
  ], exports: [
    MenuComponent,
    HeaderComponent
  ]
})
export class LayoutModule { }
