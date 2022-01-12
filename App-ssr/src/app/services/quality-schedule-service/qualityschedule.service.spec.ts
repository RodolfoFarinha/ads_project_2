import { TestBed } from '@angular/core/testing';

import { QualityScheduleService } from './qualityschedule.service';

describe('QualityscheduleService', () => {
  let service: QualityScheduleService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(QualityScheduleService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
