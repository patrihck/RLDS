import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddTransactionCategoryComponent } from './add-transaction-category.component';

describe('AddTransactionCategoryComponent', () => {
  let component: AddTransactionCategoryComponent;
  let fixture: ComponentFixture<AddTransactionCategoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddTransactionCategoryComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddTransactionCategoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
