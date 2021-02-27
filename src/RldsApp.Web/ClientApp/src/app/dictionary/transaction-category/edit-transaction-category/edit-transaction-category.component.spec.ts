import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditTransactionCategoryComponent } from './edit-transaction-category.component';

describe('EditTransactionCategoryComponent', () => {
  let component: EditTransactionCategoryComponent;
  let fixture: ComponentFixture<EditTransactionCategoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditTransactionCategoryComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditTransactionCategoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
