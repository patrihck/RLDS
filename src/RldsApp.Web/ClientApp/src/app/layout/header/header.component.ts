import { Component, OnInit } from '@angular/core';
import { Helper } from '../../../infrastructure/helpers/helper';
import { LayoutService } from '../../../infrastructure/services/layout/layout.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  constructor(private readonly layoutService: LayoutService) { }

  ngOnInit(): void {
  }

  get viewName() {
    return this.layoutService.getViewName;
  }
  get userName() {
    return `${Helper.GetSessionValue('userFirstName')} ${Helper.GetSessionValue('userLastName')}`;
  }
  get userAvatar(): string {
    return null;
  }


  showUserName() {
    return Helper.IsUserLogedIn();
  }

}
