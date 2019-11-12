import { TestBed } from '@angular/core/testing';

import { PropertysService } from './Propertys.service';

describe('PropertysService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: PropertysService = TestBed.get(PropertysService);
    expect(service).toBeTruthy();
  });
});
