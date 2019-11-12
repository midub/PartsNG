import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreatePackageFormComponent } from './create-package-form.component';

describe('CreatePackageFormComponent', () => {
  let component: CreatePackageFormComponent;
  let fixture: ComponentFixture<CreatePackageFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreatePackageFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreatePackageFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
