import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-card-view',
  templateUrl: './card-view.component.html',
  styleUrls: ['./card-view.component.scss']
})
export class CardViewComponent implements OnInit {

  @Input() cardTitle: string;
  @Input() cardSize: 'small' | 'middle' | 'big';

  constructor() { }

  ngOnInit() {
  }

}
