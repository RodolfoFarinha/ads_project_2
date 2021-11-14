import { Guid } from 'guid-typescript';

export interface Configuration {
  configurationKey: Guid,
  key: string,
  value: string
}

