import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TableModule } from 'primeng/table';
import { EditorModule } from 'primeng/editor';
import { BreadcrumbModule } from 'primeng/breadcrumb';
import { ToastModule } from 'primeng/toast';
import { CheckboxModule } from 'primeng/checkbox';
import { RadioButtonModule } from 'primeng/radiobutton';
import { DropdownModule } from 'primeng/dropdown';
import { TooltipModule } from 'primeng/tooltip';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { TabViewModule } from 'primeng/tabview';
import { BlockUIModule } from 'primeng/blockui';
import { PanelModule } from 'primeng/panel';
import { SidebarModule } from 'primeng/sidebar';
import { ListboxModule } from 'primeng/listbox';
import { CalendarModule } from 'primeng/calendar';
import { MultiSelectModule } from 'primeng/multiselect';
import { CardModule } from 'primeng/card';
import { InputSwitchModule } from 'primeng/inputswitch';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { InputTextModule } from 'primeng/inputtext'; 
import { InputTextareaModule } from 'primeng/inputtextarea';
import { PasswordModule } from 'primeng/password';
import { ChartModule } from 'primeng/chart';
import { CarouselModule } from 'primeng/carousel';

// https://www.primefaces.org/primeng/showcase/#/setup
@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    EditorModule,
    BreadcrumbModule,
    CarouselModule,
    PanelModule,
    ChartModule,
    InputTextModule,
    CommonModule,
    InputSwitchModule,
    TableModule,
    ToastModule,
    BlockUIModule,
    ListboxModule,
    ConfirmDialogModule,
    TabViewModule,
    ReactiveFormsModule,
    SidebarModule,
    PasswordModule,
    FormsModule,
    CheckboxModule,
    RadioButtonModule,
    DropdownModule,
    RouterModule,
    InputTextareaModule,
    TooltipModule,
    CalendarModule,
    MultiSelectModule
  ],
  exports: [
    CardModule,
    InputSwitchModule,
    ListboxModule,
    EditorModule,
    ChartModule,
    SidebarModule,
    BreadcrumbModule,
    BlockUIModule,
    CarouselModule,
    PanelModule,
    CommonModule,
    PasswordModule,
    TabViewModule,
    InputTextareaModule,
    ConfirmDialogModule,
    TableModule,
    ToastModule,
    ReactiveFormsModule,
    FormsModule,
    CheckboxModule,
    InputTextModule,
    RadioButtonModule,
    DropdownModule,
    RouterModule,
    TooltipModule,
    CalendarModule,
    MultiSelectModule,
  ]
})
export class SharedModule { }
