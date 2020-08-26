import { TestBed } from '@angular/core/testing';

import { DynamicService } from './dynamic.service';

describe('DynamicService', () => {
  let service: DynamicService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DynamicService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
