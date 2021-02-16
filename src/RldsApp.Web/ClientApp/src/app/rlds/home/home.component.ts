import { Component, OnInit } from '@angular/core';
import { LayoutService } from '../../../infrastructure/services/layout/layout.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private readonly layoutService: LayoutService) { }

  ngOnInit(): void {
    this.layoutService.setAppTitle("Strona główna");
  }

}
