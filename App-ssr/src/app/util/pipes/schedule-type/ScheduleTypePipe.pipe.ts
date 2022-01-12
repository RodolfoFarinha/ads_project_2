import { Pipe, PipeTransform } from '@angular/core';
import { ScheduleType } from './../../enums/ScheduleType.enum';

@Pipe({
  name: 'ScheduleTypePipe'
})
export class ScheduleTypePipePipe implements PipeTransform {

  transform(value: any, args?: any): any {
    return ScheduleType[value];
  }

}
