import { Injectable, ElementRef } from '@angular/core';
import { MessageService, Message, ConfirmationService } from 'primeng/api';
import { Title } from '@angular/platform-browser';
import { Helper } from '../../helpers/helper';

@Injectable({
  providedIn: 'root'
})
export class LayoutService {

  private menuHidden: boolean = false;
  private viewName: string;

  constructor(
    private readonly messageService: MessageService,
    private readonly titleService: Title,
    private readonly confirmationService: ConfirmationService) {
  }


  public isMenuHidden() { return this.menuHidden; }
  public showMenu() { this.menuHidden = false; }
  public hideMenu() { this.menuHidden = true; }

  showPopoverBase(message: NgMessage) {
    this.messageService.add({ severity: message.severity, detail: message.detail, life: message.life });
  }
  showPopover(severity: MessageSeverity, detail: string, life: number = 5000) {
    this.messageService.add({ severity: severity, detail: detail, life: life });
  }

  setViewName(title: string) {
    this.viewName = title;
  }
  get getViewName() {
    return this.viewName;
  }
  setAppTitle(title: string) {
    this.titleService.setTitle(`RldsApp ${Helper.IsNullOrEmpty(title) ? '' : '-'} ${title}`);
    this.setViewName(title);
  }

  createDeleteMessage(message: string, acceptEvent: () => void, rejectEvent?: () => void) {
    this.confirmationService.confirm({
      icon: '',
      acceptLabel: 'Tak',
      rejectLabel: 'Nie',
      header: 'Potwierdzenie',
      acceptIcon: '',
      acceptButtonStyleClass: 'hrb-btn hrb-btn-primary',
      rejectButtonStyleClass: 'hrb-btn hrb-btn-secondary',
      rejectIcon: '',
      message: message,
      accept: () => {
        if (acceptEvent) acceptEvent();
      },
      reject: () => {
        if (rejectEvent) rejectEvent();
      }
    });
  }

}

export class NgMessage implements Message {
  severity?: MessageSeverity;
  summary?: string;
  detail?: string;
  id?: any;
  key?: string;
  life?: number;
  sticky?: boolean;
  closable?: boolean;
  data?: any;
}

export enum MessageSeverity {
  success = "success",
  info = "info",
  warn = "warn",
  error = "error",
}
