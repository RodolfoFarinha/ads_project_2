// Angular
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule, NO_ERRORS_SCHEMA, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';

// Angular Calendar
import { adapterFactory } from 'angular-calendar/date-adapters/date-fns';
import { CalendarModule, DateAdapter } from 'angular-calendar';

// PrimeNg
import { ChartModule } from 'primeng/chart';
import { TableModule } from 'primeng/table';
import { SelectButtonModule } from 'primeng/selectbutton';

// Angular Material
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';

// Ng Bootstrap
import { NgbModalModule, NgbModule } from '@ng-bootstrap/ng-bootstrap';

// Ngx Bootstrap
import { CollapseModule } from 'ngx-bootstrap/collapse';

// Components
import { AppComponent } from './app.component';
import { CalendarComponent } from './components/calendar/calendar.component';
import { DataUploadComponent } from './components/data-upload/data-upload.component';
import { MenuComponent } from './components/menu/menu.component';
import { TableComponent } from './components/table/table.component';
import { AnalysisComponent } from './components/analysis/analysis.component';
import { LoadingInterceptor } from './util/core/loading.interceptor';

// Pipes
import { DateTimeFormatPipePipe } from './util/pipes/datetime-format/DateTimeFormatPipe.pipe';
import { ScheduleTypePipePipe } from './util/pipes/schedule-type/ScheduleTypePipe.pipe';
import { SecondsFormatPipePipe } from './util/pipes/seconds-format/SecondsFormatPipe.pipe';

// Routing
import { AppRoutingModule } from './app-routing.module';
import { LoadingComponent } from './components/loading/loading.component';

@NgModule({
  declarations: [
    // Components
    AppComponent,
    CalendarComponent,
    DataUploadComponent,
    MenuComponent,
    TableComponent,
    AnalysisComponent,
    LoadingComponent,

    // Pipes
    DateTimeFormatPipePipe,
    SecondsFormatPipePipe,
    ScheduleTypePipePipe
  ],
  imports: [
    // Angular
    BrowserModule.withServerTransition({ appId: 'serverApp' }),
    BrowserAnimationsModule,
    CommonModule,
    FormsModule,
    HttpClientModule,

    //PrimeNg
    ChartModule,
    TableModule,
    SelectButtonModule,

    // Angular Material
    MatProgressSpinnerModule,

    // Ng Bootstrap
    NgbModule,
    NgbModalModule,

    // Ngx Bootstrap
    CollapseModule.forRoot(),

    //Routing
    AppRoutingModule,

    // Angular Calendar
    CalendarModule.forRoot({ provide: DateAdapter, useFactory: adapterFactory }),
  ],
  exports: [
    DateTimeFormatPipePipe,
    SecondsFormatPipePipe,
    ScheduleTypePipePipe
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
