import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreatePartFormComponent } from './create-part-form.component';

describe('CreatePartFormComponent', () => {
  let component: CreatePartFormComponent;
  let fixture: ComponentFixture<CreatePartFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreatePartFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreatePartFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
