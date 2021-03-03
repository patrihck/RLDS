import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { defaultRequestErrorHandler } from '../../../../infrastructure/interceptors/error-interceptor';
import { NewTransactionCategory, TransactionCategoryClient } from '../../../../infrastructure/services-api/rlds-api';
import { LayoutService } from '../../../../infrastructure/services/layout/layout.service';

@Component({
  selector: 'app-add-transaction-category',
  templateUrl: './add-transaction-category.component.html',
  styleUrls: ['./add-transaction-category.component.css']
})
export class AddTransactionCategoryComponent implements OnInit {

  category: NewTransactionCategory;

  constructor(private readonly categoryClient: TransactionCategoryClient,
    private readonly router: Router,
    private readonly layoutService: LayoutService) { }

  ngOnInit(): void {
    this.category = new NewTransactionCategory();
  }

  save() {
    this.categoryClient.addTransactionCategory(this.category, "1.0").subscribe(r => {
      this.router.navigate(['/dictionary/transaction-categories']);
    }, err => defaultRequestErrorHandler(this.layoutService, err));
  }
}
