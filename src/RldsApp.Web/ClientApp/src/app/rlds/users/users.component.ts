import { Component, OnInit } from '@angular/core';  
import { defaultRequestErrorHandler } from '../../../infrastructure/interceptors/error-interceptor';
import { PrimengTableColumn } from '../../../infrastructure/models/layout/primeng-table.model';
import { PagedDataInquiryResponseOfUser, User, UsersClient } from '../../../infrastructure/services-api/rlds-api';
import { LayoutService } from '../../../infrastructure/services/layout/layout.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  users: PagedDataInquiryResponseOfUser;
  cols: Array<PrimengTableColumn>;
  constructor(private readonly usersClient: UsersClient, private readonly layoutService: LayoutService) { }

  ngOnInit(): void {
    this.layoutService.setAppTitle("Użytkownicy");
    this.createTable();
    this.usersClient.getUsers('1.0').subscribe(result => {
      this.users = result;
    }, error => defaultRequestErrorHandler(this.layoutService, error))
  }

  createTable() {
    this.cols = new Array<PrimengTableColumn>();
    this.cols.push(new PrimengTableColumn(o => {
      o.header = 'id';
      o.field = 'id';
    }));
    this.cols.push(new PrimengTableColumn(o => {
      o.header = 'login';
      o.field = 'login';
    }));
    this.cols.push(new PrimengTableColumn(o => {
      o.header = 'firstname';
      o.field = 'firstname';
    }));
    this.cols.push(new PrimengTableColumn(o => {
      o.header = 'lastname';
      o.field = 'lastname';
    }));
    this.cols.push(new PrimengTableColumn(o => {
      o.header = 'email';
      o.field = 'email';
    }));
    this.cols.push(new PrimengTableColumn(o => {
      o.header = 'startAmount';
      o.field = 'startAmount';
    }));
    this.cols.push(new PrimengTableColumn(o => {
      o.header = 'roles';
      o.field = 'roles';
    }));
  }

  getUserRoles(item: User) {
    return item.roles.map(r => r.roleName)
  }
}   
