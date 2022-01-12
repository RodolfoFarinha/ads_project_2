/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { SharedQualityScheduleService } from './SharedQualitySchedule.service';

describe('Service: SharedQualityScheduleService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [SharedQualityScheduleService]
    });
  });

  it('should ...', inject([SharedQualityScheduleService], (service: SharedQualityScheduleService) => {
    expect(service).toBeTruthy();
  }));
});
