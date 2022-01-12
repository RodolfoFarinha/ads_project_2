import { Component, OnInit } from '@angular/core';
import { Guid } from 'guid-typescript';
import { Configuration } from 'src/app/models/configuration/Configuration';
import { ConfigurationService } from 'src/app/services/configuration-service/configuration.service';
import { ScheduleCalculatorService } from 'src/app/services/schedule-calculator-service/schedulecalculator.service';
import { ConfigurationType } from 'src/app/util/enums/ConfigurationType.enum';
import { ScheduleType } from 'src/app/util/enums/ScheduleType.enum';
import { SharedQualityScheduleService } from 'src/app/util/shared-quality-schedule/SharedQualitySchedule.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-data-upload',
  templateUrl: './data-upload.component.html',
  styleUrls: ['./data-upload.component.css']
})
export class DataUploadComponent implements OnInit {

  propertiesFile: File | undefined;
  roomsFile: File | undefined;
  sessionsFile: File | undefined;

  propertyName: Configuration = { configurationKey: Guid.createEmpty(), configurationType: -1, value: '' };
  propertyDescription: Configuration = { configurationKey: Guid.createEmpty(), configurationType: -1, value: '' };
  propertyStatus: Configuration = { configurationKey: Guid.createEmpty(), configurationType: -1, value: '' };
  availableManagement: Configuration = { configurationKey: Guid.createEmpty(), configurationType: -1, value: '' };
  availableRequest: Configuration = { configurationKey: Guid.createEmpty(), configurationType: -1, value: '' };

  buildingName: Configuration = { configurationKey: Guid.createEmpty(), configurationType: -1, value: '' };
  roomName: Configuration = { configurationKey: Guid.createEmpty(), configurationType: -1, value: '' };
  normalCapacity: Configuration = { configurationKey: Guid.createEmpty(), configurationType: -1, value: '' };
  examCapacity: Configuration = { configurationKey: Guid.createEmpty(), configurationType: -1, value: '' };

  courseName: Configuration = { configurationKey: Guid.createEmpty(), configurationType: -1, value: '' };
  unitName: Configuration = { configurationKey: Guid.createEmpty(), configurationType: -1, value: '' };
  shiftName: Configuration = { configurationKey: Guid.createEmpty(), configurationType: -1, value: '' };
  className: Configuration = { configurationKey: Guid.createEmpty(), configurationType: -1, value: '' };
  startDate: Configuration = { configurationKey: Guid.createEmpty(), configurationType: -1, value: '' };
  endDate: Configuration = { configurationKey: Guid.createEmpty(), configurationType: -1, value: '' };
  day: Configuration = { configurationKey: Guid.createEmpty(), configurationType: -1, value: '' };
  propertySessionName: Configuration = { configurationKey: Guid.createEmpty(), configurationType: -1, value: '' };
  enrolledStudents: Configuration = { configurationKey: Guid.createEmpty(), configurationType: -1, value: '' };

  scheduleTypesEnum = ScheduleType;
  scheduleTypes: string[];
  algorithm = "Normal";

  constructor(
    private configurationService: ConfigurationService,
    private scheduleCalculatorService: ScheduleCalculatorService,
    private sharedQualityScheduleService: SharedQualityScheduleService
  ) { }

  ngOnInit() {
    this.scheduleTypes = Object.keys(this.scheduleTypesEnum);

    this.configurationService.getAll().subscribe(
      response => {
        response.forEach(configuration => {
          switch (configuration.configurationType) {
            case ConfigurationType.PropertyName: {
              this.propertyName = configuration
              break;
            }
            case ConfigurationType.PropertyDescription: {
              this.propertyDescription = configuration
              break;
            }
            case ConfigurationType.PropertyStatus: {
              this.propertyStatus = configuration
              break;
            }
            case ConfigurationType.AvailableManagement: {
              this.availableManagement = configuration
              break;
            }
            case ConfigurationType.AvailableRequest: {
              this.availableRequest = configuration
              break;
            }
            case ConfigurationType.BuildingName: {
              this.buildingName = configuration
              break;
            }
            case ConfigurationType.RoomName: {
              this.roomName = configuration
              break;
            }
            case ConfigurationType.NormalCapacity: {
              this.normalCapacity = configuration
              break;
            }
            case ConfigurationType.ExamCapacity: {
              this.examCapacity = configuration
              break;
            }
            case ConfigurationType.CourseName: {
              this.courseName = configuration
              break;
            }
            case ConfigurationType.UnitName: {
              this.unitName = configuration
              break;
            }
            case ConfigurationType.ShiftName: {
              this.shiftName = configuration
              break;
            }
            case ConfigurationType.ClassName: {
              this.className = configuration
              break;
            }
            case ConfigurationType.StartDate: {
              this.startDate = configuration
              break;
            }
            case ConfigurationType.EndDate: {
              this.endDate = configuration
              break;
            }
            case ConfigurationType.Day: {
              this.day = configuration
              break;
            }
            case ConfigurationType.PropertySessionName: {
              this.propertySessionName = configuration
              break;
            }
            case ConfigurationType.EnrolledStudents: {
              this.enrolledStudents = configuration
              break;
            }
          }
        });
      }, error => {
        console.log("Error");
      }
    );
  }

  propertiesFileChage(files: FileList | null) {
    if (files != null) {
      if (files.length === 0)
        return;

      this.propertiesFile = <File>files[0];
    }
  }

  roomsFileChage(files: FileList | null) {
    if (files != null) {
      if (files?.length === 0)
        return;
      this.roomsFile = <File>files[0];
    }
  }

  sessionsFileChage(files: FileList | null) {
    if (files != null) {
      if (files.length === 0)
        return;

      this.sessionsFile = <File>files[0];
    }
  }

  propertyChange() {
    this.configurationService.post(this.propertyName).subscribe();
    this.configurationService.post(this.propertyDescription).subscribe();
    this.configurationService.post(this.propertyStatus).subscribe();
    this.configurationService.post(this.availableManagement).subscribe();
    this.configurationService.post(this.availableRequest).subscribe();

    this.configurationService.post(this.buildingName).subscribe();
    this.configurationService.post(this.roomName).subscribe();
    this.configurationService.post(this.normalCapacity).subscribe();
    this.configurationService.post(this.examCapacity).subscribe();

    this.configurationService.post(this.courseName).subscribe();
    this.configurationService.post(this.unitName).subscribe();
    this.configurationService.post(this.shiftName).subscribe();
    this.configurationService.post(this.className).subscribe();
    this.configurationService.post(this.startDate).subscribe();
    this.configurationService.post(this.endDate).subscribe();
    this.configurationService.post(this.day).subscribe();
    this.configurationService.post(this.propertySessionName).subscribe();
    this.configurationService.post(this.enrolledStudents).subscribe();
  }

  calcular() {
    if ((this.propertiesFile !== undefined && this.roomsFile !== null && this.sessionsFile !== undefined)) {
      this.scheduleCalculatorService.ScheduleCalculator(this.propertiesFile, this.roomsFile, this.sessionsFile).subscribe(
        response => {
          this.sharedQualityScheduleService.setGlobalQualitySchedule(response);
          // console.log(response);
        }, error => {
          console.log("Error");
        }
      );
    }
  }

  downloadCSV() {
    switch (this.algorithm) {
      case "Normal":
        window.location.href = environment.url + "resources/download/Normal.csv";
        break;
      case "OverBooking25":
        window.location.href = environment.url + "resources/download/OverBooking25.csv";
        break;
      case "RoomCloseCapacity":
        window.location.href = environment.url + "resources/download/RoomCloseCapacity.csv";
        break;
      case "RandomOrder":
        window.location.href = environment.url + "resources/download/RandomOrder.csv";
        break;
      case "AllVariables":
        window.location.href = environment.url + "resources/download/AllVariables.csv";
        break;
    }
  }

  changeAlgorithm(event) {
    this.algorithm = event
  }
}
