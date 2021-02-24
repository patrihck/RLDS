import { Component, OnInit } from '@angular/core';
import { MessageSeverity, LayoutService } from 'src/infrastructure/services/layout/layout.service';
import { NewUser, Role, RolesClient, UsersClient } from '../../../../infrastructure/services-api/rlds-api';
import { Router } from '@angular/router';
import { defaultRequestErrorHandler } from '../../../../infrastructure/interceptors/error-interceptor';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class AddUserComponent implements OnInit {

  newUser: NewUser;
  constructor(private readonly rolesClient: RolesClient,
    private readonly layoutService: LayoutService,
    private readonly usersClient: UsersClient,
    private readonly router: Router) { }

  ngOnInit(): void {
    this.newUser = new NewUser();
    this.newUser.roles = new Array<Role>();
  }

  save() {
    this.layoutService.showPopover(MessageSeverity.success, "Dodawanie");

    this.usersClient.addUser(this.newUser, '1.0').subscribe(result => {
      this.layoutService.showPopover(MessageSeverity.success, "Pomyślnie dodano konto");
      this.router.navigate(['/rlds/accounts'])
    }, error => defaultRequestErrorHandler(this.layoutService, error))
  }

}
