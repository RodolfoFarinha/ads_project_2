import { DataUploadComponent } from './components/data-upload/data-upload.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CalendarComponent } from './components/calendar/calendar.component';

const routes: Routes = [
  { path: 'dataupload', component: DataUploadComponent },
  { path: 'calendar', component: CalendarComponent },
  { path: '**', redirectTo: 'dataupload', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
