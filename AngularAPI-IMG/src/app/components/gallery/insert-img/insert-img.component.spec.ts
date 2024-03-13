import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InsertImgComponent } from './insert-img.component';

describe('InsertImgComponent', () => {
  let component: InsertImgComponent;
  let fixture: ComponentFixture<InsertImgComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [InsertImgComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(InsertImgComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
