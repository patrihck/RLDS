import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { defaultRequestErrorHandler } from '../../../../infrastructure/interceptors/error-interceptor';
import { NewTransactionCategory, TransactionCategoryClient } from '../../../../infrastructure/services-api/rlds-api';
import { LayoutService } from '../../../../infrastructure/services/layout/layout.service';

@Component({
  selector: 'app-edit-transaction-category',
  templateUrl: './edit-transaction-category.component.html',
  styleUrls: ['./edit-transaction-category.component.css']
})
export class EditTransactionCategoryComponent implements OnInit {

  id;
  category: NewTransactionCategory;

  constructor(private readonly categoryClient: TransactionCategoryClient,
    private readonly router: Router,
    private readonly route: ActivatedRoute,
    private readonly layoutService: LayoutService) { }

  ngOnInit(): void {

    this.route.paramMap.subscribe(paramMap => {
      this.id = +paramMap.get('id');
      this.getData();
    })
  }

  getData() {
    this.categoryClient.getTransactionCategoryById(this.id, "1.0").subscribe(r => {
      this.category = r
    }, err => defaultRequestErrorHandler(this.layoutService, err));
  }


  save() {
    this.categoryClient.updateTransactionCategory(this.id,this.category, "1.0").subscribe(r => {
      this.router.navigate(['/dictionary/transaction-categories']);
    }, err => defaultRequestErrorHandler(this.layoutService, err));
  }
}
