import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { Helper } from '../../../infrastructure/helpers/helper';
import { defaultRequestErrorHandler } from '../../../infrastructure/interceptors/error-interceptor';
import { LoginData, UsersClient } from '../../../infrastructure/services-api/rlds-api';
import { LayoutService, MessageSeverity } from '../../../infrastructure/services/layout/layout.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginData: LoginData = null;

  constructor(private readonly authClient: UsersClient,
    private readonly router: Router,
    private readonly layoutService: LayoutService) { }

  ngOnInit(): void {
    this.loginData = new LoginData();
  }

  onLogin() {
    this.authClient.authenticateUser(this.loginData, "1.0").subscribe(result => {
      this.layoutService.showPopover(MessageSeverity.success, "Zalogowano");

      Helper.SetSessionValue('token', result.token);
      this.authClient.getUserById(result.userId, '1.0').subscribe(user => {
        Helper.SetUserData(result, user);
        this.router.navigate(['/']);
      }, error => defaultRequestErrorHandler(this.layoutService, error));

    }, error => defaultRequestErrorHandler(this.layoutService, error));
  }

}
