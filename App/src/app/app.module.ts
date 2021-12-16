// Angular
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';

// Angular Calendar
import { adapterFactory } from 'angular-calendar/date-adapters/date-fns';
import { CalendarModule, DateAdapter } from 'angular-calendar';

// PrimeNg
import { TableModule } from 'primeng/table';

// Ng Bootstrap
import { NgbModalModule, NgbModule } from '@ng-bootstrap/ng-bootstrap';

// Ngx Bootstrap
import { CollapseModule } from 'ngx-bootstrap/collapse';

// Components
import { AppComponent } from './app.component';
import { CalendarComponent } from './components/calendar/calendar.component';
import { DataUploadComponent } from './components/data-upload/data-upload.component';
import { MenuComponent } from './components/menu/menu.component';

// Routing
import { AppRoutingModule } from './app-routing.module';
import { TableComponent } from './components/table/table.component';

@NgModule({
  declarations: [
    // Components
    AppComponent,
    CalendarComponent,
    DataUploadComponent,
    MenuComponent,
    TableComponent
  ],
  imports: [
    // Angular
    BrowserModule,
    BrowserAnimationsModule,
    CommonModule,
    FormsModule,
    HttpClientModule,

    //PrimeNg
    TableModule,

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
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
