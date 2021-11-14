import { Component, OnInit } from '@angular/core';
import { ScheduleCalculatorService } from 'src/app/services/schedule-calculator-service/schedulecalculator.service';
import { SharedQualityScheduleService } from 'src/app/util/shared-quality-schedule/SharedQualitySchedule.service';

@Component({
  selector: 'app-data-upload',
  templateUrl: './data-upload.component.html',
  styleUrls: ['./data-upload.component.css']
})
export class DataUploadComponent implements OnInit {

  propertiesFile: File;
  roomsFile: File;
  sessionsFile: File;

  constructor(private scheduleCalculatorService: ScheduleCalculatorService, private sharedQualityScheduleService: SharedQualityScheduleService) { }

  ngOnInit() {

  }

  propertiesFileChage(files) {
    if (files.length === 0)
      return;

    this.propertiesFile = <File>files[0];
  }

  roomsFileChage(files) {
    if (files.length === 0)
      return;

    this.roomsFile = <File>files[0];
  }

  sessionsFileChage(files) {
    if (files.length === 0)
      return;

    this.sessionsFile = <File>files[0];
  }

  calcular() {
    if ((this.propertiesFile !== undefined && this.roomsFile !== null && this.sessionsFile !== undefined)) {
      this.scheduleCalculatorService.ScheduleCalculator(this.propertiesFile, this.roomsFile, this.sessionsFile).subscribe(
        response => {
          this.sharedQualityScheduleService.setGlobalQualitySchedule(response);
          console.log(response);
        }, error => {
          console.log("Error");
        }
      );
    }
  }
}
