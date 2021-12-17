import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CalendarComponent } from './components/calendar/calendar.component';
import { TableComponent } from './components/table/table.component';
import { AnalysisComponent } from './components/analysis/analysis.component';
import { DataUploadComponent } from './components/data-upload/data-upload.component';

const routes: Routes = [
  { path: 'dataupload', component: DataUploadComponent },
  { path: 'calendar', component: CalendarComponent },
  { path: 'table', component: TableComponent },
  { path: 'analysis', component: AnalysisComponent },
  { path: '**', redirectTo: 'dataupload', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
