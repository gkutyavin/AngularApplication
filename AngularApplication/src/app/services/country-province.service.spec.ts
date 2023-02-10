import { TestBed } from '@angular/core/testing';

import { CountryProvinceService } from './country-province.service';

describe('ContryProvinceService', () => {
  let service: CountryProvinceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CountryProvinceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
