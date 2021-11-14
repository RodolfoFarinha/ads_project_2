/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ScheduleCalculatorService } from './schedulecalculator.service';

describe('Service: Schedulecalculator', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ScheduleCalculatorService]
    });
  });

  it('should ...', inject([ScheduleCalculatorService], (service: ScheduleCalculatorService) => {
    expect(service).toBeTruthy();
  }));
});
