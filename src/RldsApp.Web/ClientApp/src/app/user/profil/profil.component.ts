import { Component, OnInit } from '@angular/core';
import { Helper } from '../../../infrastructure/helpers/helper';
import { User, UsersClient } from '../../../infrastructure/services-api/rlds-api';
import { LayoutService } from '../../../infrastructure/services/layout/layout.service';

@Component({
  selector: 'app-profil',
  templateUrl: './profil.component.html',
  styleUrls: ['./profil.component.css']
})
export class ProfilComponent implements OnInit {

  userData: User;

  constructor(private readonly layoutService: LayoutService, private readonly authClient: UsersClient) { }

  ngOnInit(): void {
    this.layoutService.setAppTitle("Profil");
    this.authClient.getUserById(Helper.GetSessionValueOfType<number>('userId'), '1.0').subscribe(result => {
      this.userData = result;
      console.log(result)
    });
  }

}
