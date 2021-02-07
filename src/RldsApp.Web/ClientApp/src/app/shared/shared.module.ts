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
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { InputTextModule } from 'primeng/inputtext';
import { InputTextareaModule } from 'primeng/inputtextarea';

// https://www.primefaces.org/primeng/showcase/#/setup
@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    EditorModule,
    BreadcrumbModule,
    PanelModule,
    InputTextModule,
    CommonModule,
    InputSwitchModule,
    TableModule,
    ToastModule,
    BlockUIModule,
    BrowserAnimationsModule,
    ListboxModule,
    ConfirmDialogModule,
    TabViewModule,
    ReactiveFormsModule,
    SidebarModule,
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
    BrowserAnimationsModule,
    SidebarModule,
    BreadcrumbModule,
    BlockUIModule,
    PanelModule,
    CommonModule,
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
