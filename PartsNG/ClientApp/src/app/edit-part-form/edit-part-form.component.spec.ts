import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditPartFormComponent } from './edit-part-form.component';

describe('EditPartFormComponent', () => {
  let component: EditPartFormComponent;
  let fixture: ComponentFixture<EditPartFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditPartFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditPartFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
