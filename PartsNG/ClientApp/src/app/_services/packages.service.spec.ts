import { TestBed } from '@angular/core/testing';

import { PropertiesService } from './Properties.service';

describe('PropertiesService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: PropertiesService = TestBed.get(PropertiesService);
    expect(service).toBeTruthy();
  });
});
