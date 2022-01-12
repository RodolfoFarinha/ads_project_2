import { Guid } from 'guid-typescript';
import { ConfigurationType } from 'src/app/util/enums/ConfigurationType.enum';

export interface Configuration {
  configurationKey: Guid,
  configurationType: ConfigurationType,
  value: string
}
