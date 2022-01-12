import { DatePipe } from '@angular/common';
import { Pipe, PipeTransform } from '@angular/core';

import { Constants } from '../../Constants';

@Pipe({
  name: 'SecondsFormatPipe'
})
export class SecondsFormatPipePipe extends DatePipe implements PipeTransform {
  transform(value: any, args?: any): any {
    return super.transform(value, Constants.SECONDS)
  };
}
