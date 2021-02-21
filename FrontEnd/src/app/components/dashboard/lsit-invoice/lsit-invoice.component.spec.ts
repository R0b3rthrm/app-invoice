import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LsitInvoiceComponent } from './lsit-invoice.component';

describe('LsitInvoiceComponent', () => {
  let component: LsitInvoiceComponent;
  let fixture: ComponentFixture<LsitInvoiceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LsitInvoiceComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LsitInvoiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
