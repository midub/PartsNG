import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PartsListItemComponent } from './parts-list-item.component';

describe('PartsListItemComponent', () => {
  let component: PartsListItemComponent;
  let fixture: ComponentFixture<PartsListItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PartsListItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PartsListItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
